using System;

namespace Overloading
{
    struct Complex
    {
        private const double Tolerance = 1e-6;

        public Complex(float real, float imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        float Real { get; }

        float Imaginary { get; }

        public override string ToString() => ($"({Real}, {Imaginary}i)");

        public static bool operator ==(Complex c1, Complex c2) =>
            ((Math.Abs(c1.Real - c2.Real) < Tolerance) && (Math.Abs(c1.Imaginary - c2.Imaginary) < Tolerance));

        public static bool operator !=(Complex c1, Complex c2) => (!(c1 == c2));

        public override bool Equals(object o2) => this == (Complex) o2;

        public override int GetHashCode() => Real.GetHashCode() ^ Imaginary.GetHashCode();

        public static Complex operator +(Complex c1, Complex c2) =>
            new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);

        public static Complex operator -(Complex c1, Complex c2) =>
            new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);

        public static Complex operator *(Complex c1, Complex c2) =>
            new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
                c1.Real * c2.Imaginary + c2.Real * c1.Imaginary);

        public static Complex operator /(Complex c1, Complex c2)
        {
            if ((Math.Abs(c2.Real) < Tolerance) && (Math.Abs(c2.Imaginary) < Tolerance))
                throw new DivideByZeroException("Can't divide by zero Complex number");

            var newReal = (c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) /
                          (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary);
            var newImaginary = (c2.Real * c1.Imaginary - c1.Real * c2.Imaginary) /
                               (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary);

            return (new Complex(newReal, newImaginary));
        }
    }
}