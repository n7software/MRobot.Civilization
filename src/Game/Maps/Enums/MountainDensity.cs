using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
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
        public static IDictionary<object, string> MountainDensityAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(MountainDensity)); }
        }
    }
}
