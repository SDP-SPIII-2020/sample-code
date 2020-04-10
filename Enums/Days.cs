using System;
using System.ComponentModel;

namespace Examples
{
    // this defines a new type, with name Weekdays, and lists possible values
    public enum Weekdays
    {
        [Description("Monday")] Mon,
        [Description("Tuesday")] Tue,
        [Description("Wednesday")] Wed,
        [Description("Thursday")] Thu,
        [Description("Friday")] Fri,
        [Description("Saturday")] Sat,
        [Description("Sunday")] Sun
    };

    // this defines another type, to distinguish weekdays; we will use it later
    public enum Days
    {
        [Description("Week Day")] WeekDay,
        [Description("Week End")] WeekEnd
    };

    static class DaysExtensions
    {
        public static string ToFriendlyString(this Days me)
        {
            return me switch
            {
                Days.WeekDay => "Week Day",
                Days.WeekEnd => "Week End",
                _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
            };
        }
    }
}