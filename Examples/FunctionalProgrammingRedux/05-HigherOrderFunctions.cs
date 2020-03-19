using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgrammingRedux
{
    public static class HigherOrderFunctions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> ts, Func<T, bool> predicate)
        {
            foreach (var t in ts)
            {
                if (predicate(t))
                {
                    yield return t;
                }
            }
        }

        public static void Main(string[] args)
        {
            // Func<int, bool> isDivisible(int n)
            // {
            //     return x => x % n == 0;
            // }
            //
            // var numbers = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
            // var num3 = numbers.Where(isDivisible(3));
            // Console.WriteLine(isDivisible(3));
            // num3.ToList().ForEach(x => Console.Write($"  {x}"));
            // Console.WriteLine();
        }
    }
}