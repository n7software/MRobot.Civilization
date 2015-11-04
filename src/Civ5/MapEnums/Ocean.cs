using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum Ocean
    {
        Random,
        Large,
        Medium,
        Small
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> OceanAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(Ocean)); }
        }
    }
}
