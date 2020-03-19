/* Sequential verion:
int n = ...
for (int i = 0; i < n; i++)
{
   // ... 
}

The parallel version has this signature:

Parallel.For(int fromInclusive, int toExclusive, Action<int> body);

*/

using System;
using System.Threading.Tasks;

namespace Parallel
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
                Console.WriteLine("m, n ... the range of values to apply Fib to; a good range is: 35 39");
            }
            else
            {
                var k = Convert.ToInt32(args[0]);
                var m = Convert.ToInt32(args[1]);
                var n = Convert.ToInt32(args[2]);
                var fibs = new int[n];

                /* Parallel version, using only 2 tasks */
                var options = new ParallelOptions() {MaxDegreeOfParallelism = k};
                TimeIt(() =>
                {
                    System.Threading.Tasks.Parallel.For(m, n, options, i => { fibs[i] = ParallelLoops.Fib(i); });
                });
                for (var j = m; j < n; j++)
                {
                    Console.WriteLine($"Fib({j}) = {fibs[j]}");
                }
            }
        }
    }
}