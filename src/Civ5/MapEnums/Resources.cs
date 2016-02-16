using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> ResourcesAsDict => Utils.GetEnumAsDict<Resources>();
    }
}
