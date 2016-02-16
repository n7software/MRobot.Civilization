using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
{
    public enum LandType
    {
        Hills,
        Mountains,
        Ocean,
        Desert,
        Standard,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> LandTypeAsDict => Utils.GetEnumAsDict<LandType>();
    }
}
