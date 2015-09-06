using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
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
        public static IDictionary<object, string> LandShapeAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(LandShape)); }
        }
    }
}
