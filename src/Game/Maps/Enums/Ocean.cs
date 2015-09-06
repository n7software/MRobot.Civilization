using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum Ocean
    {
        Random,
        Large,
        Medium,
        Small
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> OceanAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(Ocean)); }
        }
    }
}
