using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRobot.Civilization.Base;

namespace MRobot.Civilization.Civ5
{
    public static class MapSizes
    {
        public static readonly MapSize Duel = new MapSize("Duel", 2);
        public static readonly MapSize Tiny = new MapSize("Tiny", 4);
        public static readonly MapSize Small = new MapSize("Small", 6);
        public static readonly MapSize Standard = new MapSize("Standard", 8);
        public static readonly MapSize Large = new MapSize("Large", 10);
        public static readonly MapSize Huge = new MapSize("Huge", 12);

        public static readonly IEnumerable<MapSize> All = new List<MapSize>
        {
            Duel,
            Tiny,
            Small,
            Standard,
            Large,
            Huge
        };

        public static readonly IDictionary<int, MapSize> AllByPlayerCount
            = All.ToDictionary(m => m.Players, m => m);
    }
}