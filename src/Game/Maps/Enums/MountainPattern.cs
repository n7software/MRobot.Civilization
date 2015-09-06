using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
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
