using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MRobot.Civilization
{
    static class Util
    {

        public static IDictionary<K, Func<V>> GetStaticGettersOfType<K, V>(Func<V, K> keySelector)
        {
            return GetStaticGettersOfType<K, V>(typeof(V), (val) => new K[] { keySelector(val) });
        }

        public static IDictionary<K, Func<V>> GetStaticGettersOfType<K, V>(Func<V, IEnumerable<K>> keysSelector)
        {
            return GetStaticGettersOfType<K, V>(typeof(V), keysSelector);
        }

        public static IDictionary<K, Func<V>> GetStaticGettersOfType<K, V>(Type classToSearch, Func<V, K> keySelector)
        {
            return GetStaticGettersOfType<K, V>(classToSearch, (val) => new K[] { keySelector(val) });
        }

        public static IDictionary<K, Func<V>> GetStaticGettersOfType<K, V>(Type classToSearch, Func<V, IEnumerable<K>> keysSelector)
        {
            var staticFields = classToSearch.GetFields();
            var staticProperties = classToSearch.GetProperties(BindingFlags.Static | BindingFlags.Public);
            var propertyInfo =
                from p in staticProperties
                where p.PropertyType == typeof(V)
                select p;
            var dict = new Dictionary<K, Func<V>>();
            foreach (var prop in propertyInfo)
            {
                V val = (V)prop.GetValue(null, null);
                var keys = keysSelector(val);
                foreach(var key in keys)
                    dict[key] = () => (V)prop.GetValue(null, null);
            }
            return dict;
        }

        public static IList<T> GetStaticFieldsOfType<T>()
        {
            return GetStaticFieldsOfType<T>(typeof(T));
        }

        public static IList<T> GetStaticFieldsOfType<T>(Type classToSearch)
        {
            var staticFields = classToSearch.GetFields();
            var staticProperties = classToSearch.GetProperties(BindingFlags.Static | BindingFlags.Public);
            var fieldInfo =
                from f in staticFields
                where f.FieldType == typeof(T)
                && f.IsStatic && f.IsPublic
                select f;
            IList<T> values = new List<T>();
            foreach (var field in fieldInfo)
                values.Add((T)field.GetValue(null));
            return values;
        }


    }
}
