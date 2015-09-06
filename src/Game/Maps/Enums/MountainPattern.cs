using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
{
    public enum MountainPattern
    {
        Ridgelines,
        Scattered,
        Ranges,
        Clusters,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> MountainPatternAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(MountainPattern)); }
        }
    }
}
