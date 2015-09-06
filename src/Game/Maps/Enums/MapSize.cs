using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum MapSize
    {
        Duel = 2,
        Tiny = 4,
        Small = 6,
        Standard = 8,
        Large = 10,
        Huge = 12
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