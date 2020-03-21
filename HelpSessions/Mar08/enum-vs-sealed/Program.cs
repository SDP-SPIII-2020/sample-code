using System;
using System.Collections.Generic;

namespace Mar08
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{Things.First} and {Things.Second}");
            var athing = Things.First;
            Console.WriteLine($"{athing}");
            athing = Things.Second;
            Console.WriteLine($"{athing}");
            var al = new List<Things> {Things.First, Things.Third};
            foreach (var thing in al)
            {
                Console.WriteLine($"{thing}"); 
            }
            al.ForEach(x =>Console.WriteLine(x));
            
            IThings ithings = new First();
            Console.WriteLine(ithings.ToString()?.Substring(6));
        }
    }
}