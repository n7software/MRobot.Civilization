using System;
using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
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
