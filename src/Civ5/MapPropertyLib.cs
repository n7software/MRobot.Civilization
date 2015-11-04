using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.CivilizationV.Civ5
{
    static class MapPropertyLib
    {
        public static GameProperty<MapSize> MapSizeProp
        {
            get
            {
                return new GameProperty<MapSize>
                (
                    name: "Map Size",
                    defaultValue: MapSize.Small,
                    possibleValues: EnumDefinitions.MapSizeAsDict
                );
            }
        }
    }
}
