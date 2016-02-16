using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Civ5
{
    public class Player : Base.Player
    {
        public Player()
            : base(PlayerDifficulties.All, PlayerDifficulties.DefaultDifficulty)
        { }

        public static Player AiPlayer
        {
            get { return new Player { Type = PlayerType.AI }; }
        }

        public static Player ClosedSlot
        {
            get { return new Player { Type = PlayerType.None }; }
        }

        public static Player CityState
        {
            get { return new Player { Type = PlayerType.Unknown }; }
        }

        public static Player Barbarian
        {
            get { return new Player { Type = PlayerType.Unknown, Civilization = Civilizations.Unknown }; }
        }

        protected override void OnPlayerTypeChanged()
        {
            PlayerDifficulty difficulty = null;

            switch (Type)
            {
                case PlayerType.Human:
                    difficulty = PlayerDifficulties.Prince;
                    break;  

                case PlayerType.AI:
                    difficulty = PlayerDifficulties.AI;
                    break;

                default:
                    difficulty = PlayerDifficulties.Chieftain;
                    break;
            }

            Difficulty = new GameProperty<PlayerDifficulty>(
                DifficultyPropertyName,
                difficulty,
                PlayerDifficulties.AllInNamesDictionary());
        }
    }
}
