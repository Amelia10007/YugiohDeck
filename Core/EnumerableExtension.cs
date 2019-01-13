using System;
using System.Collections.Generic;

namespace YugiohDeck.Core
{
    static class EnumerableExtension
    {
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
        public static IEnumerable<Tuple<T,int>> WithIndex<T>(this IEnumerable<T> enumerable)
        {
            int index = 0;
            foreach(var e in enumerable)
            {
                yield return new Tuple<T, int>(e, index);
                index++;
            }
        }
    }
}
