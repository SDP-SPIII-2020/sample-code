using System;

namespace Mar16
{
    public interface IFraction
    {
        public IFraction Add(IFraction f);
        public static IFraction operator +(IFraction f1, IFraction f2) => f1.Add(f2);
    }

    public readonly struct Fraction : IFraction
    {
        private int One { get; }
        private int Two { get; }

        public Fraction(int one = 0, int two = 1)
        {
            One = one;
            Two = two;
        }

        public IFraction Add(IFraction f)
        {
            var fraction = f as Fraction? ?? default;
            return new Fraction(this.One + fraction.One, this.Two + fraction.Two);
        }

        public override string ToString() => $"One: {One} and Two: {Two}";
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            IFraction f1 = new Fraction(1,2);
            IFraction f2 = new Fraction(1,2);
            //var f3 = f1.Add(f2);
            var f3 = f1 + f2;
            Console.WriteLine(f3);
        }
    }
}