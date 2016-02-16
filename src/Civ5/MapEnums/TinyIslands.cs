using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
{
    public enum TinyIslands
    {
        No,
        Few,
        Various,
        Many,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> TinyIslandsAsDict => Utils.GetEnumAsDict<TinyIslands>();
    }
}
