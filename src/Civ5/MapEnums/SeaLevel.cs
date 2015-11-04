using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum SeaLevel
    {
        Low,
        Medium,
        High,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> SeaLevelAsDict
        {
            get { return EnumDefinitions.GetEnumAsDict(typeof(SeaLevel)); }
        }
    }
}
