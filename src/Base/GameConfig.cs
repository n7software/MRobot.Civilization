using MRobot.CivilizationV.Game;
using MRobot.CivilizationV.Game.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Base
{
    public partial class GameConfig
    {
        const string CurrentVersion = "1.0.3.144 (395131)";
        const string CurrentBuild = "395131";

        protected GameConfig()
        {
            Version = CurrentVersion;
            Build = CurrentBuild;

            RandomSeed = new Random().Next(int.MinValue, int.MaxValue);

            Name = "My Game";
            GameMode = GameMode.HotSeat;

            _Expansions = new HashSet<Expansion>();

            Mods = new HashSet<Mod>();

            GamePace = CreateGamePaceProperty(Game.GamePace.Quick);
            HeaderStartingEra = GameEraProps.Vanilla;
            StartingEra = GameEraProps.Vanilla;

            DominationVictory = true;

            //EnableMaxTurns = false;
            //MaxTurns = new SaveNumber(100, 1, 999);
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

        protected static IGameProperty<GamePace> CreateGamePaceProperty(GamePace defaultPace)
        {
            return new GameProperty<GamePace>("Game Pace", defaultPace, GamePaceDict.GamePaceAsDict);
        }

        public SaveString Name { get; set; }
        public GameMode GameMode { get; set; }

        public SaveString Version { get; protected set; }
        public SaveString Build { get; protected set; }

        public int RandomSeed { get; protected set; }

        protected readonly ISet<Expansion> _Expansions;

        /// <summary>
        /// Note that all games have the Upgrade 1 expansion
        /// </summary>
        public IEnumerable<Expansion> Expansions
        {
            get { return _Expansions.ToArray(); }
        }

        /// <summary>
        /// Note that adding all expansions to a map will automatically add the Civilization V Compete expansion
        /// </summary>
        public void AddExpansion(Expansion expansion)
        {
            if (expansion != Expansion.CivilizationVComplete)
            {
                _Expansions.Add(expansion);
                if (expansion == Expansion.GodsAndKings || expansion == Expansion.BraveNewWorld)
                {
                    SetPropertiesForExpansions();
                }
                if (_Expansions.IsSupersetOf(Expansion.All))
                    _Expansions.Add(Expansion.CivilizationVComplete);
            }
        }

        protected virtual void SetPropertiesForExpansions()
        {
            HeaderStartingEra = GameEraProps.Expansions;
            StartingEra = GameEraProps.Expansions;
        }

        public void RemoveExpansion(Expansion expansion)
        {
            if (expansion != Expansion.CivilizationVComplete && expansion != Expansion.Upgrade1 && expansion != Expansion.Mongolia)
            {
                _Expansions.Remove(expansion);
                if (!this.HasGnkOrBnw)
                {
                    SetPropertiesForVanilla();
                }
                if (!_Expansions.IsSupersetOf(Expansion.All))
                    _Expansions.Remove(Expansion.CivilizationVComplete);
            }
        }

        protected virtual void SetPropertiesForVanilla()
        {
            HeaderStartingEra = GameEraProps.Vanilla;
            StartingEra = GameEraProps.Vanilla;
        }

        public ISet<Mod> Mods { get; private set; }

        public bool HasGnkOrBnw
        {
            get { return _Expansions.Contains(Expansion.GodsAndKings) || _Expansions.Contains(Expansion.BraveNewWorld); }
        }

        public bool HasDlcCiv
        {
            get
            {
                return _Expansions.Any(e =>
                    e == Expansion.Babylon ||
                    e == Expansion.Denmark ||
                    e == Expansion.Korea ||
                    e == Expansion.Polynesia ||
                    e == Expansion.SpainAndInca);
            }
        }

        
        public PlayerDifficulty? HeaderDifficulty { get; protected set; }

        #region Basic Options

        public IGameProperty<GamePace> GamePace { get; private set; }
        public IGameProperty<GameEra> HeaderStartingEra { get; private set; }
        public IGameProperty<GameEra> StartingEra { get; private set; }
        #endregion

        #region Victory Types
        public bool DominationVictory { get; set; }
        #endregion

        #region Advanced Game Options
        //Doesn't work, even in officially created game config files
        //public bool EnableMaxTurns { get { return false; } }
        //public SaveNumber MaxTurns { get; private set; }

        public bool EnableTurnTimer { get; set; }
        public SaveNumber TurnTimer { get; protected set; }

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
    }
}
