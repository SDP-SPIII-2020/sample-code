using System;

namespace Example
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IThing x = new Thing(3);
            IThing y = new Thing(4);
            Console.WriteLine($"Result: {x + y}");
        }
    }
}