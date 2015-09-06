using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum TeamSetting
    {
        StartTogether,
        StartSeparated,
        StartAnywhere
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> TeamSettingAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { TeamSetting.StartTogether,    "Start Together" },
                    { TeamSetting.StartSeparated,   "Start Separated" },
                    { TeamSetting.StartAnywhere,    "Start Anywhere" }
                };
            }
        }
    }
}
