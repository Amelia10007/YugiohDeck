using System;

namespace YugiohDeck.Core
{
    class Range<T> where T : IComparable<T>
    {
        public readonly T Min;
        public readonly T Max;
        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException("min must be less than or equal to max");
            }
            this.Min = min;
            this.Max = max;
        }
        public bool Contains(T value)
        {
            return this.Min.CompareTo(value) < 0 && value.CompareTo(this.Max) < 1;
        }
    }
}
