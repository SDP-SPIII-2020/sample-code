using System;
using System.Collections.Generic;

namespace Reusable
{
    static class Program
    {
        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            int count = 0;
            foreach (TSource element in source)
            {
                checked
                {
                    if (predicate(element))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}