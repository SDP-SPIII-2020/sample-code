using System;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;

namespace LookupExtension
{
    public static class EnumerableExtension
    {
        private static Option<T> Lookup<T>(this IEnumerable<T> ts, Func<T, bool> pred)
        {
            foreach (var t in ts)
                if (pred(t))
                    return Some(t);
            return None;
        }

        public static void Main(string[] args)
        {
            bool isOdd(int i) => i % 2 == 1;
            Console.WriteLine(new List<int>().Lookup(isOdd)); // => None
            Console.WriteLine(new List<int> {1}.Lookup(isOdd)); // => Some(1)
        }
    }
}