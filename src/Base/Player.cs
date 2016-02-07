using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRobot.Civilization.Civ5;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Base
{
    public abstract class Player
    {
        const string DifficultyPropertyName = "Difficulty";

        protected Player(IDictionary<int, string> possibleDifficulties, int defaultDifficulty)
        {
            Name = string.Empty;
            Password = string.Empty;
            Type = PlayerType.None;

            Difficulty = new GameProperty<int>(DifficultyPropertyName, defaultDifficulty, possibleDifficulties);
        }

        public ICivilization Civilization { get; set; }

        public SaveString Name { get; set; }

        public IGameProperty<int> Difficulty { get; private set; }

        private PlayerType _type;

        public PlayerType Type 
        {
            get { return _type; }
            set
            {
                _type = value;
                if (_type == PlayerType.Human)
                {
                    Difficulty = new GameProperty<PlayerDifficulty>(
                        DifficultyPropertyName,
                        PlayerDifficulty.Prince,
                        DifficultyNames);
                }
                else if (_type == PlayerType.AI)
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
