using System;
using System.Collections.Generic;

namespace YugiohDeck
{
    static class Extension
    {
        public static T MapIf<T>(this T value, bool condition, Func<T, T> map)
        {
            if (condition)
            {
                return value;
            }
            else
            {
                return map(value);
            }
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }
        public static int IndexOf<T>(this IEnumerable<T> enumerable, T item) where T : IEquatable<T>
        {
            int i = 0;
            foreach (var e in enumerable)
            {
                if (item?.Equals(e) ?? (e == null)) return i;
                i++;
            }
            return -1;
        }

        public static T TryGet<T, TAllowException>(Func<T> getter, T defaultValue) where TAllowException : Exception
        {
            try
            {
                return getter();
            }
            catch (TAllowException)
            {
                return defaultValue;
            }
        }
    }
}
