using System;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;

namespace PartA
{
    public static class LookupExample
    {
        public static Option<T> Lookup<T>(this IEnumerable<T> ts, Func<T, bool> pred)
        {
            foreach (T t in ts)
                if (pred(t))
                    return Some(t);
            return None;
        }
    }
}