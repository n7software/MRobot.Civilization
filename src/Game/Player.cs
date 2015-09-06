using MRobot.CivilizationV.Civs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game
{
    public class Player
    {
        public static Player AiPlayer
        {
            get { return new Player { Type = PlayerType.AI, Difficulty = PlayerDifficulty.Ai_default }; }
        }

        public static Player ClosedSlot
        {
            get { return new Player { Type = PlayerType.None, Difficulty = PlayerDifficulty.Chieftain }; }
        }

        public static Player CityState
        {
            get { return new Player { Type = PlayerType.Unknown, Difficulty = PlayerDifficulty.Chieftain }; }
        }

        public static Player Barbarian
        {
            get { return new Player { Type = PlayerType.Unknown, Difficulty = PlayerDifficulty.Chieftain, Civilization = Civs.Civilization.Unknown }; }
        }

        internal Player()
        {
            Name = String.Empty;
            Password = String.Empty;
            Difficulty = PlayerDifficulty.Ai_default;
            Type = PlayerType.AI;
        }

        public SaveString Name { get; set; }
        private PlayerDifficulty _Difficulty;

        public PlayerDifficulty Difficulty
        {
            get 
            {
                if (Type == PlayerType.Human)
                    return _Difficulty;
                else if (Type == PlayerType.AI)
                    return PlayerDifficulty.Ai_default;
                else return PlayerDifficulty.Chieftain;
            }
            set { _Difficulty = value; }
        }

        public PlayerType Type { get; set; }
        public int? Team { get; set; }
        public ICivilization Civilization { get; set; }

        public SaveString Password { get; set; }

    }
}
