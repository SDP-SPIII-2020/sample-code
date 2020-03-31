// A function that accepts another function as a parameter, or returns another function.

using System;
using System.Collections;

namespace HOF
{
    class Program
    {
        int IEnumerable.Count<T>(Func<T, bool> predicate)
        {
            int count = 0;
            foreach (T element in source)
            {
                checked // overflow exception check
                {
                    if (predicate(element)) // func<T,Bool> invoked
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}