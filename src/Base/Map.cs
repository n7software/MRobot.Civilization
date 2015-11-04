using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Base
{
    public abstract class Map<MapSizeEnum> : IExpandable
    {
        internal Map(string name, GameProperty<MapSizeEnum> mapSize = null, IEnumerable<GameProperty> mapProperties = null, SaveString saveName = null, Expansion requirement = null, IDictionary<MapSizeEnum, SaveString> sizedMaps = null)
        {
            Name = name;
            Path = saveName;
            Requirement = requirement;
            if (mapProperties != null)
                _MapProperties = new List<GameProperty>(mapProperties);
            else _MapProperties = new List<GameProperty>();

            if (sizedMaps != null)
                SizedMaps = new Dictionary<MapSizeEnum, SaveString>(sizedMaps);

            this._Size = mapSize;
        }

        public string Name { get; private set; }

        public SaveString Path { get; private set; }

        public Expansion Requirement { get; private set; }

        protected GameProperty<MapSizeEnum> _Size;
        public IGamePropertyReadOnly<MapSizeEnum> Size { get { return _Size; } }

        private IDictionary<MapSizeEnum, SaveString> SizedMaps;

        private ICollection<GameProperty> _MapProperties;

        public IList<IGameProperty> MapProperties
        {
            get { return new List<IGameProperty>(_MapProperties); }
        }

        public virtual void SetMapSize(MapSizeEnum mapSize)
        {
            this._Size.Value = mapSize;
            AdjustMapPathBySize(mapSize);

        }

        protected void AdjustMapPathBySize(MapSizeEnum mapSize)
        {
            if (SizedMaps != null && SizedMaps.Count > 0)
                Path = SizedMaps[mapSize];
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
