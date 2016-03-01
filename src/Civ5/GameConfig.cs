using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;
using MRobot.Civilization.Civ5.Save;

namespace MRobot.Civilization.Civ5
{
    public class GameConfig : Base.GameConfig
    {
        internal static readonly byte[] HeaderCrazyBytes = new byte[] { 0xB3, 0xB6, 0xB2, 0xC3, 0x9C, 0x43, 0x0B, 0x48, 0x85, 0x36, 0x1C, 0xF3, 0x9F, 0xCF, 0xC6, 0x82, 0x05, 0x00, 0x00, 0x00, 0x31, 0x2E, 0x30, 0x2E, 0x30, 0x2C, 0x15, 0x41, 0x0D, 0x8E, 0x94, 0x8F, 0x49, 0x8C, 0xDF, 0x69, 0x9D, 0x04, 0xC9, 0x8A, 0x95 };

        public GameConfig()
        {
            Map = Maps.Continents;

            Players = new Player[SaveHelpers.StandardSectionBlockCount];
            for (int i = 0; i < SaveHelpers.MaxPlayers; i++)
                Players[i] = Player.ClosedSlot;
            for (int i = SaveHelpers.MaxPlayers; i < SaveHelpers.StandardSectionBlockCount - 1; i++)
                Players[i] = Player.CityState;
            Players[Players.Length - 1] = Player.Barbarian;

            _Expansions.Add(Data.Expansions.Mongolia);
            _Expansions.Add(Data.Expansions.Upgrade1);

            CulturalVictory = true;
            DiplomaticVictory = true;
            TimeVictory = true;
            ScienceVictory = true;

            HeaderStartingEra = GameEraProps.Vanilla;
            StartingEra = GameEraProps.Vanilla;

            DominationVictory = true;
            
            EnableTurnTimer = false;
            TurnTimer = new SaveNumber(0, 0, 999);

            AllowPolicySaving = false;
            AllowPromotionSaving = false;
            CompleteKills = false;
            DisableStartBias = false;
            NewRandomSeed = false;
            NoAncientRuins = false;
            NoBarbarians = false;
            NoCityRazing = false;
            NoEspionage = false;
            OneCityChallenge = false;
            QuickCombat = true;
            QuickMovement = true;
            RagingBarbarians = false;
            RandomPersonalities = false;

            DynamicTurns = false;
            SimultaneousTurns = false;
            Pitboss = false;

            //Special options not visible in the in-game setup menu
            NoReligion = false;
            AlwaysWar = false;
            AlwaysPeace = false;
            NoChangingWarPeace = false;
            LockMods = false;
            NoScience = false;
            NoPolicies = false;
            NoHappiness = false;
            NoLeagues = false;
            NoCultureOverviewUI = false;

            CustomSettings = new Dictionary<string, bool>();

            TimeOffset = 3;
            GameStarted = false;
        }

        public ICivilization HeaderCiv { get; set; }
        
        public bool CulturalVictory { get; set; }
        public bool DiplomaticVictory { get; set; }
        public bool TimeVictory { get; set; }
        public bool ScienceVictory { get; set; }

        public IGameProperty<object> GamePace { get; }  = CreateGamePaceProperty(Data.GamePace.Quick);

        /// <summary>
        /// Note that all games have the Upgrade 1 expansion
        /// </summary>
        public IEnumerable<Expansion> Expansions => _Expansions.ToArray();

        public bool HasGnkOrBnw => _Expansions.Any(e => e == Data.Expansions.GodsAndKings || e == Data.Expansions.BraveNewWorld);

        public bool HasGnk => _Expansions.Contains(Data.Expansions.GodsAndKings);

        public bool HasBnw => _Expansions.Contains(Data.Expansions.BraveNewWorld);

        public bool HasDlcCiv
        {
            get
            {
                return _Expansions.Any(e =>
                    e == Data.Expansions.Babylon ||
                    e == Data.Expansions.Denmark ||
                    e == Data.Expansions.Korea ||
                    e == Data.Expansions.Polynesia ||
                    e == Data.Expansions.SpainAndInca);
            }
        }
        
        public PlayerDifficulty HeaderDifficulty { get; set; }

        protected override string CurrentVersion()
        {
            return "1.0.3.144 (395131)";
        }

        protected override string CurrentBuild()
        {
            return "395131";
        }

        /// <summary>
        /// Note that adding all expansions to a map will automatically add the Civilization V Compete expansion
        /// </summary>
        public void AddExpansion(Expansion expansion)
        {
            if (expansion != Data.Expansions.CivilizationVComplete)
            {
                _Expansions.Add(expansion);
                if (expansion == Data.Expansions.GodsAndKings || expansion == Data.Expansions.BraveNewWorld)
                {
                    SetPropertiesForExpansions();
                }
                if (_Expansions.IsSupersetOf(Data.Expansions.All))
                    _Expansions.Add(Data.Expansions.CivilizationVComplete);
            }
        }

        public void RemoveExpansion(Expansion expansion)
        {
            if (expansion != Data.Expansions.CivilizationVComplete && expansion != Data.Expansions.Upgrade1 && expansion != Data.Expansions.Mongolia)
            {
                _Expansions.Remove(expansion);
                if (!HasGnkOrBnw)
                {
                    SetPropertiesForVanilla();
                }
                if (!_Expansions.IsSupersetOf(Data.Expansions.All))
                    _Expansions.Remove(Data.Expansions.CivilizationVComplete);
            }
        }

        public void Save(Stream outputStream)
        {
            new GameSaver(this).Save(outputStream);
        }

        public override byte[] ToBytes()
        {
            return new GameSaver(this).ToBytes();
        }

        protected virtual void SetPropertiesForVanilla()
        {
            HeaderStartingEra = GameEraProps.Vanilla;
            StartingEra = GameEraProps.Vanilla;
        }

        protected virtual void SetPropertiesForExpansions()
        {
            HeaderStartingEra = GameEraProps.Expansions;
            StartingEra = GameEraProps.Expansions;
        }

        private static IGameProperty<object> CreateGamePaceProperty(GamePace defaultPace)
        {
            return new GameProperty<object>("Game Pace", defaultPace, GamePaceDict.GamePaceAsDict);
        }

        #region Basic Options
        public IGameProperty<GameEra> HeaderStartingEra { get; private set; }
        public IGameProperty<GameEra> StartingEra { get; private set; }
        #endregion

        #region Victory Types
        public bool DominationVictory { get; set; }
        #endregion

        #region Advanced Game Options

        public bool EnableTurnTimer { get; set; }
        public SaveNumber TurnTimer { get; set; }

        public bool AllowPolicySaving { get; set; }
        public bool AllowPromotionSaving { get; set; }
        public bool CompleteKills { get; set; }
        public bool DisableStartBias { get; set; }
        public bool NewRandomSeed { get; set; }
        public bool NoAncientRuins { get; set; }
        public bool NoBarbarians { get; set; }
        public bool NoCityRazing { get; set; }
        public bool NoEspionage { get; set; }
        public bool OneCityChallenge { get; set; }
        public bool QuickCombat { get; set; }
        public bool QuickMovement { get; set; }
        public bool RagingBarbarians { get; set; }
        public bool RandomPersonalities { get; set; }
        public bool DynamicTurns { get; set; }
        public bool SimultaneousTurns { get; set; }
        public bool Pitboss { get; set; }
        public bool NoReligion { get; set; }
        public bool AlwaysWar { get; set; }
        public bool AlwaysPeace { get; set; }
        public bool NoChangingWarPeace { get; set; }
        public bool LockMods { get; set; }
        public bool NoScience { get; set; }
        public bool NoPolicies { get; set; }
        public bool NoHappiness { get; set; }
        public bool NoLeagues { get; set; }
        public bool NoCultureOverviewUI { get; set; }

        public IDictionary<string, bool> CustomSettings { get; private set; }
        #endregion

        #region Miscellaneous Properties
        //This effects the current year, production, and growth valus somehow
        //It may only be used in scenarios
        internal int TimeOffset { get; set; }

        internal bool GameStarted { get; set; }
        #endregion

        #region Overridable Methods
        internal virtual int GetCurrentTurnNumber()
        {
            return 0x00;
        }

        internal virtual byte[] GetCurrentEra()
        {
            return GameSaver.ConvertOptionEnumToSaveStr(HeaderStartingEra.Value).Bytes;
        }

        internal virtual byte[] GetPlayerColor()
        {
            return new byte[] { 0x00 };
        }

        internal virtual void WriteLeaders(SaveWriter output)
        {
            output.WriteEmptyBlocks(SaveHelpers.StandardSectionBlockCount);
        }

        internal virtual void WriteMinorCivs(SaveWriter output)
        {
            output.WriteEmptyBlocks(SaveHelpers.CityStateBlocks);
        }

        internal virtual int GetCurrentPlayerIndex()
        {
            return 0x00;
        }

        internal virtual void WriteCityStates(SaveWriter output)
        {
            output.WriteEmptyBlocks(SaveHelpers.CityStateBlocks);
        }

        internal virtual void WritePlayerColors(SaveWriter output)
        {
            output.WriteEmptyBlocks(SaveHelpers.StandardSectionBlockCount);
        }

        internal virtual byte[] GetRawGameData()
        {
            return new byte[0];
        }
        #endregion

        #region Static Methods

        internal static byte[] GetExpectedCrazyMapSizeBytes(GameConfig gameSave)
        {
            MapSize mapSize = gameSave.Map.Size.Value;
            bool GodsAndKings = gameSave.HasGnk;
            bool BraveNewWorld = gameSave.HasBnw;

            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                var crazyMapSizeBytes = CrazyMapSizeBytes[mapSize];

                writer.Write(crazyMapSizeBytes, 0, 44);

                if (GodsAndKings || BraveNewWorld)
                    writer.Write(crazyMapSizeBytes, 44, 4);

                writer.Write(crazyMapSizeBytes, 48, 20);

                if (BraveNewWorld)
                    writer.Write(crazyMapSizeBytes, 68, 8);
                else writer.Write(new byte[] { 0x0F, 0x00, 0x00, 0x00 });

                writer.Write(crazyMapSizeBytes, crazyMapSizeBytes.Length - 4, 4);

                return stream.ToArray();
            }
        }


        private static readonly IDictionary<MapSize, byte[]> CrazyMapSizeBytes = new Dictionary<MapSize, byte[]>()
        {
            {
                MapSizes.Duel,
                new byte[] { 0x02, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x0D, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00,
                             0x32, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                             0xCE, 0xFF, 0xFF, 0xFF, 0x28, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00,
                             0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x64, 0x00, 0x00, 0x00, 0x50, 0x00, 0x00, 0x00,
                             0x64, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }
            },
            {
                MapSizes.Tiny,
                new byte[] { 0x04, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x12, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00,
                             0x28, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                             0xE7, 0xFF, 0xFF, 0xFF, 0x38, 0x00, 0x00, 0x00, 0x24, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00,
                             0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x64, 0x00, 0x00, 0x00, 0x55, 0x00, 0x00, 0x00,
                             0x64, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 }
            },
            {
                MapSizes.Small,
                new byte[] { 0x06, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x17, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00,
                             0x1E, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x19, 0x00, 0x00, 0x00,
                             0x00, 0x00, 0x00, 0x00, 0x42, 0x00, 0x00, 0x00, 0x2A, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
                             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x64, 0x00, 0x00, 0x00, 0x5A, 0x00, 0x00, 0x00,
                             0x64, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00 }
            },
            {
                MapSizes.Standard,
                new byte[] { 0x08, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x1B, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
                             0x14, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x00,
                             0x19, 0x00, 0x00, 0x00, 0x50, 0x00, 0x00, 0x00, 0x34, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00,
                             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6E, 0x00, 0x00, 0x00, 0x64, 0x00, 0x00, 0x00,
                             0x64, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00 }
            },
            {
                MapSizes.Large,
                new byte[] { 0x0A, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x1E, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
                             0x0A, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x4B, 0x00, 0x00, 0x00,
                             0x32, 0x00, 0x00, 0x00, 0x68, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
                             0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x78, 0x00, 0x00, 0x00, 0x6E, 0x00, 0x00, 0x00,
                             0x50, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00 }
            },
            {
                MapSizes.Huge,
                new byte[] { 0x0C, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x23, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00,
                             0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x64, 0x00, 0x00, 0x00,
                             0x4B, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x50, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00,
                             0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x82, 0x00, 0x00, 0x00, 0x78, 0x00, 0x00, 0x00,
                             0x3C, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00 }
            },
        };
        #endregion
    }
}
