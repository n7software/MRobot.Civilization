using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
{
    public enum TeamSetting
    {
        StartTogether,
        StartSeparated,
        StartAnywhere
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> TeamSettingAsDict => Utils.GetEnumAsDict<TeamSetting>();
    }
}
