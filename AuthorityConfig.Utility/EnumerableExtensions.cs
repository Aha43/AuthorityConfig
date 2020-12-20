using System.Collections.Generic;

namespace AuthorityConfig.Utility
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Extend<T>(this IEnumerable<T> enumerable, T e)
        {
            var list = new List<T>() { e };
            if (enumerable != null)
            {
                list.AddRange(enumerable);
            }

            return list.ToArray();
        }

    }

}
