using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum Temperature
    {
        Cool,
        Temperate,
        Hot,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> TemperatureAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(Temperature)); }
        }
    }
}
