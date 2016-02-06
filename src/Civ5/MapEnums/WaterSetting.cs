using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> WaterSettingAsDict => Utils.GetEnumAsDict<WaterSetting>();
    }

}
