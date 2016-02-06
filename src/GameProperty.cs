using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization
{
    //Interface allows Map to return a set of immutable IMapProperties, 
    //since map properties should be changed via the Map object
    public interface IGamePropertyReadOnly<T>
    {
        string Name { get; }
        T Value { get; }
        IDictionary<T, string> PossibleValues { get; }
    }

    public interface IGameProperty<T> : IGamePropertyReadOnly<T>
    {
        new T Value { get; set; }
    }

    public interface IGameProperty : IGameProperty<object>
    { }

    public class GameProperty<T> : IGameProperty<T>
    {
        public GameProperty(string name, T defaultValue, IDictionary<T, string> possibleValues = null)
        {
            if (possibleValues == null)
                possibleValues = new SortedDictionary<T, string>();

            Name = name;
            _PossibleValues = new SortedDictionary<T, string>(possibleValues);
            Value = defaultValue;
        }

        public string Name { get; private set; }

        private T _Value;
        public T Value 
        {
            get { return _Value; }
            set
            {
                if (_PossibleValues.Count == 0 || _PossibleValues.ContainsKey(value))
                    _Value = value;
                else throw new InvalidValueException(String.Format("{0} is not a valid value for {1}", value, Name));
            }
        }

        private IDictionary<T, string> _PossibleValues;
        public IDictionary<T, string> PossibleValues
        {
            get { return new Dictionary<T, string>(_PossibleValues); }
        }
    }

    public class GameProperty : GameProperty<object>, IGameProperty
    {
        public GameProperty(string name, object defaultValue, IDictionary<object, string> possibleValues = null)
            : base(name, defaultValue, possibleValues)
        { }
    }
}
