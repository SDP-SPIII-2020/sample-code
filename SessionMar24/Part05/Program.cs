using System;
// closures and currying
namespace Part05
{
    public static class Program
    {
        public static void Main()
        {
            var inc = GetAFunc();
            Console.WriteLine(inc(5));
            Console.WriteLine(inc(6));
        }

        private static Func<int, int> GetAFunc()
        {
            var myVar = 1;

            int Increment(int var1)
            {
                myVar++;
                return var1 + myVar;
            }

            return Increment;
        }
    }
}