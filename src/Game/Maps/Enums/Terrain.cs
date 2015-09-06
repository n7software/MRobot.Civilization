using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
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
        public static IDictionary<object, string> TerrainAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { Terrain.Grasslands,    "Grasslands" },
                    { Terrain.Plains,        "Plains" },
                    { Terrain.Forest,        "Forest" },
                    { Terrain.Jungle,        "Jungle" },
                    { Terrain.Desert,        "Desert" },
                    { Terrain.Tundra,        "Tundra" },
                    { Terrain.Hills,         "Hills" },
                    { Terrain.GlobalClimate, "Global Climate" },
                    { Terrain.Random,        "Random" }
                };
            }
        }
    }
}
