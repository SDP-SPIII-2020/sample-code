using System;

// An example of using enums - as requested

namespace Enums
{
    class Enums
    {
        // Define a new type, with name Weekdays, and list possible values
        enum Weekdays
        {
            Mon,
            Tue,
            Wed,
            Thu,
            Fri,
            Sat,
            Sun
        };

        // Define another type, to distinguish weekdays; we will use it later
        enum Days
        {
            WeekDay,
            WeekEnd
        };

        // a standard main function, that takes arguments from the command-line 
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                // expect 1 arg: day of week
                Console.WriteLine("Usage: Program <weekday>");
            }
            else
            {
                Weekdays z = Weekdays.Mon; // needed for parsing
                Weekdays d = (Weekdays) Enum.Parse(z.GetType(), args[0]);
                Test(d); // call the test method in this class
            }
        }

        /// <summary>
        /// This method runs series of tests on the methods in the class.
        /// </summary>
        /// <seealso cref="NextDay(Weekdays)"> This is the main method that is tested. </seealso>
        static void Test(Weekdays d)
        {
            var d0 = WhatDay(d);
            Console.WriteLine("Testing some enums now...");

            Console.WriteLine("Testing with fixed input ...");
            Weekdays a = Weekdays.Sun; // test with a fixed input
            Days a0 = WhatDay(a); // determine which day of the week this is
            Weekdays b = NextDay(a); // call the method NextDay to return the next day
            Days b0 = WhatDay(b); // determine which day of the week this is
            Console.WriteLine("Tomorrow of " + a + " (a " + a0 + ") is " + b + " (a " + b0 + ")");

            Console.WriteLine("Testing with command-line input ...");
            Weekdays e = NextDay(d);
            Days e0 = WhatDay(e);
            Console.WriteLine("Tomorrow of " + d + " (a " + d0 + ") is " + e + " (a " + e0 + ")");
            Weekdays f = NextDay1(d);
            Days f0 = WhatDay(f);
            Console.WriteLine("Tomorrow of " + d + " (a " + d0 + ") is " + f + " (a " + f0 + ")");
        }

        // We want to define a method that takes a day and returns the next day
        /// <summary>
        /// Take a day as input and return the next day as a result.
        /// </summary>
        /// <param name="d"> The input day  </param>
        /// <returns>Returns the next day of the week. </returns>
        static Weekdays NextDay(Weekdays d)
        {
            // using a switch expression here (easiest solution)
            // declare a variable which will hold the result
            var e = d switch
            {
                // examine the value in d, and check if it's one of the values below
                Weekdays.Mon => Weekdays.Tue,
                Weekdays.Tue => Weekdays.Wed,
                Weekdays.Wed => Weekdays.Thu,
                Weekdays.Thu => Weekdays.Fri,
                Weekdays.Fri => Weekdays.Sat,
                Weekdays.Sat => Weekdays.Sun,
                Weekdays.Sun => Weekdays.Mon,
                _ => Weekdays.Mon
            };

            return e; // return the value we have assigned to
        }

        /// <summary>
        /// Take a day as input and return the next day as a result.
        /// An alternative, shorter implementation.
        /// </summary>
        /// <param name="d"> The input day  </param>
        /// <returns>Returns the next day of the week. </returns>
        static Weekdays NextDay1(Weekdays d)
        {
            return (Weekdays) ((int) (d + 1) % 7); // uses implicit conversions and int as basetype
        }

        /// <summary>
        /// Take a day as input and return whether it is a WeekDay or a WeekEnd.
        /// </summary>
        /// <param name="d"> The input day  </param>
        /// <returns>Returns WeekDay or WeekEnd. </returns>
        static Days WhatDay(Weekdays d)
        {
            return d switch
            {
                _ when d >= Weekdays.Mon && d <= Weekdays.Fri => Days.WeekDay,
                _ when d == Weekdays.Sat || d == Weekdays.Sun => Days.WeekEnd,
                _ => Days.WeekEnd
            };
        }
    }
}