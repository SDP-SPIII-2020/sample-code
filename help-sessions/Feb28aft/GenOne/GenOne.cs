using System;

namespace GenOne
{
    class GenOne
    {
        static void Main(string[] args)
        {
            var items = GenerateNames();
            PrintNames(items);
        }

        static string[] GenerateNames() // function
        { // need to know the size of the array at creation time
            string[] _names = new string[3];
            _names[0] = "Fred";
            _names[1] = "Betty";
            _names[2] = "Colin";
            return _names;
        }

        static void PrintNames(string[] names) // procedure
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Item is {name}");
            }
        }
    }
}