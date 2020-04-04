// -------------------------------------------------------------

#define DEBUG

using System;
using System.Diagnostics.Contracts;

// Examples from C# Basics, adapted to use code contracts

namespace Functions
{
    public static class Functions
    {
        public static void Main()
        {
            int[] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var x = 0;
            const int goodN = 3; // OK index
            const int badN = 15; // illegal index
            const int n1 = 7;
            const int n2 = 8;
            var n3 = 9;

            Console.WriteLine("Testing array operations on this array: " + ShowArr(arr));
            Console.WriteLine($"Get of {goodN}-th element (out of {arr.Length}) = {Get(arr, goodN)}"); // OK
            Console.WriteLine($"Get of {badN}-th element (out of {arr.Length}) = {Get(arr, badN)}");
            // throws an illegal index exception, unless checked by pre-condition

            Console.WriteLine($"Setting the {n1}-th element to {x}");
            Set(arr, n1, x);
            Console.WriteLine("Modified array: " + ShowArr(arr));

            Console.WriteLine($"SetStepping the {n2}-th element to {x}");
            SetStepBroken(arr, n2, x);
            Console.WriteLine("Modified array: " + ShowArr(arr));
            Console.WriteLine($"Index = {n2}");
            Console.WriteLine($"SetStepping the {n3}-th element to {x}");
            n3 = SetStep(arr, n3, x);
            Console.WriteLine("Modified array: " + ShowArr(arr));
            Console.WriteLine($"Index = {n3}");
        }

        private static int Get(int[] arr, int n)
        {
            Contract.Requires(n < arr.Length);
            return arr[n];
        }

        private static void Set(int[] arr, int n, int x)
        {
            Contract.Requires(n < arr.Length);
            arr[n] = x;
        }

        private static void SetStepBroken(int[] arr, int n, int x)
        {
            arr[n] = x;
            n += 1;
        }

        private static int SetStep(int[] arr, int n, int x)
        {
            arr[n] = x;
            n++;
            return n;
        }

        static string ShowArr(int[] arr)
        {
            var s = "";
            foreach (var i in arr)
            {
                if (s != "")
                {
                    s += ',';
                }

                s += i.ToString();
            }

            return s;
        }
    }
}