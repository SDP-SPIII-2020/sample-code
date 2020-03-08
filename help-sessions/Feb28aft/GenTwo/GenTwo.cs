using System;
using System.Collections;

namespace GenTwo
{
    class GenTwo
    {
        static void Main(string[] args)
        {
            var items = GenerateNames();
            PrintNames(items);
        }

        static ArrayList GenerateNames() // function
        { // What if the ArrayList contains a non-string?
            ArrayList _names = new ArrayList();
            _names.Add("Fred");
            _names.Add("Betty");
            _names.Add("Colin");
            _names.Add(3);
            return _names;
        }

        static void PrintNames(ArrayList names) // procedure
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Item is {name}"); // as string produces unexpected results
            }
        }
    }

    static class Int32Extension
    {
        static string Int32ToString(this Int32 val) => val.ToString();
    }
    
}