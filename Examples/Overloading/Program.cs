using System;

namespace Overloading
{
    class MainClass
    {
        public static void Main()
        {
            Complex c1 = new Complex(3, 1);
            Complex c2 = new Complex(1, 2);

            Console.WriteLine("c1 == c2: {0}", c1 == c2);
            Console.WriteLine("c1 != c2: {0}", c1 != c2);
            Console.WriteLine("c1 + c2 = {0}", c1 + c2);
            Console.WriteLine("c1 - c2 = {0}", c1 - c2);
            Console.WriteLine("c1 * c2 = {0}", c1 * c2);
            Console.WriteLine("c1 / c2 = {0}", c1 / c2);
        }
    }
}
