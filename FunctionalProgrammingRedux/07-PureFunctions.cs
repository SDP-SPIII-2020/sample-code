using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FunctionalProgrammingRedux
{
    public class PureFunctions
    {
        public static void Main(string[] args)
        {
            // var johndoe = new Person("John", "Doe");
            // Console.WriteLine(Person.Greet(johndoe));
            // Console.WriteLine(Person.Greet(johndoe, "Hello!"));
            // Console.WriteLine(Person.GreetWithTime(johndoe));
            // Thread.Sleep(600);
            // Console.WriteLine(Person.GreetWithTime(johndoe));
            // Thread.Sleep(600);
            // Console.WriteLine(Person.GreetWithTime(johndoe));

            var names = new List<string>() {"Alex", "Michael", "Trevor", "Igor"};
            int counter = 1;

            string Format(string s) => $"({counter++}) {s}"; // string -> string

            // List<string> result = names
            //     .Select(x => x.ToUpper())
            //     .Select(Format)
            //     .ToList();
            //
            // result.ForEach(Console.WriteLine);

            List<string> res = names
                .AsParallel()
                .Select(x => x.ToUpper())
                .Select(Format)
                .ToList();
            res.ForEach(Console.WriteLine);

            int Sum(int upper) // int -> int 
            {
                var sum = 0; // local side-effect --- not visible from the outside
                for (var i = 0; i < upper; i++)
                {
                    sum += i;
                }

                return sum;
            } // Even though this function has local side-effects it is still "pure"
        }

        // string GetPrefix(int age) // int -> string
        // {
        //     if (age < 0 || age > 150)
        //     {
        //         return null;
        //     }
        //
        //     return age < 18 ? "child" : "adult";
        // } // dishonest function int -> string | null
        //
        // int Divide(int x, int y) => x / y; // int, int -> int
        // // dishonest int,int -> int | Exception
    }

    class Person
    {
        private string FirstName { get; }
        private string Surname { get; }

        public Person(string first, string second)
        {
            FirstName = first;
            Surname = second;
        }

        public static string Greet(Person person, string greeting = "Aha!") =>
            $"{greeting}, {person?.FirstName} {person?.Surname}";
        // Null-conditional operators "?." and "?[]"
        // "?." is for member access
        // "?[]" is for element access

        public static string GreetWithTime(Person person, string greeting = "Doh!") =>
            $"{greeting}, {person?.FirstName} {person?.Surname}. Current time is {DateTime.Now}";
    }
}

// The signature of an honest function must tell the reader all the information about the possible
// input types/constraints and the possible output outcomes.

// Pure functions - is a function with no side effects and its result is solely determined by
// its input arguments.

// Examples of side-effects:
//   Changing global state
//   Changing the arguments ("out")
//   Performing I/O
//   A less obvious one - the current time?!?

// Predictably 