using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> SeaLevelAsDict => Utils.GetEnumAsDict<SeaLevel>();
    }
}
