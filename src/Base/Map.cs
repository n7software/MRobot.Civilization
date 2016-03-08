using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization.Base
{
    public class Map: IExpandable
    {
        internal Map(string name, int steamGameId, GameProperty<MapSize> mapSize = null, IEnumerable<GameProperty> mapProperties = null, SaveString saveName = null, Expansion requirement = null, IDictionary<MapSize, SaveString> sizedMaps = null)
        {
            Name = name;
            SteamGameId = steamGameId;
            Path = saveName;
            Requirement = requirement;
            _MapProperties = new List<GameProperty>(mapProperties ?? new GameProperty[0]);

            if (sizedMaps != null)
                SizedMaps = new Dictionary<MapSize, SaveString>(sizedMaps);

            this._Size = mapSize;
        }

        public int SteamGameId { get; }

        public string Name { get; private set; }

        public SaveString Path { get; private set; }

        public Expansion Requirement { get; private set; }

        public virtual SaveNumber NumberOfCityStates
        {
            get { return new SaveNumber(0); }
            internal set { }
        }

        protected GameProperty<MapSize> _Size;

        public IGamePropertyReadOnly<MapSize> Size { get { return _Size; } }

        private IDictionary<MapSize, SaveString> SizedMaps;

        private ICollection<GameProperty> _MapProperties;

        public IList<IGameProperty> MapProperties
        {
            get { return new List<IGameProperty>(_MapProperties); }
        }

        public virtual void SetMapSize(MapSize mapSize)
        {
            _Size.Value = mapSize;
            AdjustMapPathBySize(mapSize);
        }

        protected void AdjustMapPathBySize(MapSize mapSize)
        {
            if (SizedMaps != null && SizedMaps.Count > 0)
                Path = SizedMaps[mapSize];
        }
        
        internal IEnumerable<SaveString> AllPossiblePaths
        {
            get
            {
                var paths = new List<SaveString>();
                if (!string.IsNullOrEmpty(Path))
                    paths.Add(Path);
                if(SizedMaps != null)
                    paths.AddRange(SizedMaps.Values);
                return paths;
            }
        }
    }
}
