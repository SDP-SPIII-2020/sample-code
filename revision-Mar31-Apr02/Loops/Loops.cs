// Simple examples using loops over arrays

using System;

namespace Loops
{
    public static class Loops
    {
        public static void Main()
        {
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Console.WriteLine("Testing some loops now...");
            Run(10);
            SumArr(arr);
            for (var i = 0; i < 10; i++)
            {
                arr[i] = i - 1;
            }

            SumArr(arr);
        }

        private static void Run(int n)
        {
            int i = 0, s = 0;
            while (i <= n)
            {
                s += i;
                i++;
            }

            Console.WriteLine("Sum from 0 to " + n + " = " + s);

            s = 0;
            for (i = 0; i <= n; i++)
            {
                s += i;
            }

            Console.WriteLine("Sum from 0 to " + n + " = " + s);
        }

        private static void SumArr(int[] arr)
        {
            int i, s = 0;
            for (i = 0; i < arr.Length; i++)
            {
                s += arr[i];
            }

            Console.WriteLine("SumArr = " + s);
            s = 0;
            foreach (var j in arr)
            {
                // need different variable here
                s += j;
            }

            Console.WriteLine("SumArr = " + s);
        }
    }
}