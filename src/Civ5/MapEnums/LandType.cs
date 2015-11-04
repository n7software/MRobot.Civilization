using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum LandType
    {
        Hills,
        Mountains,
        Ocean,
        Desert,
        Standard,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> LandTypeAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(LandType)); }
        }
    }
}
