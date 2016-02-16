using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> OceanAsDict => Utils.GetEnumAsDict<Ocean>();
    }
}
