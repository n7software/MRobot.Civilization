using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public partial class Map : IExpandable
    {
        const int MaxCityStates = 58;

        internal Map(string name, GameProperty<MapSize> mapSize = null, IEnumerable<GameProperty> mapProperties = null, SaveString saveName = null, Expansion requirement = null, IDictionary<MapSize, SaveString> sizedMaps = null)
        {
            Name = name;
            Path = saveName;
            Requirement = requirement;
            if (mapProperties != null)
                _MapProperties = new List<GameProperty>(mapProperties);
            else _MapProperties = new List<GameProperty>();

            if (mapSize == null)
                mapSize = MapPropertyLib.MapSizeProp;

            if (sizedMaps != null)
                SizedMaps = new Dictionary<MapSize, SaveString>(sizedMaps);

            NumberOfCityStates = new SaveNumber(12, 0, MaxCityStates);
            this._Size = mapSize;
            AdjustMapSizeSideEffects(mapSize.Value);
        }

        public string Name { get; private set; }

        public SaveString Path { get; private set; }

        public Expansion Requirement { get; private set; }

        private GameProperty<MapSize> _Size;
        public IGamePropertyReadOnly<MapSize> Size { get { return _Size; } }
        public SaveNumber NumberOfCityStates { get; internal set; }

        private IDictionary<MapSize, SaveString> SizedMaps;

        private ICollection<GameProperty> _MapProperties;

        public IList<IGameProperty> MapProperties
        {
            get { return new List<IGameProperty>(_MapProperties); }
        }

        public void SetMapSize(MapSize mapSize)
        {
            this._Size.Value = mapSize;
            AdjustMapSizeSideEffects(mapSize);
        }

        private void AdjustMapSizeSideEffects(MapSize mapSize)
        {
            AdjustMapPathBySize(mapSize);
            AdjustCityStatesBySize(mapSize);
        }

        private void AdjustMapPathBySize(MapSize mapSize)
        {
            if (SizedMaps != null && SizedMaps.Count > 0)
                Path = SizedMaps[mapSize];
        }

        private void AdjustCityStatesBySize(MapSize mapSize)
        {
            NumberOfCityStates.Value = ((int)mapSize) * 2;
        }

        internal IEnumerable<SaveString> AllPossiblePaths
        {
            get
            {
                var paths = new List<SaveString>();
                if (!String.IsNullOrEmpty(Path))
                    paths.Add(Path);
                if(SizedMaps != null)
                    paths.AddRange(SizedMaps.Values);
                return paths;
            }
        }
    }
}
