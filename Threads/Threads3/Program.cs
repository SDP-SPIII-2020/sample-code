using System;
using System.Collections.Generic;
using System.Threading;

namespace Threads3
{
    public static class Program
    {
        // list of all threads
        private static readonly LinkedList<Thread> AllThreads = new LinkedList<Thread>();

        // summary: test wrapper, generating a test for each filename in args
        public static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main thread";
            foreach (var s in args)
            {
                // set-up a test for file s
                var t = new Test(s);

                // run the test
                var currT = new Thread(t.RunTest) {Name = "Tester_for_file_" + s};

                // add the thread to this list of all threads
                AllThreads.AddLast(currT);

                // now, start a new thread for the test
                currT.Start();
            }

            foreach (var thr in AllThreads)
            {
                // iterate over all threads and join it with the main one
                thr.Join();
                Console.WriteLine($"<{thr.Name}> shutting down.");
            }

            Console.WriteLine($"<{Thread.CurrentThread.Name}> thread terminates.");
        }
    }
}