using MRobot.Civilization.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MRobot.Civilization.Base
{
    internal abstract class SaveReader : IDisposable
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

        #region Specific Types And Defaults
        
        protected abstract IEnumerable<PlayerDifficulty> AllDifficulties();

        protected abstract IEnumerable<PlayerColor> AllPlayerColors();

        protected abstract IEnumerable<Leader> AllLeaders();

        protected abstract IEnumerable<MapSize> AllMapSizes();

        protected abstract PlayerDifficulty DefaultDifficulty();

        protected abstract MapSize DefaultMapSize();

        protected abstract ICivilization FindCivBySaveName(SaveString civStr);

        protected abstract Leader DefaultLeader();

        protected abstract Map FindMapByPath(SaveString saveString);

        protected abstract GameProperty<MapSize> GetNonStandardMapSize(MapSize size);

        #endregion

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
                : string.Empty;
            string val;
            if (parts.Length <= prefixParts)
                val = string.Empty;
            else val = parts.Skip(prefixParts).Aggregate(assembleString);

            return new SaveString(prefix, val, allCaps);
        }
        
        public PlayerDifficulty ReadDifficulty()
        {
            var name = ReadSaveString(1).Value;
            return AllDifficulties().FirstOrDefault(d => d.Name == name) ?? DefaultDifficulty();
        }

        public MapSize ReadMapSize()
        {
            var name = ReadSaveString(1);
            return AllMapSizes().FirstOrDefault(ms => ms.Name == name) ?? DefaultMapSize();
        }

        public ICivilization ReadCiv(bool civMinor = false)
        {
            var civStr = ReadSaveString(1);
            ICivilization civ = null;
            if (!civMinor)
                civ = FindCivBySaveName(civStr);
            if (civ == null)
            {
                if (civMinor && string.IsNullOrEmpty(civStr.Prefix))
                    civ = null;
                else if (civMinor)
                    civ = new CivilizationMinor(civStr.Value, null);
                else
                    civ = new Base.Civilization(-1, civStr.Value, null, DefaultLeader());
            }
            return civ;
        }

        public Map ReadMap(MapSize worldSize, MapFactory mapFactory)
        {
            var mapPath = ReadSaveString();
            var map = FindMapByPath(mapPath);
            if (map != null)
            {
                map.SetMapSize(worldSize);
            }
            else
            {
                string mapName = Path.GetFileNameWithoutExtension(mapPath);
                map = mapFactory(mapName, GetNonStandardMapSize(worldSize), mapPath);
            }
            return map;
        }

        public PlayerColor ReadPlayerColor()
        {
            var str = ReadSaveString(1);
            return AllPlayerColors().FirstOrDefault(c => c.SaveName == str) ?? new PlayerColor(str.Value);
        }

        public Leader ReadLeader()
        {
            var str = ReadSaveString(1);
            return AllLeaders().FirstOrDefault(c => c.SaveName == str) ?? new Leader(str.Value);
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

        #endregion

        #region Internal Methods
        protected object ReadEnum(Type enumType)
        {
            var diffStr = ReadSaveString(1).Value;
            diffStr = diffStr.ToLower();
            if (!string.IsNullOrWhiteSpace(diffStr))
            {
                var chars = diffStr.ToCharArray();
                chars[0] = char.ToUpper(chars[0]);
                return Enum.Parse(enumType, new string(chars));
            }
            else return null;
        }
        
        public bool ReadIntAsBool()
        {
            return this.ReadInt32() != 0;
        }
        #endregion

        public void Dispose()
        {
            CopyWriter.Dispose();
        }
    }

    public delegate Map MapFactory(string name, GameProperty<MapSize> sizeProperty, SaveString path);
}
