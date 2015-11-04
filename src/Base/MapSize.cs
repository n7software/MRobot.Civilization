using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.CivilizationV.Base
{
    public abstract class MapSize
    {
        public string Name { get; private set; }

        public int Players { get; private set; }

        protected MapSize(string name, int players)
        {
            Name = name;
            Players = players;
        }
    }
}
