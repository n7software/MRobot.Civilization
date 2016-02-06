using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> IsthmusWidthAsDict => Utils.GetEnumAsDict<IsthmusWidth>();
    }
}
