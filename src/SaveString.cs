using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV
{
    public class SaveString : IEquatable<SaveString>
    {
        public SaveString()
        {
            Prefix = String.Empty;
            Value = String.Empty;
            AllCaps = false;
        }

        public SaveString(string value, bool allCaps = false)
        {
            Prefix = String.Empty;
            Value = value;
            AllCaps = allCaps;
        }

        public SaveString(string prefix, string value, bool allCaps = true)
        {
            Prefix = prefix;
            Value = value;
            AllCaps = allCaps;
        }

        private string _Prefix;
        public string Prefix
        {
            get { return _Prefix; }
            set
            {
                if (value.Length + (Value != null ? Value.Length : 0) + 1 > int.MaxValue)
                    throw new StringTooLongException();
                else
                {
                    FilterNonASCII(value);
                    _Prefix = value;
                }
            }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set
            {
                if ((Prefix != null ? Prefix.Length : 0) + value.Length + 1 > int.MaxValue)
                    throw new StringTooLongException();
                else
                {
                    FilterNonASCII(value);
                    _Value = value;
                }
            }
        }

        private static void FilterNonASCII(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (c < byte.MinValue || c > byte.MaxValue)
                    c = '?';
            }
        }

        public byte[] Bytes
        {
            get
            {
                string str = this.ToString();
                int length = ContainsUnicode(str) ? str.Length * 2 + 1 :str.Length;

                byte[] data = new byte[length + 4];

                //Use a MemoryStream/BinaryWriter to resolve ASCII vs. Unicode issues
                using(var memStream = new MemoryStream(data))
                using(var memWriter = new BinaryWriter(memStream))
                {
                    memWriter.Write(length);
                    memWriter.Write(str.ToCharArray());
                }

                return data;
            }
        }

        private bool ContainsUnicode(string str)
        {
            return str.Any(c => c > 255);
        }

        public bool AllCaps { get; set; }

        public static implicit operator SaveString(string str)
        {
            return new SaveString(str);
        }

        public static implicit operator string(SaveString str)
        {
            return str.ToString();
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Value))
                return String.Empty;

            string prefix = String.IsNullOrEmpty(Prefix) ? String.Empty : Prefix + "_";
            var str = prefix + Value;
            if (AllCaps)
                str = str.ToUpper();
            return str;
        }

        public static bool operator ==(SaveString s1, SaveString s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(SaveString s1, SaveString s2)
        {
            return !s1.Equals(s2);
        }

        public override bool Equals(object obj)
        {
            var saveStr = obj as SaveString;
            var str = obj as String;
            if(saveStr != null)
                return Equals(saveStr);
            else if (str != null)
                return str == this.ToString();
            else return false;
        }

        public bool Equals(SaveString other)
        {
            return this.ToString() == other.ToString();

        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }

    public class StringTooLongException : Exception
    {
        public StringTooLongException()
            : base("Save String cannot exceed " + int.MaxValue + " characters")
        { }
    }
}
