using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> GetEnumAsDict(Type enumType)
        {
            var dict = new Dictionary<object, string>();
            foreach (var val in enumType.GetEnumValues())
                dict.Add(val, val.ToString());
            return dict;
        }
    }
}
