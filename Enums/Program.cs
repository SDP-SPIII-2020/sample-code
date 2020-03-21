using System;

namespace Examples
{
    public static class Program
    {
        // a standard main function, that takes arguments from the command-line 
        public static void Main(string[] args)
        {
            Console.WriteLine("cmdline arg: {args[0]}");
            if (args.Length != 1)
            {
                // expect 1 arg: day of week
                Console.WriteLine("Usage: Program <weekday>");
            }
            else
            {
                var z = Weekdays.Mon; // needed for parsing
                var d = (Weekdays) Enum.Parse(z.GetType(), args[0]);
                Enums.Test(d); // call the test method in this class
            }
        }
    }
}