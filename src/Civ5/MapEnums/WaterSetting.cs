using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum WaterSetting
    {
        Rivers,
        SmallLakes,
        Seas,
        RiversAndSeas,
        Dry,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> WaterSettingAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { WaterSetting.Rivers,        "Rivers" },
                    { WaterSetting.SmallLakes,    "Small Lakes" },
                    { WaterSetting.Seas,          "Seas" },
                    { WaterSetting.RiversAndSeas, "Rivers And Seas" },
                    { WaterSetting.Dry,           "Dry" },
                    { WaterSetting.Random,        "Random" },
                };
            }
        }
    }

}
