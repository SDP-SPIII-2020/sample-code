using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace FunctionalProgrammingRedux
{
    public static class AvoidChangingState
    {
        public static void Main(string[] args)
        {
            // int[] original = {1, 7, 4, 3, 2};
            // var sorted = original.OrderBy(x => x);
            // var filtered = original.Where(x => x % 2 == 0);
            // original.ToList().ForEach(x => Console.Write($"  {x}")); Console.WriteLine();
            // sorted.ToList().ForEach(x => Console.Write($"  {x}"));Console.WriteLine();
            // filtered.ToList().ForEach(x => Console.Write($"  {x}"));Console.WriteLine();
            //
            // var orig = original.ToList();
            // orig.Sort();
            // orig.ForEach(x => Console.Write($"  {x}")); Console.WriteLine();
            //
            // original.ToList().Sort();
            // original.ToList().ForEach(x => Console.Write($"  {x}")); Console.WriteLine();
            var numbers = Enumerable.Range(10000, 20001).ToList();
            Console.WriteLine($"The sum of the sequence is {numbers.Sum()}");

            void Task1() => Console.WriteLine($"The sum of the sequence is {numbers.Sum()}");
            void Task2()
            {
                numbers.Sort();
                Console.WriteLine($"The sum is {numbers.Sum()}");
            }

            Parallel.Invoke((Action) Task1,Task2);
        }
    }
}
// By default, many of the C# structures are mutable