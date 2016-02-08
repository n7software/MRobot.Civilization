using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MRobot.Civilization.Civ5;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Base
{
    public abstract class Player
    {
        public const string DifficultyPropertyName = "Difficulty";

        protected Player(IEnumerable<PlayerDifficulty> possibleDifficulties, PlayerDifficulty defaultDifficulty)
        {
            Name = string.Empty;
            Password = string.Empty;
            Type = PlayerType.None;

            Difficulty = new GameProperty<PlayerDifficulty>(DifficultyPropertyName, defaultDifficulty, possibleDifficulties.ToDictionary(pd => pd, pd => pd.Name));
        }

        public ICivilization Civilization { get; set; }

        public SaveString Name { get; set; }

        public IGameProperty<PlayerDifficulty> Difficulty { get; protected set; }

        private PlayerType _type;

        public PlayerType Type 
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPlayerTypeChanged();
            }
        }

        public int? Team { get; set; }

        public SaveString Password { get; set; }


        protected virtual void OnPlayerTypeChanged()
        {
        }
    }
}
