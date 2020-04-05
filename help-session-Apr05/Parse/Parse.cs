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
            "Friday".Parse<DayOfWeek>(); // => Some(DayOfWeek.Friday)
            "Freeday".Parse<DayOfWeek>(); // => None
        }
    }
}