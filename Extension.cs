using System;
using System.Collections.Generic;

namespace YugiohDeck
{
    static class Extension
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
    }
}
