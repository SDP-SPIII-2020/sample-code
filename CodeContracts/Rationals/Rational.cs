using System.Diagnostics.Contracts;

namespace Rationals
{
    internal class Rational
    {
        private int _denominator;

        public Rational(int numerator, int denominator)
        {
            Contract.Requires(denominator != 0);

            Numerator = numerator;
            Denominator = denominator;
        }

        private int Denominator
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() != 0);
                return _denominator;
            }
            set => _denominator = value;
        }

        private int Numerator { get; set; }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(Denominator != 0);
        }
    }
}