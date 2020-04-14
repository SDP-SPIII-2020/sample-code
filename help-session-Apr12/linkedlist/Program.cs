using System;
using LanguageExt;
using static LanguageExt.List;
using static LanguageExt.Prelude;
using static ListExtensions;

namespace help_session_Apr12
{
    internal static class Program
    {
        public static void Main()
        {
            var ls = create(3, 4, 5, 6, 7, 8);
            Console.WriteLine($"List: {ls}");
            var ls2 = ls.InsertAt(5, 10);
            Console.WriteLine($"List: {ls2}");
        }
    }
}