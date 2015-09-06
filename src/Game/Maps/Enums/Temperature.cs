using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum Temperature
    {
        Cool,
        Temperate,
        Hot,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> TemperatureAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(Temperature)); }
        }
    }
}
