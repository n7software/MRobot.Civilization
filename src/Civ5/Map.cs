using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.CivilizationV.Civ5
{
    public class Map : Base.Map<MapSize>
    {
        public Map(string name, GameProperty<MapSize> mapSize = null, IEnumerable<GameProperty> mapProperties = null, SaveString saveName = null, Expansion requirement = null, IDictionary<MapSize, SaveString> sizedMaps = null)
            : base(name, mapSize, mapProperties, saveName, requirement, sizedMaps)
        {
            if (mapSize == null)
                mapSize = MapPropertyLib.MapSizeProp;

            NumberOfCityStates = new SaveNumber(12, 0, MaxCityStates);
            AdjustMapPathBySize(mapSize.Value);
            AdjustCityStatesBySize(mapSize.Value);

        }

        const int MaxCityStates = 58;

        public SaveNumber NumberOfCityStates { get; internal set; }

        public override void SetMapSize(MapSize mapSize)
        {
            base.SetMapSize(mapSize);
            AdjustCityStatesBySize(mapSize);
        }

        private void AdjustCityStatesBySize(MapSize mapSize)
        {
            NumberOfCityStates.Value = mapSize.Players * 2;
        }
    }
}
