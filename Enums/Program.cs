using System;

namespace Examples
{
    public static class Program
    {
        // a standard main function, that takes arguments from the command-line 
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                // expect 1 arg: day of week
                Console.WriteLine("Usage: Program <weekday>");
            }
            else
            {
                var z = Weekdays.Mon; // needed for parsing
                var d = (Weekdays) Enum.Parse(z.GetType(), args[0]);
                Test(d); // call the test method in this class
            }
        }
        
        /// <summary>
        /// This method runs series of tests on the methods Enums.
        /// </summary>
        private static void Test(Weekdays d)
        {
            var d0 = Enums.WhatDay(d);
            Console.WriteLine("Testing some enums now...");

            Console.WriteLine("Testing with fixed input ...");
            var a = Weekdays.Sun; // test with a fixed input
            var a0 = Enums.WhatDay(a); // determine which day of the week this is
            var b = Enums.NextDay(a); // call the method NextDay to return the next day
            var b0 = Enums.WhatDay(b); // determine which day of the week this is
            Console.WriteLine($"Tomorrow of {a.GetDescription()} (a {a0.GetDescription()}) is {b.GetDescription()} (a {b0.GetDescription()})");

            Console.WriteLine("Testing with command-line input ...");
            var e = Enums.NextDay(d);
            var e0 = Enums.WhatDay(e);
            Console.WriteLine($"Tomorrow of {d.GetDescription()} (a {d0.GetDescription()}) is {e.GetDescription()} (a {e0.GetDescription()})");
            var f = Enums.NextDay1(d);
            var f0 = Enums.WhatDay(f);
            Console.WriteLine($"Tomorrow of {d.GetDescription()} (a {d0.ToFriendlyString()}) is {f.GetDescription()} (a {f0.ToFriendlyString()})");
        }
    }
}