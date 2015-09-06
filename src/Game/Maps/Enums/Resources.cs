using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum Resources
    {
        Sparse,
        Standard,
        Abundant,
        LegendaryStart,
        StrategicBalance,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> ResourcesAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { Resources.Sparse,             "Sparse" },
                    { Resources.Standard,           "Standard" },
                    { Resources.Abundant,           "Abundant" },
                    { Resources.LegendaryStart,     "Legendary Start" },
                    { Resources.StrategicBalance,   "Strategic Balance" },
                    { Resources.Random,             "Random" },
                };
            }
        }
    }
}
