using System.Collections.Generic;
using System.Linq;

namespace AuthorityConfig.Utility
{
    public static class CollectionsExtensions
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

        public static ICollection<string> UnionWithTokens(this ICollection<string> collection, string tokensToAdd)
        {
            collection ??= new List<string>();
            tokensToAdd ??= string.Empty;
            var set = new HashSet<string>(collection);
            var tokens = tokensToAdd.Split(' ');
            return set.Union(tokens).ToList();
        }

        public static ICollection<string> RemoveTokens(this ICollection<string> collection, string tokensToRemove)
        {
            collection ??= new List<string>();
            tokensToRemove ??= string.Empty;
            var tokens = tokensToRemove.Split(' ');
            var retVal = new List<string>(collection);
            foreach (var t in tokens) retVal.Remove(t);
            return retVal;
        }

    }

}
