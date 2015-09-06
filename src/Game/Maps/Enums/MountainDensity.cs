using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
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
