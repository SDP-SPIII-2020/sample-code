using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intarr = {1, 2, 3, 4, 5, 6, 7, 8};
            //var (first, last, thing) = FirstAndLast(intarr);
            var ret = FirstAndLast(intarr);
            Console.WriteLine(ret);
            //Console.WriteLine($"First value is {first}, Last value is {last}");
        }

        private static (int, int, string) FirstAndLast(int[] intarr) =>
            (intarr[0], intarr[^1], "First value is {first}, Last value is {last}");
            // intarr[0] - first element
            // intarr[intarr.Length-1] - last element

        class ReturnValues
        {
            public ReturnValues(int first, int second)
            {
                First = first;
                Second = second;
            }

            int First { get; }
            int Second { get; }

            public override string ToString() => $"First = {First}, Second = {Second}";
        }
    }
}