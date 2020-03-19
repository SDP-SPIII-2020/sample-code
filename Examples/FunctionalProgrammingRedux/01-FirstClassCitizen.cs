using System;
using System.Linq;

namespace FunctionalProgrammingRedux
{
#if X
    public static class FirstClassCitizen
    {
        public static void Main(string[] args)
        {
            Func<int, bool> isEven = x => x % 2 == 0;
            var list = Enumerable.Range(1, 10);
            // pass isEven as an argument to Where
            var even = list.Where(isEven);
            even.ToList().ForEach(Console.WriteLine);
        }
    }
#endif
}


// OO - all about protecting the data - the data is king/queen
// FP - its all about the computation

// FP

// Functions as first-class values
// Avoiding changing state and emphasise immutable data

// int -> bool