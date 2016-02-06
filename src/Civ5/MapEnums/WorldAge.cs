using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> WorldAgeAsDict => Utils.GetEnumAsDict<WorldAge>();
    }
}
