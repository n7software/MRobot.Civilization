using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV
{
    public class SaveNumber : IEquatable<SaveNumber>
    {
        public SaveNumber(int number, int minValue = 0, int maxValue = int.MaxValue)
        {
            _Value = number;
            MinValue = MinValue;
            MaxValue = maxValue;
        }

        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        private int _Value;

        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > MaxValue)
                    ValueTooBigException(value, MaxValue);
                else if (value < MinValue)
                    ValueTooSmallException(value, MinValue);
                else _Value = value;
            }
        }

        private static void ValueTooBigException(int value, int maxValue)
        {
            throw new InvalidValueException(String.Format("Given value {0} was greater than maximum value of {1}", value, maxValue));
        }

        private static void ValueTooSmallException(int value, int minValue)
        {
            throw new InvalidValueException(String.Format("Given value {0} was lesser than minimum value of {1}", value, minValue));
        }

        public static implicit operator SaveNumber(int number)
        {
            return new SaveNumber(number);
        }

        public static implicit operator int(SaveNumber number)
        {
            return number.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static bool operator ==(SaveNumber n1, SaveNumber n2)
        {
            return n1.Value == n2.Value;
        }

        public static bool operator !=(SaveNumber n1, SaveNumber n2)
        {
            return n1.Value != n2.Value;
        }

        private static void FindMinAndMax(SaveNumber n1, SaveNumber n2, int newVal, out int newMin, out int newMax)
        {
            newMin = Math.Max(n1.MinValue, n2.MinValue);
            newMax = Math.Min(n1.MaxValue, n2.MaxValue);
            if (newVal < newMin)
                ValueTooSmallException(newVal, newMin);
            if (newVal > newMax)
                ValueTooBigException(newVal, newMax);
        }

        public static SaveNumber operator +(SaveNumber n1, SaveNumber n2)
        {
            int newVal = n1.Value + n2.Value;
            int newMin, newMax;
            FindMinAndMax(n1, n2, newVal, out newMin, out newMax);
            return new SaveNumber(newVal, newMin, newMax);
        }

        public static SaveNumber operator -(SaveNumber n1, SaveNumber n2)
        {
            int newVal = n1.Value - n2.Value;
            int newMin, newMax;
            FindMinAndMax(n1, n2, newVal, out newMin, out newMax);
            return new SaveNumber(newVal, newMin, newMax);
        }

        public static SaveNumber operator *(SaveNumber n1, SaveNumber n2)
        {
            int newVal = n1.Value * n2.Value;
            int newMin, newMax;
            FindMinAndMax(n1, n2, newVal, out newMin, out newMax);
            return new SaveNumber(newVal, newMin, newMax);
        }

        public static SaveNumber operator /(SaveNumber n1, SaveNumber n2)
        {
            int newVal = n1.Value / n2.Value;
            int newMin, newMax;
            FindMinAndMax(n1, n2, newVal, out newMin, out newMax);
            return new SaveNumber(newVal, newMin, newMax);
        }

        public override bool Equals(object obj)
        {
            if (obj is SaveNumber)
                return Equals((SaveNumber)obj);
            else if (obj is int)
                return ((int)obj) == this.Value;
            else if (obj is int)
                return ((int)obj) == this.Value;
            else return false;
        }

        public bool Equals(SaveNumber other)
        {
            return this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

    }
}
