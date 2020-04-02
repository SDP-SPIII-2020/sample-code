// Very basic C# exercises

using System;

// You can define a namespace to group classes together; or just ignore

namespace Enums
{
    public static class Enums
    {
        // this defines a new type, with name Weekdays, and lists possible values
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

        // this defines another type, to distinguish weekdays; we will use it later
        enum Days
        {
            WeekDay,
            WeekEnd
        };

        // a standard main function, that takes arguments from the command-line 
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                // expect 1 arg: day of week
                Console.WriteLine("Usage: Enums <weekday>");
            }
            else
            {
                var z = Weekdays.Mon; // needed for parsing
                var d = (Weekdays) Enum.Parse(z.GetType(), args[0]);
                Console.WriteLine($"Hard-coded weekday is {z}");
                Console.WriteLine($"Input  weekday is {d}");
                Console.WriteLine(z == d
                    ? "Both days are equal! Congrats, you have won!"
                    : "Days are different. Guess another day!");

                ShowWeekdays();
                ShowWeekdaysOk();
                ShowWeekdaysReflection();
            }
        }

        /// <summary>
        /// Show all Weekdays and their associated encodings. Verbose version, with a while loop,
        /// </summary>
        public static void ShowWeekdays()
        {
            var d = Weekdays.Mon;
            while (d <= Weekdays.Sun)
            {
                Console.WriteLine($"Days: {d} (rep {(int) d})");
                d++;
            }
        }

        /// <summary>
        /// Show all Weekdays and their associated encodings. Verbose version, but ok.
        /// </summary>
        static void ShowWeekdaysOk()
        {
            var d = Weekdays.Mon;
            while (d <= Weekdays.Sun)
            {
                Console.WriteLine($"{(int) d}: {d}");
                d++;
            }
        }

        // Notice this much shorter version, using "reflection"
        /// <summary>
        /// A shorter version of the above
        /// </summary>
        static void ShowWeekdaysReflection()
        {
            foreach (Weekdays d in Enum.GetValues(typeof(Weekdays)))
            {
                Console.WriteLine($"{(int) d}: {d}");
            }
        }
    } /* class */
} /* namespace */