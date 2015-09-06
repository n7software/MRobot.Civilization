using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum Rainfall
    {
        Arid,
        Normal,
        Wet,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> RainfallAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(Rainfall)); }
        }
    }
}
