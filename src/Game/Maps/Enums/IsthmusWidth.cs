using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum IsthmusWidth
    {
        TwoPlotsWide = 2,
        ThreePlotsWide = 3,
        FourPlotsWide = 4,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> IsthmusWidthAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { IsthmusWidth.TwoPlotsWide,    "2 Plots Wide" },
                    { IsthmusWidth.ThreePlotsWide,  "3 Plots Wide" },
                    { IsthmusWidth.FourPlotsWide,   "4 Plots Wide" },
                    { IsthmusWidth.Random,          "Random" }
                };
            }
        }
    }
}
