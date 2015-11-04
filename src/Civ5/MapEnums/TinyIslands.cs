using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum TinyIslands
    {
        No,
        Few,
        Various,
        Many,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> TinyIslandsAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { TinyIslands.No,       "No Tiny Islands" },
                    { TinyIslands.Few,      "Few Tiny Islands" },
                    { TinyIslands.Various,  "Various Tiny Islands" },
                    { TinyIslands.Many,     "Many Tiny Islands" },
                    { TinyIslands.Random,   "Random" }
                };
            }
        }
    }
}
