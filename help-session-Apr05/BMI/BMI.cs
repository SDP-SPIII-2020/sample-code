using System;

namespace help_session_Apr05
{
    using static Math;

    public enum BmiRange
    {
        Underweight,
        Healthy,
        Overweight
    }

    public static class Bmi
    {
        public static void Main()
        {
            Run(Read, Write);
        }

        public static void Run(Func<string, double> read, Action<BmiRange> write)
        {
            // input
            var weight = read("weight");
            var height = read("height");

            // computation
            var bmiRange = CalculateBmi(height, weight).ToBmiRange();

            // output
            write(bmiRange);
        }

        public static double CalculateBmi(double height, double weight)
            => Round(weight / Pow(height, 2), 2);

        public static BmiRange ToBmiRange(this double bmi)
            => bmi < 18.5 ? BmiRange.Underweight
                : 25 <= bmi ? BmiRange.Overweight
                : BmiRange.Healthy;

        private static double Read(string field)
        {
            Console.Write($"Please enter your {field}: ");
            return double.Parse(Console.ReadLine() ?? "");
        }

        private static void Write(BmiRange bmiRange)
            => Console.WriteLine($"Based on your BMI, you are {bmiRange}");
    }
}