// From Code contract user manual: http://download.microsoft.com/download/C/2/7/C2715F76-F56C-4D37-9231-EF8076B7EC13/userdoc.pdf
// Figure 1: Example of preconditions, postconditions, and invariants

#define CONTRACTS_FULL

using System;
using System.Diagnostics.Contracts;

namespace ContractExample {

 class Rational {

    int numerator;
    int denominator;

    public Rational ( int numerator, int denominator)
    {
      Contract.Requires( denominator != 0 );

      this.numerator = numerator;
      this.denominator = denominator;
    }

    public int Denominator {
      get {
       Contract.Ensures( Contract.Result<int>() != 0 );
       return this .denominator;
     }
    }

  [ContractInvariantMethod]
  void ObjectInvariant () {
    Contract. Invariant ( this .denominator != 0 );
  }
 }

 class ContractExampleMain {
  public static void Main () {
    Rational goodRat = new Rational(3,2);
    Rational badRat = new Rational(3,0);
  }
 }
}
