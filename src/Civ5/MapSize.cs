using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Civ5
{
    public class MapSize : Base.MapSize
    {
        private MapSize(string name, int players)
            : base(name, players)
        { }

        public static readonly MapSize Duel = new MapSize("Duel", 2);
        public static readonly MapSize Tiny = new MapSize("Tiny", 4);
        public static readonly MapSize Small = new MapSize("Small", 6);
        public static readonly MapSize Standard = new MapSize("Standard", 8);
        public static readonly MapSize Large = new MapSize("Large", 10);
        public static readonly MapSize Huge = new MapSize("Huge", 12);
    }

    partial class EnumDefinitions
    {
        public static IDictionary<MapSize, string> MapSizeAsDict
        {
            get 
            {
                var dict = new Dictionary<MapSize, string>();
                foreach (MapSize val in typeof(MapSize).GetEnumValues())
                    dict.Add(val, val.ToString());
                return dict;
            }
        }
    }
}