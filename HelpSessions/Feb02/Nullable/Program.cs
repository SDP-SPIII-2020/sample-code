using System;

// An example to illustrate the use of "nullable" types.
// Requires the appropriate option at runtime as otherwise null types are acceptable.
// Also illustrates typical code layout and the use of "var".

namespace Nullable
{
// An integer sequence with Min and Max operations — with int? (a nullable type). 	

    static class IntSequence
    {
        static int? Min(int[] sequence)
        {
            int theMinimum;
            if (sequence.Length == 0)
            {
                return null; // only allowed with a nullable return type
            }
            else
            {
                theMinimum = sequence[0];
                foreach (var e in sequence)
                    if (e < theMinimum)
                    {
                        theMinimum = e;
                    }
            }

            return theMinimum;
        }

        static int? Max(int[] sequence)
        {
            int theMaximum;
            if (sequence.Length == 0)
            {
                return null; // only allowed with a nullable return type
            }
            else
            {
                theMaximum = sequence[0];
                foreach (var e in sequence)
                    if (e > theMaximum)
                    {
                        theMaximum = e;
                    }
            }

            return theMaximum;
        }

        static void ReportMinMax(int[] sequence)
        {
            if (Min(sequence).HasValue && Max(sequence).HasValue)
            {
                Console.WriteLine("Min: {0}. Max: {1}", Min(sequence), Max(sequence));
            }
            else
            {
                Console.WriteLine("Int sequence is empty");
            }
        }

        public static void Main()
        {
            int[] is1 = new int[] {-5, -1, 7, -8, 13};
            int[] is2 = new int[] { };

            ReportMinMax(is1);
            ReportMinMax(is2);
        }
    }
}