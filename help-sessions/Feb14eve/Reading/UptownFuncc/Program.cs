using System;

namespace UptownFuncc
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = (x, y) => x + y;
            Func<string> returner = () => "gadsgadsggasd";
            Func<string, int, int> myFunc = (x, y) => Convert.ToInt32(x) + y;
            Console.WriteLine(add(3,4));
            Console.WriteLine(returner());
            Console.WriteLine(myFunc("3",4));

            Action<string> consume = x => Console.WriteLine(x);
            consume("Eat...");
            (int x, int y) = aMethod();
            Console.WriteLine($" {x} and {y}");
            var tuple = aMethod();
            Console.WriteLine($" {tuple.Item1} and {tuple.Item2}");
        }

        static (int, int) aMethod()
        {
            return (3, 4);
        }
    }
}