using System;
using System.Collections;
using System.Collections.Specialized;

namespace GenThree
{
    class GenThree
    {
        static void Main(string[] args)
        {
            var items = GenerateNames();
            PrintNames(items);
        }

        static StringCollection GenerateNames() // function
        { // Flexibility - there isn't a collection for Widgets?
            StringCollection names = new StringCollection();
            names.Add("Fred");
            names.Add("Betty");
            names.Add("Colin");
            return names;
        }

        static void PrintNames(StringCollection names) // procedure
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Item is {name}");
            }
        }
    }
}