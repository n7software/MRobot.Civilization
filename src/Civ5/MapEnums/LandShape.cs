using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
{
    public enum LandShape
    {
        Natural,
        Pressed,
        Solid,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> LandShapeAsDict => Utils.GetEnumAsDict<LandShape>();
    }
}
