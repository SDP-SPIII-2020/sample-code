// Hello-world-like example program
// Note: this file has Windows-style end-of-lines: CTRL-M CTRL-N

using System;

namespace DoubleExample
{
    public static class TestClass
    {
        public static void Main()
        {
            var m = new MyClass();
            Console.WriteLine("99*2 = {m.Double(99)}");
        }
    }

    internal class MyClass
    {
        public int Double(int val)
        {
            return val * 2;
        }
    }
}