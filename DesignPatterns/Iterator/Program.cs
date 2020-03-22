using System;

namespace Iterator
{
    public static class Program
    {
        public static void Main()
        {
            var a = new ConcreteAggregate<string>
            {
                [0] = "String one", [1] = "String two", [2] = "String three", [3] = "String four"
            };

            var iter = a.CreateIterator();
            
            Console.WriteLine("Iterating over the items...");
            var item = iter.First();

            while (item != null)
            {
                Console.WriteLine($"Item is {item}");
                item = iter.Next();
            }
        }
    }
}