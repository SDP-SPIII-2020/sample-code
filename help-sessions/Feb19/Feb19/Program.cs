using System;

namespace Feb19
{
    class Program
    {
        static void Main(string[] args)
        {
            ABoringOldClass ab1 = new ABoringOldClass();
            Console.WriteLine(ab1);
            ABoringOldClass ab2 = new ABoringOldClass(3,4);
            Console.WriteLine(ab2);
            ab2.SetI(12);
            ab2.SetJ(13);
            Console.WriteLine(ab2);
            ab2.SetI(21);
            Console.WriteLine($"The modified I is {ab2.GetI()}");
        }
    }
}