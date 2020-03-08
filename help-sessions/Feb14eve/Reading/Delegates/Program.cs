using System;
using System.Linq;

namespace Delegates
{
    delegate void AFunction(string s);

    delegate int AnyFunction(int i, int j);
    
    class Program
    {
        static void Main(string[] args)
        {
            var s = "Fred"; 
            //Hello(s);
            //InBetween(s);
            //Goodbye(s);

            AFunction af;
            //AFunction[] afarr = {Hello, InBetween, Goodbye};
            //afarr.ToList().ForEach(x => x(s));

            af = Hello;
            af += InBetween;
            af += Goodbye;

            af(s);
            af -= Hello; // dangerous
            af(s);

            AnyFunction anyf = Add;
            anyf += Multiply;

            anyf(3, 4);
        }

        static void Hello(string s) => Console.WriteLine($"Hello {s}");
        static void Goodbye(string s) => Console.WriteLine($"Goodbye {s}!");
        static void InBetween(string s) => Console.WriteLine($"Cup of coffee {s}?");

        static int Add(int i, int j)
        {
            var answer = i + j;
            Console.WriteLine(answer);
            return answer;
        }

        static int Multiply(int i, int j)
        {
            var answer = i * j;
            Console.WriteLine(answer);
            return answer;
        }

    }
}