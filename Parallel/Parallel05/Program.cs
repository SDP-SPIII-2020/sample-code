/* 
From: 
Parallel Programming with Microsoft® .NET
Design Patterns for Decomposition and Coordination on Multicore Architectures
By Colin Campbell, Ralph Johnson, Ade Miller, Stephen Toub
Publisher: Microsoft Press
Released:  August 2010 
On-line: http://msdn.microsoft.com/en-us/library/ff963547.aspx

Chapter on Futures

*/

using System;
using System.Threading.Tasks;

namespace Parallel05
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                // expect 1 arg: value to double
                Console.WriteLine("Usage: <n> ... input to Fib");
            }
            else
            {
                var n = Convert.ToInt32(args[0]);
                Console.WriteLine($"Sequential computation of Fib({n})): {Futures.SeqCode(n)}");
                Console.WriteLine($"Parallel computation of Fib({n})) using futures: {Futures.ParCode(n)}");
            }
        }
    }
}