using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.CivilizationV.Civ5
{
    public class GameConfig : Base.GameConfig
    {
        public GameConfig()
        {
            Map = Map.Continents;

            Players = new Player[SaveHelpers.StandardSectionBlockCount];
            for (int i = 0; i < SaveHelpers.MaxPlayers; i++)
                Players[i] = Player.ClosedSlot;
            for (int i = SaveHelpers.MaxPlayers; i < SaveHelpers.StandardSectionBlockCount - 1; i++)
                Players[i] = Player.CityState;
            Players[Players.Length - 1] = Player.Barbarian;

            _Expansions.Add(Expansion.Mongolia);
            _Expansions.Add(Expansion.Upgrade1);

            CulturalVictory = true;
            DiplomaticVictory = true;
            TimeVictory = true;
            ScienceVictory = true;
        }

        public Map Map { get; set; }

        public Player[] Players { get; protected set; }
        public ICivilization HeaderCiv { get; protected set; }

        public int PlayerCount
        {
            get
            { return Players.Take(63).Count(p => p.Type == PlayerType.Human || p.Type == PlayerType.AI); }
        }



        public bool CulturalVictory { get; set; }
        public bool DiplomaticVictory { get; set; }
        public bool TimeVictory { get; set; }
        public bool ScienceVictory { get; set; }

    }
}
