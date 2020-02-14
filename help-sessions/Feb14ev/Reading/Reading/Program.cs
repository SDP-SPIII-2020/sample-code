using System;

namespace Reading
{
    class Program
    {
        private const string END = "end";
        
        static void Main(string[] args)
        {
            #if ORIG
            Console.Write("Type 'end' to exit: ");
            var str = Console.ReadLine();
            while (!str.Equals(END))
            {
                Console.WriteLine($"Value is '{str}'");
                Console.Write("Type 'end' to exit: ");
                str = Console.ReadLine();
            }
            #else
            do
            {
                Console.Write("Input a string: ");
                var str = Console.ReadLine();
                if (str == null) break;
                Console.WriteLine($"Value is '{str}'");
            } while (true);
#endif
        }
    }
}