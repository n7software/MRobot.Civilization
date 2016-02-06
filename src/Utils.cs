using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MRobot.Civilization
{
    static class Utils
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

        public static IDictionary<object, string> GetEnumAsDict<T>()
        {
            return typeof(T)
                .GetEnumValues()
                .Cast<T>()
                .ToDictionary(
                    val => (object)val, 
                    val => val.ToString()
                              .SplitCamelCase()
                              .ConvertNumericWordsToNumbers());
        }

        private static Regex UpperUpperLowerRegex = new Regex(@"(\P{Ll})(\P{Ll}\p{Ll})");
        private static Regex LowerUpperRegex = new Regex(@"(\p{Ll})(\P{Ll})");
        private const string CamelSplitReplace = "$1 $2";

        public static string SplitCamelCase(this string camelCase)
        {
            return LowerUpperRegex.Replace(
                UpperUpperLowerRegex.Replace(camelCase, CamelSplitReplace),
                CamelSplitReplace);
        }


        private static Dictionary<string, string> NumericWordsToNumbers = new Dictionary<string, string>
        {
            ["one"]     = "1",
            ["two"]     = "2",
            ["three"]   = "3",
            ["four"]    = "4",
            ["five"]    = "5",
            ["six"]     = "6",
            ["seven"]   = "7",
            ["eight"]   = "8",
            ["nine"]    = "9",
            ["ten"]     = "10",
        };

        public static string ConvertNumericWordsToNumbers(this string input)
        {
            var words = input.Split();

            for (int i = 0; i < words.Length; i++)
            {
                var lower = words[i].ToLower();
                if (NumericWordsToNumbers.ContainsKey(lower))
                {
                    words[i] = NumericWordsToNumbers[lower];
                }
            }

            return string.Join(" ", words);
        }
    }
}
