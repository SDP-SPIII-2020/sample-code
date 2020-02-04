#define OLD

using System;

namespace Expressions
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(GetSalutation(DateTime.Now.Hour));
        }

        // imperative, mutates state to produce a result

#if OLD
        static string GetSalutation(int hour)
        {
            string salutation; // placeholder value
            if (hour < 12)
            {
                salutation = "Good Morning";
            }
            else
            {
                salutation = "Good Afternoon";
            }

            return salutation; // return mutated
        }
#else
        public static string GetSalutation(int hour) =>
            hour < 12 ? "Good Morning" : "Good Afternoon";
#endif
    }
}