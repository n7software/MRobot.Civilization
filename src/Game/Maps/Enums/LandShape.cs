using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum LandShape
    {
        Natural,
        Pressed,
        Solid,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> LandShapeAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(LandShape)); }
        }
    }
}
