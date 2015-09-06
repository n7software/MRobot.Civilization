using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
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
