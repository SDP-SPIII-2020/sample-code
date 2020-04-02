// Example on nullable types
// Object-oriented Programming in C# for C and Java programmers
// http://www.cs.aau.dk/~normark/oop-csharp/html/notes/more-classes_themes-value-types-sect.html#more-classes_nullable-types_title_1

using System;

// An integer sequence with Min and Max operations - with int?. 	

namespace Nullable
{
    public static class IntSequenceClient
    {
        private static int? Min(int[] sequence)
        {
            if (sequence.Length == 0)
                return null;
            var theMinimum = sequence[0];
            foreach (var e in sequence)
                if (e < theMinimum)
                    theMinimum = e;
            return theMinimum;
        }

        private static int? Max(int[] sequence)
        {
            if (sequence.Length == 0)
                return null;
            var theMaximum = sequence[0];
            foreach (var e in sequence)
                if (e > theMaximum)
                    theMaximum = e;
            return theMaximum;
        }

        private static void ReportMinMax(int[] sequence)
        {
            if (Min(sequence).HasValue && Max(sequence).HasValue)
                Console.WriteLine($"Min: {Min(sequence)}. Max: {Max(sequence)}");
            else
                Console.WriteLine("Int sequence is empty");
        }

        public static void Main()
        {
            var is1 = new int[] {-5, -1, 7, -8, 13};
            var is2 = new int[] { };

            ReportMinMax(is1);
            ReportMinMax(is2);
        }
    }
}