using System;

namespace example03
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var collection = new SweetBag
            {
                [0] = new Sweet("Red"),
                [1] = new Sweet("Blue"),
                [2] = new Sweet("Yellow"),
                [3] = new Sweet("Green"),
                [4] = new Sweet("Blue"),
                [5] = new Sweet("Red"),
            };

            // Create iterator
            var iterator = collection.CreateIterator();

            Console.WriteLine("Here are all the sweets...");

            for (var item = iterator.First();
                !iterator.IsDone;
                item = iterator.Next())
            {
                Console.WriteLine(item.Colour);
            }
        }
    }
}