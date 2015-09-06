using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum Rainfall
    {
        Arid,
        Normal,
        Wet,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> RainfallAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(Rainfall)); }
        }
    }
}
