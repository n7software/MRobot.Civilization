using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
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
