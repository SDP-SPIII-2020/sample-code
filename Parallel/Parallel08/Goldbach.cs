using System;
using System.Threading.Tasks;

namespace Parallel08
{
    public class Goldbach
    {
        public static bool GoldbachNaive(int m)
        {
            var primes = new Primes(m);
            var found = false;

            for (var n = 4; n < m; n += 2)
            {
                found = false;
                foreach (int p in primes)
                {
                    foreach (int q in primes)
                    {
                        if (n == p + q)
                        {
                            found = true;
                        }
                    }

                    if (found) break;
                }

                if (!found) break;
            }

            return found;
        }

        public static bool GoldbachPar(int m, int proc)
        {
            // initialise list of primes eagerly
            var primes = new Primes(m);
            object foundLock = new object();
            var globalFound = false;

            /* Parallel version, using only k tasks */
            var options = new ParallelOptions() {MaxDegreeOfParallelism = proc};

            // for (int n = 4; n<m; n+=2) {
            Parallel.For(4, m, options, (n, loopState) =>
            {
                bool found = false; // thread-local
                foreach (int p in primes)
                {
                    foreach (int q in primes)
                    {
                        if (n == p + q)
                        {
                            found = true;
                        }
                    }

                    if (found)
                    {
                        lock (foundLock)
                        {
                            globalFound = true;
                        }

                        ;
                        loopState.Break();
                    }
                }

                if (!found) loopState.Break();
                n++;
            });
            return globalFound;
        }
    }
}