using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum SeaLevel
    {
        Low,
        Medium,
        High,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> SeaLevelAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(SeaLevel)); }
        }
    }
}
