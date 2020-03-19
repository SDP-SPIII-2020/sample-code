/* 
From: 
Parallel Programming with Microsoft® .NET
Design Patterns for Decomposition and Coordination on Multicore Architectures
By Colin Campbell, Ralph Johnson, Ade Miller, Stephen Toub
Publisher: Microsoft Press
Released:  August 2010 
On-line: http://msdn.microsoft.com/en-us/library/ff963547.aspx

Chapter on Parallel aggregation

This example extends the basic ForEach loop with a way to combine all results to an overall result.
*/

using System;
using System.Threading.Tasks;
// using Parallel;
using System.Collections.Generic;

namespace Parallel02
{
    internal static class ParallelLoops
    {
        private static int Fib(int n)
        {
            switch (n)
            {
                case 0:
                case 1:
                    return 1;
                default:
                {
                    var n1 = Fib(n - 1);
                    var n2 = Fib(n - 2);
                    return n1 + n2;
                }
            }
        }

        private static void MkSequence(ICollection<int> seq, int m, int n)
        {
            if (m > n)
            {
                return;
            }
            else
            {
                seq.Add(m);
                MkSequence(seq, m + 1, n);
                return;
            }
        }

        private static int SomeComputation(int i) => Fib(i);

        private delegate void WorkerDelegate();

        private static void TimeIt(WorkerDelegate worker)
        {
            var startTime = DateTime.Now;
            var stopTime = DateTime.Now;
            worker();
            var duration = stopTime - startTime;
            Console.WriteLine($"Elapsed time: {duration}");
        }

        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                // expect 1 arg: value to double
                Console.WriteLine("Usage: <prg> <k> <m> <n>");
                Console.WriteLine("k ... number of cores to use");
                Console.WriteLine("m, n ... the range of values to apply Fib to; a good range is: 39 43");
            }
            else
            {
                var k = Convert.ToInt32(args[0]);
                var m = Convert.ToInt32(args[1]);
                var n = Convert.ToInt32(args[2]);
                var sum = 0;
                object lockObject = new { }; // any non-null object will do as lock
                // int[] fibs = new int[n];
                // generates a range from input values; slightly artificial
                var seq = new List<int>();
                MkSequence(seq, m, n);

                /* Parallel version, using only 2 tasks */
                Console.WriteLine($"Running Parallel Foreach, with aggregation, over {m} .. {n} on {k} cores");
                var options = new ParallelOptions() {MaxDegreeOfParallelism = k};
                TimeIt(() =>
                {
                    Parallel.ForEach(
                        seq, // The values to be aggregated
                        options, // specify degree of parallelism
                        () => 0, // The local initial partial result
                        (x, loopState, partialResult) => Fib(x) + partialResult, // The loop body
                        (localPartialSum) => // The final step of each local context
                        {
                            lock (lockObject) // Enforce serial access to single, shared result
                            {
                                sum += localPartialSum;
                            }
                        });
                });
                Console.WriteLine($"Sum of Fib({m}) .. Fib({n}) = {sum}");
            }
        }
    }
}