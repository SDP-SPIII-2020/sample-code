using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Parse
{
    public static class StringExtension
    {
        private static Option<T> Parse<T>(this string s) where T : struct
            => Enum.TryParse(s, out T t) ? Some(t) : None;

        public static void Main(string[] args)
        {
            var s = "Friday".Parse<DayOfWeek>(); // => Some(DayOfWeek.Friday)
            Console.WriteLine(s);
            s = "Freeday".Parse<DayOfWeek>(); // => None
            Console.WriteLine(s);

            var t = Enum.Parse<DayOfWeek>("Friday"); // => Some(DayOfWeek.Friday)
            Console.WriteLine(t);
            t = Enum.Parse<DayOfWeek>("Freeday"); // => None
            Console.WriteLine(t);
        }
    }
}