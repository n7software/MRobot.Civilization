using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
{
    public enum MountainDensity
    {
        Dense,
        Normal,
        Thin,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> MountainDensityAsDict => Utils.GetEnumAsDict<MountainDensity>();
    }
}
