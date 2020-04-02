using System;

namespace CmdLineInput
{
    public static class TestClass
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                // expect 1 args: x
                Console.WriteLine("Usage: CmdLineInput <int>");
            }
            else
            {
                var x = Convert.ToInt32(args[0]);
                var m = new MyClass();
                Console.WriteLine($"Doubling the value {x} gives {m.Double(x)}");
            }
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