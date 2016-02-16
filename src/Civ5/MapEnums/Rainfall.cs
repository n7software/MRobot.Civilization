using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> RainfallAsDict => Utils.GetEnumAsDict<Rainfall>();
    }
}
