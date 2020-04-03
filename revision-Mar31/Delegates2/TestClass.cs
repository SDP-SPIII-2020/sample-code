// Advanced C# Constructs: Delegates

using System;

// simple higher-order example, using delegates
// this class takes an int -> int function and applies it twice

namespace Delegates2
{
    internal static class TestClass
    {
        private static int Double(int val) => val * 2;

        public static void Main(string[] args)
        {
            var x = 32;
            Console.WriteLine($"Applying double once on {x} gives {Double(x)}");
            Console.WriteLine($"Applying double twice, using class Twice, on {x} gives {Twice.twice(Double, x)}");
        }
    }
}