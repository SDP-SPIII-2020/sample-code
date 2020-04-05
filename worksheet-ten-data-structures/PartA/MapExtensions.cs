using System;
using System.Collections.Generic;
using static LanguageExt.Prelude;

namespace PartA
{
    public static class Mapp
    {
        // Map : ISet<T> -> (T -> R) -> ISet<R>
        static ISet<R> Map<T, R>(this ISet<T> ts, Func<T, R> f)
        {
            var rs = new LanguageExt.HashSet<R>();
            foreach (var t in ts)
                rs.Add(f(t));
            return rs;
        }

        // Map : IDictionary<K, T> -> (T -> R) -> IDictionary<K, R>
        static IDictionary<K, R> Map<K, T, R>
            (this IDictionary<K, T> dict, Func<T, R> f)
        {
            var rs = new Dictionary<K, R>();
            foreach (var pair in dict)
                rs[pair.Key] = f(pair.Value);
            return rs;
        }
    }
}