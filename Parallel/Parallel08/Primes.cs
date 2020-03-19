using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parallel08
{
    internal class Primes : IEnumerable
    {
        private static List<int> _allPrimes;
        private int _ctr = 0;

        // enumerator
        public IEnumerator GetEnumerator() => ((IEnumerable<int>) _allPrimes).GetEnumerator();

        // Build a list of all primes
        public Primes(int m)
        {
            _allPrimes = new List<int> {2};
            _ctr++;
            for (var n = 3; n < m; n += 2)
            {
                var isPrime = _allPrimes.All(p => n % p != 0);

                if (!isPrime) continue;
                _allPrimes.Add(n);
                _ctr++;
            }
        }
    }
}