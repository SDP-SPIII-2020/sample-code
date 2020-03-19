/* 
From: 
Parallel Programming with Microsoft® .NET
Design Patterns for Decomposition and Coordination on Multicore Architectures
By Colin Campbell, Ralph Johnson, Ade Miller, Stephen Toub
Publisher: Microsoft Press
Released:  August 2010 
On-line: http://msdn.microsoft.com/en-us/library/ff963547.aspx

Chapter on Parallel aggregation

This example adds a partitioner to aggregating ForEach loop.
*/

using System;
using System.Threading.Tasks;
using System.Collections.Generic; // for List<T>
using System.Collections.Concurrent; // for Partitioner

namespace Parallel03
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

        private static void MkSequence(List<int> seq, int m, int n)
        {
            if (m > n) return;
            seq.Add(m);
            MkSequence(seq, m + 1, n);
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
                System.Console.WriteLine("Usage: <prg> <k> <m> <n>");
                System.Console.WriteLine("k ... number of cores to use");
                System.Console.WriteLine("m, n ... the range of values to apply Fib to; a good range is: 35 39");
            }
            else
            {
                var k = Convert.ToInt32(args[0]);
                var m = Convert.ToInt32(args[1]);
                var n = Convert.ToInt32(args[2]);
                var sum = 0;
                object lockObject = new { }; // any non-null object will do as lock
                // int[] fibs = new int[n];
                var seq = new List<int>();
                MkSequence(seq, m, n);

                /* Parallel version, using only 2 tasks */
                Console.WriteLine($"Running Parallel Foreach, with aggregation, over sequence {seq} on {k} cores");
                // var options = new ParallelOptions() { MaxDegreeOfParallelism = k};
                var size = seq.Count / k; // make a partition large enough to feed k cores
                var rangePartitioner = Partitioner.Create(0, seq.Count, size+1);
                TimeIt(() =>
                {
                    Parallel.ForEach(
                        rangePartitioner, // The input intervals
                        () => 0, // The local initial partial result

                        // The loop body for each interval
                        (range, loopState, initialValue) =>
                        {
                            // a *sequential* loop to increase the granularity of the parallelism
                            var partialSum = initialValue;
                            for (var i = range.Item1; i < range.Item2; i++)
                            {
                                partialSum += Fib(seq[i]);
                            }

                            return partialSum;
                        },

                        // The final step of each local context
                        (localPartialSum) =>
                        {
                            // Use lock to enforce serial access to shared result
                            lock (lockObject)
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