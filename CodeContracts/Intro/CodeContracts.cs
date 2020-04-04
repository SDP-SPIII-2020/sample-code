#undef CONTRACTS_FULL
#define DEBUG

using System;
using System.Diagnostics.Contracts;

namespace CodeContracts
{
    internal static class CodeContracts
    {
        public static void Main()
        {
            int[] goodArr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Contract.Assert(goodArr.Length > 0); // example of a property that must hold here
            Console.WriteLine("Success: array has a length > 0, namely " + goodArr.Length);
            Contract.Assert(Contract.ForAll(goodArr, x => x >= 0)); // example of quantifying 

            // int[] badArr = { };
            // Contract.Assert(badArr.Length > 0); // should fail!
        }
    }
}