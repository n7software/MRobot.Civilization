using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
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
