using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Civ5.MapEnums
{
    static partial class EnumDefinitions
    {
        public static IDictionary<MapSize, string> MapSizeAsDict => MapSizes.All.ToDictionary(m => m, m => m.Name);
    }
}
