using System;
using System.Linq;

/* 
    From: Parallel Programming with Microsoft® .NET
    Design Patterns for Decomposition and Coordination on Multicore Architectures
    By Colin Campbell, Ralph Johnson, Ade Miller, Stephen Toub
    Publisher: Microsoft Press
    Released:  August 2010 
    On-line: http://msdn.microsoft.com/en-us/library/ff963547.aspx

    Chapter on Dynamic Parallelism

    This is an example of divide-and-conquer parallelism.

    Possible extensions:
    . implement a more efficient sorting alg for the base case
    . use generics to abstract over the data-type
    . use delegates to abstract over the comparison function

    Parallel Quicksort
*/

namespace Parallel07
{
    public static class Program
    {
        public static int Size { get; } = 1000000;
        private const int MaxVal = 1000; // bound on values
        private const int Iterations = 3; // number of tests to run

        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                // expect 1 arg: value to double
                Console.WriteLine("Usage: <prg> <v> <n> <t>");
                Console.WriteLine(
                    "v ... version (0: sequential, 1: parallel, implicit threshold, 2: parallel, explicit threshold)");
                Console.WriteLine("n ... list length");
                Console.WriteLine("t ... threshold for generating parallelism");
            }
            else
            {
                var v = Convert.ToInt32(args[0]);
                var n = Convert.ToInt32(args[1]);
                var t = Convert.ToInt32(args[2]);

                var seed = 1701 + 13 * n;
                for (var j = 0; j < Iterations; j++)
                {
                    var rg = new Random((seed + j * 7) % 65535); // fix a seed for deterministic results
                    var arr = new int[n];
                    Console.WriteLine($"Generating an array of size {n} ...");
                    for (var i = 0; i < n; i++)
                    {
                        arr[i] = rg.Next() % MaxVal;
                    }

                    arr.ToList().ForEach(x => Console.Write($" {x}"));
                    Console.WriteLine();

                    switch (v)
                    {
                        // sequential sort
                        case 0:
                            Console.WriteLine($"Sequential sorting (size {n}) ...");
                            ParallelSort.SequentialQuickSort(arr);
                            arr.ToList().ForEach(x => Console.Write($" {x}"));
                            Console.WriteLine();
                            break;
                        case 1:
                            Console.WriteLine($"Parallel sorting (size {n}, implicit threshold)...");
                            ParallelSort.ParallelQuickSort(arr);
                            arr.ToList().ForEach(x => Console.Write($" {x}"));
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine($"Parallel sorting (size {n}, threshold {1}))...");
                            ParallelSort.ParallelQuickSort(arr, t);
                            arr.ToList().ForEach(x => Console.Write($" {x}"));
                            Console.WriteLine();
                            break;
                        default:
                            Console.WriteLine(
                                "Unknown version {v}; use 0: sequential, 1: parallel, implicit threshold, 2: parallel, explicit threshold");
                            continue;
                    }
                }
            }
        }
    }
}