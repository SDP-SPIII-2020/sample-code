using System;
using Microsoft.VisualBasic;

namespace example01
{
    internal static class Program
    {
        private static void Main()
        {
            var numberBox1 = new Box<int>(1);
            Console.WriteLine($"The initial contents of the box are {numberBox1.Item}");

            var result = from num in numberBox1 select num + 1;
            Console.WriteLine($"The contents of the box are {result.Item}");

            var result2 = result.Select(x => x + 1);
            Console.WriteLine($"The contents of the box are {result2.Item}");
        }
    }
}