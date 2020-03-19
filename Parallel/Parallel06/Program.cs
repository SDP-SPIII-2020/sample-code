using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

/* 
    From: Parallel Programming with Microsoft® .NET
    Design Patterns for Decomposition and Coordination on Multicore Architectures
    By Colin Campbell, Ralph Johnson, Ade Miller, Stephen Toub
    Publisher: Microsoft Press
    Released:  August 2010 
    On-line: http://msdn.microsoft.com/en-us/library/ff963547.aspx

    Chapter on Pipelines

    Simplified example from the book.
*/

namespace Parallel06
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                // expect 1 arg: value to double
                Console.WriteLine("Usage: <prg> <k> <m> <n>");
                Console.WriteLine("k ... number of cores to use");
                Console.WriteLine("m, n ... the range of values to apply square function to");
            }
            else
            {
                var k = Convert.ToInt32(args[0]); // unused
                var m = Convert.ToInt32(args[1]);
                var n = Convert.ToInt32(args[2]);
                object lockObject = new { }; // any non-null object will do as lock

                // generates a range from input values; slightly artificial
                // List<int> seq = new List<int>();
                // mkSequence(seq, m, n);
                Pipeline<int>.IncDelegate inc = new Pipeline<int>.IncDelegate(x => x + 1);

                /* Parallel version, using only 2 tasks */
                Console.WriteLine($"Generating a list of squares, using a pipeline: {m} .. {n}");

                const int limit = 10; // buffer size
                const string str = "";
                var resultStr = "";
                var buffer1 = new BlockingCollection<int>(limit);
                var buffer2 = new BlockingCollection<int>(limit);

                var f = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
                Console.WriteLine("Starting Producer writing to buffer1 ... ");

                var task1 = f.StartNew(() => Pipeline<int>.Producer(buffer1, m, n, inc));

                // MkSequence(seq,m,n)));
                Console.WriteLine("Starting Consumer, reading from buffer1 writing to buffer2 ... ");
                var task2 = f.StartNew(() => Pipeline<int>.Consumer(buffer1,
                    new Pipeline<int>.ConsumerDelegate(x => x * x),
                    buffer2));

                Console.WriteLine("Starting LastConsumer reading from buffer2 ... ");
                var task3 = f.StartNew(() => { resultStr = Pipeline<int>.LastConsumer(buffer2, str); });

                Console.WriteLine("Waiting for all results ... ");

                Task.WaitAll(task1, task2, task3);
                Console.WriteLine($"Result is: {resultStr}");
            }
        }
    }
}