using System;
using System.Collections.Generic;

namespace YugiohDeck
{
    static class EnumerableExtension
    {
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
    }
}
