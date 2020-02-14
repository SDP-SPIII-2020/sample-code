using System;
using System.Linq;

namespace DIApp
{
    class Program
    {
        static void Main(string[] args) // java MyClass these are the arguments
        {
            IRectangle[] rect = {
                RectangleFactory.GetInstance(5),
                new AnotherRectangle(1, 2), 
                new Rectangle(5),
                new ColoredRectangle(), 
                RectangleFactory.GetInstance(),
                RectangleFactory.GetInstance(1,2)
            };
            
            rect.ToList().ForEach(Console.WriteLine);
        }
    }
}