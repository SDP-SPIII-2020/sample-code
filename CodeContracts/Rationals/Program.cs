// From Code contract user manual:
// http://download.microsoft.com/download/C/2/7/C2715F76-F56C-4D37-9231-EF8076B7EC13/userdoc.pdf
// Example of pre-conditions, post-conditions, and invariants

#define CONTRACTS_FULL

namespace Rationals
{
    public static class ContractExampleMain
    {
        public static void Main()
        {
            var goodRat = new Rational(3, 2);
            var badRat = new Rational(3, 0);
        }
    }
}