﻿using System;
using System.Collections.Generic;

namespace Reusable
{
    static class Program
    {
        static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var count = 0;
            foreach (var element in source)
            {
                checked // for overflow
                {
                    if (predicate(element))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static void Main()
        {
            bool[] bools = {false, true, false, false};
            var f = bools.Count(bln => bln == false); // out = 3
            Console.WriteLine(f);
            var t = bools.Count(bln => bln == true); // out =1
            Console.WriteLine(t);
        }
    }
}