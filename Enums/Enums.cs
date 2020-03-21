using System;

namespace Examples
{
    class Enums
    {
        /// <summary>
        /// This method runs series of tests on the methods in this class.
        /// </summary>
        /// <seealso cref="NextDay(Weekdays)"> This is the main method that is tested. </seealso>
        internal static void Test(Weekdays d)
        {
            var d0 = Enums.WhatDay(d);
            Console.WriteLine("Testing some enums now...");

            Console.WriteLine("Testing with fixed input ...");
            var a = Weekdays.Sun; // test with a fixed input
            var a0 = Enums.WhatDay(a); // determine which day of the week this is
            var b = Enums.NextDay(a); // call the method NextDay to return the next day
            var b0 = Enums.WhatDay(b); // determine which day of the week this is
            Console.WriteLine($"Tomorrow of {a} (a {a0}) is {b} (a {b0})");

            Console.WriteLine("Testing with command-line input ...");
            var e = Enums.NextDay(d);
            var e0 = Enums.WhatDay(e);
            Console.WriteLine($"Tomorrow of {d} (a {d0}) is {e} (a {e0})");
            var f = Enums.NextDay1(d);
            var f0 = Enums.WhatDay(f);
            Console.WriteLine($"Tomorrow of {d} (a {d0}) is {f} (a {f0})");
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
        static Weekdays NextDay1(Weekdays d) =>
            (Weekdays) ((int) (d + 1) % 7); // uses implicit conversions and int as basetype

        /// <summary>
        /// Take a day as input and return whether it is a WeekDay or a WeekEnd.
        /// </summary>
        /// <param name="d"> The input day  </param>
        /// <returns>Returns WeekDay or WeekEnd. </returns>
        static Days WhatDay(Weekdays d) => d switch
        {
            Weekdays.Mon => Days.WeekDay,
            Weekdays.Tue => Days.WeekDay,
            Weekdays.Wed => Days.WeekDay,
            Weekdays.Thu => Days.WeekDay,
            Weekdays.Fri => Days.WeekDay,
            Weekdays.Sat => Days.WeekEnd,
            Weekdays.Sun => Days.WeekEnd,
            _ => Days.WeekEnd
        };
    }
}