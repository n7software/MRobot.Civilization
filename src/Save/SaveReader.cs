using System;
using System.IO;
using System.Linq;
using System.Text;
using MRobot.Civilization.Civs;
using MRobot.Civilization.Color;
using MRobot.Civilization.Game;
using MRobot.Civilization.Game.Maps;
using MRobot.Civilization.Game.Maps.Enums;

namespace MRobot.Civilization.Save
{
    class SaveReader : IDisposable
    {
        private BinaryReader Reader;
        private MemoryStream Copy;
        private BinaryWriter CopyWriter;

        public SaveReader(Stream input)
        {
            Init(input, (int)input.Length);
        }

        public SaveReader(Stream input, int length)
        {
            Init(input, length);
        }

        private void Init(Stream input, int length)
        {
            Reader = new BinaryReader(input);
            Copy = new MemoryStream(length);
            CopyWriter = new BinaryWriter(Copy);
        }

        public byte[] AllBytesRead
        {
            get { return Copy.ToArray(); }
        }

        #region Base Reading Methods
        //These methods should be duplicated stubs from BinaryReader
        //Each should copy the values read into the copy

        public long Position
        {
            get { return Reader.BaseStream.Position; }
        }

        public char[] ReadChars(int count)
        {
            var chars = Reader.ReadChars(count);
            CopyWriter.Write(chars);
            return chars;
        }

        public int ReadInt32()
        {
            int val = Reader.ReadInt32();
            CopyWriter.Write(val);
            return val;
        }

        public byte[] ReadBytes(int length)
        {
            byte[] bytes = Reader.ReadBytes(length);
            CopyWriter.Write(bytes);
            return bytes;
        }

        public byte ReadByte()
        {
            byte b = Reader.ReadByte();
            CopyWriter.Write(b);
            return b;
        }

        public bool ReadBoolean()
        {
            bool b = Reader.ReadBoolean();
            CopyWriter.Write(b);
            return b;
        }
        #endregion

        #region Convenience and Verification Methods
        public void VerifySectionDelimiter(byte[] expectedValue)
        {
            if (expectedValue.Length != 4)
                throw new ArgumentException("Section delimiter must be 4 bytes long");
            VerifySectionDelimiter(BitConverter.ToInt32(expectedValue, 0));
        }

        public void VerifySectionDelimiter(int expectedValue = 0x40)
        {
            int val = this.ReadInt32();
            if (val != expectedValue)
                throw new InvalidSaveException("Expected section delimiter " + expectedValue + " at " + (Reader.BaseStream.Position - 4));
        }

        public SaveString ReadSaveString(int prefixParts = 0, bool allCaps = false)
        {
            int length = this.ReadInt32();
            var bytes = this.ReadBytes(length);

            string str;
            string asciiStr = Encoding.ASCII.GetString(bytes);

            //Unicode string detection
            using (var memStream = new MemoryStream(bytes))
            using (var memReader = new BinaryReader(memStream))
            {
                //ReadChars will detect if the string is unicode
                string possibleUnicodeStr = new String(memReader.ReadChars(length / 2 + 1));

                //If the string is not unicode, it'll be identical to the first half of the original ASCII string
                if (asciiStr.StartsWith(possibleUnicodeStr))
                    str = asciiStr;
                //If the string is unicode, it'll be totally different from the original ASCII string
                else str = possibleUnicodeStr;
            }


            if (String.IsNullOrEmpty(str))
                return new SaveString();

            var parts = str.Split('_');

            Func<string, string, string> assembleString = (acc, next) => acc + '_' + next;
            string prefix =
                prefixParts > 0
                ? parts.Take(prefixParts).Aggregate(assembleString)
                : String.Empty;
            string val;
            if (parts.Length <= prefixParts)
                val = String.Empty;
            else val = parts.Skip(prefixParts).Aggregate(assembleString);

            return new SaveString(prefix, val, allCaps);
        }

        public ICivilization ReadCiv(bool civMinor = false)
        {
            var civStr = this.ReadSaveString(1);
            ICivilization civ = null;
            if (!civMinor)
                civ = Civs.Civilization.FindBySaveName(civStr);
            if (civ == null)
            {
                if (civMinor && String.IsNullOrEmpty(civStr.Prefix))
                    civ = null;
                else if (civMinor)
                    civ = new CivilizationMinor(civStr.Value, null);
                else
                    civ = new Civs.Civilization(-1, civStr.Value, null, Leader.Barbarian);
            }
            return civ;
        }

        public PlayerDifficulty ReadDifficulty()
        {
            return (PlayerDifficulty)(ReadEnum(typeof(PlayerDifficulty)) ?? PlayerDifficulty.Prince);
        }

        public GameEra ReadEra()
        {
            return (GameEra)(ReadEnum(typeof(GameEra)) ?? GameEra.Ancient);
        }

        public GamePace ReadPace()
        {
            return (GamePace)(ReadEnum(typeof(GamePace)) ?? Game.GamePace.Quick);
        }

        public MapSize ReadMapSize()
        {
            return (MapSize)(ReadEnum(typeof(MapSize)) ?? MapSize.Standard);
        }

        public Map ReadMap(MapSize worldSize)
        {
            var mapPath = this.ReadSaveString();
            var map = Map.FindByPath(mapPath);
            if (map != null)
            {
                map.SetMapSize(worldSize);
            }
            else
            {
                string mapName = Path.GetFileNameWithoutExtension(mapPath);
                map = new Map
                (
                    name: mapName,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(worldSize),
                    saveName: mapPath
                );
            }
            return map;
        }

        public void SkipTextKey()
        {
            for (int i = 0; i < 7; i++)
                this.ReadSaveString();
        }

        public void SkipInt32s(int count)
        {
            for (int i = 0; i < count; i++)
                this.ReadInt32();
        }

        public void SkipSaveStrings(int count)
        {
            for (int i = 0; i < count; i++)
                this.ReadSaveString();
        }

        public void SkipByteSection(int byteCount = SaveHelpers.StandardSectionBlockCount)
        {
            this.VerifySectionDelimiter();
            this.ReadBytes(byteCount);
        }

        public void SkipIntSection(int intCount = SaveHelpers.StandardSectionBlockCount)
        {
            this.VerifySectionDelimiter();
            this.SkipInt32s(intCount);
        }

        public void SkipStringSection(int stringCount = SaveHelpers.StandardSectionBlockCount)
        {
            this.VerifySectionDelimiter();
            this.SkipSaveStrings(stringCount);
        }
    
        public PlayerColor ReadPlayerColor()
        {
            var str = this.ReadSaveString(1);
            var color = PlayerColor.All.SingleOrDefault(c => c.SaveName == str);
            if (color == null) color = new PlayerColor(str.Value);
            return color;
        }

        public Leader ReadLeader()
        {
            var str = this.ReadSaveString(1);
            var leader = Leader.All.SingleOrDefault(c => c.SaveName == str);
            if (leader == null) leader = new Leader(str.Value);
            return leader;
        }

        public void ReadPreference(GameSave gameSave)
        {
            var prefName = this.ReadSaveString(1);
            switch (prefName.Value)
            {
                case "DYNAMIC_TURNS":
                    gameSave.DynamicTurns = this.ReadIntAsBool();
                    break;
                case "SIMULTANEOUS_TURNS":
                    gameSave.SimultaneousTurns = this.ReadIntAsBool();
                    break;
                case "PITBOSS":
                    gameSave.Pitboss = this.ReadIntAsBool();
                    break;
                case "END_TURN_TIMER_ENABLED":
                    gameSave.EnableTurnTimer = this.ReadIntAsBool();
                    break;
                case "POLICY_SAVING":
                    gameSave.AllowPolicySaving = this.ReadIntAsBool();
                    break;
                case "PROMOTION_SAVING":
                    gameSave.AllowPromotionSaving = this.ReadIntAsBool();
                    break;
                case "COMPLETE_KILLS":
                    gameSave.CompleteKills = this.ReadIntAsBool();
                    break;
                case "DISABLE_START_BIAS":
                    gameSave.DisableStartBias = this.ReadIntAsBool();
                    break;
                case "NEW_RANDOM_SEED":
                    gameSave.NewRandomSeed = this.ReadIntAsBool();
                    break;
                case "NO_GOODY_HUTS":
                    gameSave.NoAncientRuins = this.ReadIntAsBool();
                    break;
                case "NO_BARBARIANS":
                    gameSave.NoBarbarians = this.ReadIntAsBool();
                    break;
                case "NO_CITY_RAZING":
                    gameSave.NoCityRazing = this.ReadIntAsBool();
                    break;
                case "NO_ESPIONAGE":
                    gameSave.NoEspionage = this.ReadIntAsBool();
                    break;
                case "ONE_CITY_CHALLENGE":
                    gameSave.OneCityChallenge = this.ReadIntAsBool();
                    break;
                case "RAGING_BARBARIANS":
                    gameSave.RagingBarbarians = this.ReadIntAsBool();
                    break;
                case "RANDOM_PERSONALITIES":
                    gameSave.RandomPersonalities = this.ReadIntAsBool();
                    break;
                case "ALWAYS_WAR":
                    gameSave.AlwaysWar = this.ReadIntAsBool();
                    break;
                case "ALWAYS_PEACE":
                    gameSave.AlwaysPeace = this.ReadIntAsBool();
                    break;
                case "NO_CHANGING_WAR_PEACE":
                    gameSave.NoChangingWarPeace = this.ReadIntAsBool();
                    break;
                case "LOCK_MODS":
                    gameSave.LockMods = this.ReadIntAsBool();
                    break;
                case "NO_SCIENCE":
                    gameSave.NoScience = this.ReadIntAsBool();
                    break;
                case "NO_RELIGION":
                    gameSave.NoReligion = this.ReadIntAsBool();
                    break;
                case "NO_POLICIES":
                    gameSave.NoPolicies = this.ReadIntAsBool();
                    break;
                case "NO_HAPPINESS":
                    gameSave.NoHappiness = this.ReadIntAsBool();
                    break;
                case "NO_LEAGUES":
                    gameSave.NoLeagues = this.ReadIntAsBool();
                    break;
                case "NO_CULTURE_OVERVIEW_UI":
                    gameSave.NoCultureOverviewUI = this.ReadIntAsBool();
                    break;
                case "QUICK_COMBAT":
                    gameSave.QuickCombat = this.ReadIntAsBool();
                    break;
                case "QUICK_MOVEMENT":
                    gameSave.QuickMovement = this.ReadIntAsBool();
                    break;
                default:
                    gameSave.CustomSettings[prefName.Value] = this.ReadIntAsBool();
                    break;
            }
        }

        public void ReadMapPreference(GameSave gameSave)
        {
            var mapProps = gameSave.Map.MapProperties;
            int mapPropIndex = int.Parse(this.ReadSaveString()) - 1;
            if (mapPropIndex < mapProps.Count)
            {
                var mapProp = (GameProperty)mapProps[mapPropIndex];
                int valIndex = this.ReadInt32() - 1;
                var possibleValues = mapProp.PossibleValues.Keys.ToArray();
                if(valIndex >= 0 && valIndex < possibleValues.Length)
                    mapProp.Value = possibleValues[valIndex];
            }
        }

        #endregion

        #region Internal Methods
        private object ReadEnum(Type enumType)
        {
            var diffStr = this.ReadSaveString(1).Value;
            diffStr = diffStr.ToLower();
            if (!String.IsNullOrWhiteSpace(diffStr))
            {
                var chars = diffStr.ToCharArray();
                chars[0] = Char.ToUpper(chars[0]);
                return Enum.Parse(enumType, new String(chars));
            }
            else return null;
        }


        private bool ReadIntAsBool()
        {
            return this.ReadInt32() != 0;
        }
        #endregion

        public void Dispose()
        {
            CopyWriter.Dispose();
        }
    }
}
