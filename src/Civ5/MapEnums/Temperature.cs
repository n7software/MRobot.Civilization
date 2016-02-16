using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> TemperatureAsDict => Utils.GetEnumAsDict<Temperature>();
    }
}
