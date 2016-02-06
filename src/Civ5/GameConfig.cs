﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Game;

namespace MRobot.Civilization.Civ5
{
    public class GameConfig : Base.GameConfig
    {
        public GameConfig()
        {
            Map = DefaultMaps.Continents;

            Players = new Player[SaveHelpers.StandardSectionBlockCount];
            for (int i = 0; i < SaveHelpers.MaxPlayers; i++)
                Players[i] = Player.ClosedSlot;
            for (int i = SaveHelpers.MaxPlayers; i < SaveHelpers.StandardSectionBlockCount - 1; i++)
                Players[i] = Player.CityState;
            Players[Players.Length - 1] = Player.Barbarian;

            _Expansions.Add(ExpansionLib.Mongolia);
            _Expansions.Add(ExpansionLib.Upgrade1);

            CulturalVictory = true;
            DiplomaticVictory = true;
            TimeVictory = true;
            ScienceVictory = true;

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

        public Map Map { get; set; }

        public Player[] Players { get; protected set; }
        public ICivilization HeaderCiv { get; protected set; }

        public int PlayerCount => Players.Take(63).Count(p => p.Type == PlayerType.Human || p.Type == PlayerType.AI);

        public bool CulturalVictory { get; set; }
        public bool DiplomaticVictory { get; set; }
        public bool TimeVictory { get; set; }
        public bool ScienceVictory { get; set; }

        /// <summary>
        /// Note that all games have the Upgrade 1 expansion
        /// </summary>
        public IEnumerable<Expansion> Expansions => _Expansions.ToArray();

        /// <summary>
        /// Note that adding all expansions to a map will automatically add the Civilization V Compete expansion
        /// </summary>
        public void AddExpansion(Expansion expansion)
        {
            if (expansion != ExpansionLib.CivilizationVComplete)
            {
                _Expansions.Add(expansion);
                if (expansion == ExpansionLib.GodsAndKings || expansion == ExpansionLib.BraveNewWorld)
                {
                    SetPropertiesForExpansions();
                }
                if (_Expansions.IsSupersetOf(ExpansionLib.All))
                    _Expansions.Add(ExpansionLib.CivilizationVComplete);
            }
        }

        protected virtual void SetPropertiesForExpansions()
        {
            HeaderStartingEra = GameEraProps.Expansions;
            StartingEra = GameEraProps.Expansions;
        }

        public void RemoveExpansion(Expansion expansion)
        {
            if (expansion != ExpansionLib.CivilizationVComplete && expansion != ExpansionLib.Upgrade1 && expansion != ExpansionLib.Mongolia)
            {
                _Expansions.Remove(expansion);
                if (!this.HasGnkOrBnw)
                {
                    SetPropertiesForVanilla();
                }
                if (!_Expansions.IsSupersetOf(ExpansionLib.All))
                    _Expansions.Remove(ExpansionLib.CivilizationVComplete);
            }
        }

        protected virtual void SetPropertiesForVanilla()
        {
            HeaderStartingEra = GameEraProps.Vanilla;
            StartingEra = GameEraProps.Vanilla;
        }

        public bool HasGnkOrBnw => _Expansions.Contains(ExpansionLib.GodsAndKings) || _Expansions.Contains(ExpansionLib.BraveNewWorld);

        public bool HasDlcCiv
        {
            get
            {
                return _Expansions.Any(e =>
                    e == ExpansionLib.Babylon ||
                    e == ExpansionLib.Denmark ||
                    e == ExpansionLib.Korea ||
                    e == ExpansionLib.Polynesia ||
                    e == ExpansionLib.SpainAndInca);
            }
        }


        public PlayerDifficulty? HeaderDifficulty { get; protected set; }

        #region Basic Options
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

        protected override string CurrentVersion()
        {
            return "1.0.3.144 (395131)";
        }

        protected override string CurrentBuild()
        {
            return "395131";
        }
    }
}
