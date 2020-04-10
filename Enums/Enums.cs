using System;

namespace Examples
{
    public static class Enums
    {
        // We want to define a method that takes a day and returns the next day
        /// <summary>
        /// Take a day as input and return the next day as a result.
        /// </summary>
        /// <param name="d"> The input day  </param>
        /// <returns>Returns the next day of the week. </returns>
        public static Weekdays NextDay(Weekdays d)
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
        public static Weekdays NextDay1(Weekdays d) =>
            (Weekdays) ((int) (d + 1) % 7); // uses implicit conversions and int as basetype

        /// <summary>
        /// Take a day as input and return whether it is a WeekDay or a WeekEnd.
        /// </summary>
        /// <param name="d"> The input day  </param>
        /// <returns>Returns WeekDay or WeekEnd. </returns>
        public static Days WhatDay(Weekdays d) => d switch
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