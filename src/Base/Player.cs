using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Base
{
    public abstract class Player
    {
        const string DifficultyPropertyName = "Difficulty";

        protected Player(IDictionary<PlayerDifficulty, string> difficultyNames)
        {
            Name = String.Empty;
            Difficulty = new GameProperty<PlayerDifficulty>(DifficultyPropertyName, PlayerDifficulty.Chieftain);
            DifficultyNames = difficultyNames;
            Password = String.Empty;
            Type = PlayerType.None;
        }

        private IDictionary<PlayerDifficulty, string> DifficultyNames;

        public SaveString Name { get; set; }

        public IGameProperty<PlayerDifficulty> Difficulty { get; private set; }

        private PlayerType _Type;

        public PlayerType Type 
        {
            get { return _Type; }
            set
            {
                _Type = value;
                if (_Type == PlayerType.Human)
                {
                    Difficulty = new GameProperty<PlayerDifficulty>(
                        DifficultyPropertyName,
                        PlayerDifficulty.Prince,
                        DifficultyNames);
                }
                else if (_Type == PlayerType.AI)
                {
                    Difficulty = new GameProperty<PlayerDifficulty>(
                        DifficultyPropertyName,
                        PlayerDifficulty.AI);
                }
                else
                {
                    Difficulty = new GameProperty<PlayerDifficulty>(
                        DifficultyPropertyName,
                        PlayerDifficulty.Chieftain);
                }
            }
        }

        public int? Team { get; set; }

        public SaveString Password { get; set; }

    }
}
