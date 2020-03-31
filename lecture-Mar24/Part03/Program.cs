using System;
using System.Linq;

namespace Part03
{
    public static class Program
    {
        public static void Main()
        {
            var i = Enumerable.Range(1, 3);
            i.ToList().ForEach(Console.WriteLine);

            var j = Enumerable.Zip(
                new [] {1,2,3},
                new [] {"ichi", "ni", "san"},
                (number, name) => $"In Japanese, {number} is {name}" // NameThing?
            );
            j.ToList().ForEach(Console.WriteLine);
        }

        public static string NameThing(int number, string name) => $"In Japanese, {number} is {name}";
    }
}

// In Functional Programming you usually end up with lots of little functions
// In Object-Oriented Programming you usually end up with lots of small interfaces