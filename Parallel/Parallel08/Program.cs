using System;
using System.Collections;
using System.Collections.Generic; // for List<T>
using System.Threading.Tasks; // parallel patterns

/*
    Time-stamp: <>

    Parallel implementation, testing the "Goldbach conjecture":
    Every even integer greater than 2 can be expressed as the sum of two primes.
    See: http://en.wikipedia.org/wiki/Goldbach%27s_conjecture

    Usage: goldbach <no. of proc> <int>
        to test the Goldbach conjecture on numbers up to <int>
*/

namespace Parallel08
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                // expect 1 args: x
                Console.WriteLine("Usage: Program <int> <int>");
            }
            else
            {
                var p = Convert.ToInt32(args[0]);
                var x = Convert.ToInt32(args[1]);
                Console.WriteLine(
                    $"Parallel Goldbach conjecture (parallel version) up to {x} is {Goldbach.GoldbachPar(x, p)} on {p} processors");
                Console.WriteLine($"Goldbach conjecture (naive version) up to {x} is {Goldbach.GoldbachNaive(x)}");
            }
        }
    }
}