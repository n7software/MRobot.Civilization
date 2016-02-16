using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
{
    public enum Terrain
    {
        Grasslands,
        Plains,
        Forest,
        Jungle,
        Desert,
        Tundra,
        Hills,
        GlobalClimate,
        Random
    }

    partial class EnumDefinitions
    {
        public static IDictionary<object, string> TerrainAsDict => Utils.GetEnumAsDict<Terrain>();
    }
}
