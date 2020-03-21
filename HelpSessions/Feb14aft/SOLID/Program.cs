using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            var r1 = new Rectangle {Height = 2.0, Width = 4.0};
            var r2 = new Rectangle {Height = 1.5, Width = 2};

            var rectangles = new[] {r1, r2};

            Console.WriteLine($"Total area of rectangles is {Rectangle.TotalArea(rectangles)}");
        }
    }
}