using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.Civilization.Base
{
    public class MapSize
    {
        public string Name { get; private set; }

        public int Players { get; private set; }

        public MapSize(string name, int players)
        {
            Name = name;
            Players = players;
        }
    }
}
