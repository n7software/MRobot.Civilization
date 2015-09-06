using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
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
        public static IDictionary<object, string> LandTypeAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(LandType)); }
        }
    }
}
