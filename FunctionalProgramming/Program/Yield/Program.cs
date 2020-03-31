//#define OLD

using System;
using System.Collections.Generic;
using System.Linq;

namespace Yield
{
    internal static class Program
    {
        public static void Main()
        {
            int[] a = {1, 2, 3, 4, 5};
            foreach (int n in GreaterThan(a, 3))
            {
                Console.WriteLine(n);
            }

            //Console.WriteLine(GreaterThan(a, 2).First().ToString());
            //Console.WriteLine(GreaterThan(a, 2).Last().ToString());
        }

#if OLD
        static IEnumerable<int> GreaterThan(int[] arr, int gt)
        {
            List<int> temp = new List<int>();
            foreach (int n in arr)
            {
                if (n > gt) temp.Add(n);
            }

            return temp;
        }
#else
        static IEnumerable<int> GreaterThan(int[] arr, int gt)
        {
            foreach (int n in arr)
            {
                if (n > gt) yield return n;
            }
        }
#endif
    }
}