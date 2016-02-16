using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> MountainPatternAsDict => Utils.GetEnumAsDict<MountainPattern>();
    }
}
