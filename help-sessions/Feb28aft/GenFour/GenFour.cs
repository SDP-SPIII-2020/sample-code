using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace GenFour
{
    class GenFour
    {
        static void Main(string[] args)
        {
            var items = GenerateNames();
            PrintNames(items);
        }

        static List<string> GenerateNames() // function
        { // Introduce Generics?
            List<string> names = new List<string>();
            names.Add("Fred");
            names.Add("Betty");
            names.Add("Colin");
            return names;
        }

        // actual and formal parameter lists (parameters)
        // 
        static void PrintNames(List<string> names) // procedure
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Item is {name}");
            }
        }
    }
}