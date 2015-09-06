using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum WorldAge
    {
        ThreeBillionYears,
        FourBillionYears,
        FiveBillionYears,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> WorldAgeAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { WorldAge.ThreeBillionYears,   "3 Billion Years" },
                    { WorldAge.FourBillionYears,    "4 Billion Years" },
                    { WorldAge.FiveBillionYears,    "5 Billion Years" },
                    { WorldAge.Random,              "Random" },
                };
            }
        }
    }
}
