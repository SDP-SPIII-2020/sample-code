﻿using System.Threading;
using System;

namespace Threads1
{
    public class Program
    {
        public static void Main()
        {
            var t = new Program();
            t.DoTest();
        }

        private void DoTest()
        {
            Thread[] myThreads =
            {
                new Thread(new ThreadStart(Decrement)),
                new Thread(new ThreadStart(Increment))
            };

            var n = 1;
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
            Console.WriteLine("All threads are done");
        }

        private long _counter = 0;

        private void Decrement()
        {
            try
            {
                // (1) synchronise this area
                Monitor.Enter(this);

                while (_counter < 5)
                {
                    Console.WriteLine($"[{Thread.CurrentThread.Name}] In Decrement. Counter: {_counter}. Waiting...");
                    Monitor.Wait(this);
                }

                while (_counter > 0)
                {
                    Thread.Sleep(2);
                    Console.WriteLine($"[{Thread.CurrentThread.Name}] In Decrement. Counter: {_counter}.");
                    _counter--;
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        private void Increment()
        {
            try
            {
                // (1) synchronise this area
                Monitor.Enter(this); // comment this out and line XXX to see what happens

                while (_counter < 10)
                {
                    // (2) more fine-grained control like this:
                    Monitor.Enter(this);
                    Thread.Sleep(1);
                    _counter++;
                    Console.WriteLine($"[{Thread.CurrentThread.Name}] In Increment. Counter: {_counter}.");

                    // (2) more fine-grained control like this:
                    Monitor.Pulse(this); // inform waiting threads of the change
                    Monitor.Exit(this); // leave monitor
                    Thread.Sleep(1); // give other threads time to work
                }

                Monitor.Pulse(this); // (1) release lock after all increments! --- XXX
            }
            finally
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] Exiting ...");
                Monitor.Exit(this);
            }
        }
    }
}