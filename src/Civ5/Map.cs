using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MRobot.Civilization.Base;

namespace MRobot.Civilization.Civ5
{
    public class Map : Base.Map
    {
        public Map(string name, GameProperty<MapSize> mapSize = null, IEnumerable<GameProperty> mapProperties = null, SaveString saveName = null, Expansion requirement = null, IDictionary<MapSize, SaveString> sizedMaps = null)
            : base(name, GameSteamIds.CivV, mapSize, mapProperties, saveName, requirement, sizedMaps)
        {
            if (mapSize == null)
                mapSize = Data.MapProperties.MapSizeProp;

            NumberOfCityStates = new SaveNumber(12, 0, MaxCityStates);
            AdjustMapPathBySize(mapSize.Value);
            AdjustCityStatesBySize(mapSize.Value);

        }

        const int MaxCityStates = 58;

        public override SaveNumber NumberOfCityStates { get; internal set; }

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
