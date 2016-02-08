using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization.Base
{
    public class PlayerDifficulty
    {
        public PlayerDifficulty(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public int Value { get; }

        public SaveString SaveString => new SaveString("HANDICAP", Name);
    }
}
