// -----------------------------------------------------------------------------
// Increment/Decrement example, now with tunable lo- and hi-marks
// This demonstrates how to indirectly pass an argument to the Increment/Decrement methods
// -----------------------------------------------------------------------------

using System.Threading;
using System;

namespace Threads2
{
    public class Tester
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                // expect 2 args: a low-mark and a high-mark
                Console.WriteLine("Usage: <prg> <loMark> <hiMark>");
            }
            else
            {
                var t = new Tester();
                t.DoTest(args);
            }
        }

        private void DoTest(string[] args)
        {
            Thread[] myThreads =
            {
                new Thread(new ThreadStart(Decrement)), // arg is a function from void to void
                new Thread(new ThreadStart(Incrementer)) // arg is a function from void to void
            };

            var n = 1;
            // init the marks and make them available to Increment/Decrement
            // NB: this must be done *before* launching the threads, otw we have a race condition!

            _loMark = Convert.ToInt32(args[0]);
            _hiMark = Convert.ToInt32(args[1]);
            // start all threads

            foreach (var myThread in myThreads)
            {
                myThread.IsBackground = true;
                myThread.Name = "Thread" + n.ToString();
                Console.WriteLine($"Starting thread {myThread.Name}");
                myThread.Start();
                n++;
                // add a delay in starting all threads
                Thread.Sleep(500);
            }

            // wait for all threads to end
            foreach (var myThread in myThreads)
            {
                myThread.Join();
            }

            // after all threads end print this message
            Console.WriteLine("All my threads are done");
        }

        private int _hiMark; // never increment beyond this mark
        private int _loMark; // never decrement below this mark
        private int _counter = 0;

        private void Decrement()
        {
            try
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] Decrement finds a loMark of {_loMark}.");

                // (1) synchronise this area
                Monitor.Enter(this);

                while (_counter < _loMark)
                {
                    // now, this uses the loMark 
                    Console.WriteLine($"[{Thread.CurrentThread.Name}] In Decrement. Counter: {_counter}. Waiting...");
                    Monitor.Wait(this);
                }

                while (_counter >= _loMark)
                {
                    Thread.Sleep(1);
                    Console.WriteLine($"[{Thread.CurrentThread.Name}] In Decrement. Counter: {_counter}.");
                    _counter--;
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        private void Incrementer()
        {
            try
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] Incrementer finds a hiMark of {_hiMark}.");

                // (1) synchronise this area
                Monitor.Enter(this);

                while (_counter < _hiMark)
                {
                    // now, this uses the hiMark 
                    // (2) more fine-grained control like this:
                    Monitor.Enter(this);
                    _counter++;
                    Thread.Sleep(1);
                    Console.WriteLine($"[{Thread.CurrentThread.Name}] In Incrementer. Counter: {_counter}.");
                    

                    // (2) more fine-grained control like this:
                    Monitor.Pulse(this); // inform waiting threads of the change
                    Monitor.Exit(this); // leave monitor
                    Thread.Sleep(1); // give other threads time to work
                }

                Monitor.Pulse(this); // (1) release lock after all increments!
            }
            finally
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] Exiting ...");
                Monitor.Exit(this);
            }
        }
    }
}