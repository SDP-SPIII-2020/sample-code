using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads5
{
    public static class Program
    {
        public static void Main()
        {
            var t1 = new Task<int>(() =>
            {
                Console.WriteLine("Task One");
                Thread.Sleep(1000);
                return 123;
            });
            var t2 = t1.ContinueWith((tx) =>
            {
                Console.WriteLine($"Task Continued, receiving this value from Task One: {tx.Result}");
            });

            t1.Start();

            Console.WriteLine("Main task still working ...");
            Thread.Sleep(300);

            Task.WaitAll(t1, t2);
        }
    }
}