using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int> {1, 2, 3, 4, 5};

            // Imperative style of programming is verbose
            List<int> results = new List<int>();
            foreach (var num in collection)
            {
                if (num % 2 != 0)
                    results.Add(num);
            }

            results.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            // Declarative is more concise
            collection.Where(num => num % 2 != 0).ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }
    }
}