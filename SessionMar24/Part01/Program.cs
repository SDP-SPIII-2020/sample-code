using System;
using System.Linq;

namespace SessionMar24
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // var a = Enumerable.Range(1, 100)
            //     .Where(i => i % 20 == 0)
            //     .OrderBy(i => -i)
            //     .Select(i => $"{i}% ");
            //
            // a.ToList().ForEach(Console.WriteLine);
            
            Func<int,string> aFunc = (x) => $"Number: {x}";
            Console.WriteLine(aFunc(3));
            Console.WriteLine(AFunction(3));

            //delegate string FuncTwo(int i)
        }

        private static string AFunction(int i)
        {
            return $"Number: {i}";
        }
    }
}

// Algebraic Data Types

interface IPerson
{
}

sealed class Student : IPerson
{
}

sealed class Lecturer : IPerson
{
    
}

// map  -> function is a mapping between two sets - the input set (domain) - the result set (codomain)

// These are examples of delegates - lambda functions in other words.

// Func<string, int> -> function takes a string and returns an int
// Action<int> -> function takes an int and returns void

// string -> int --- Haskell

// char -> char


