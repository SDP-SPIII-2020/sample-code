using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            IRectangle rect1 = new Rectangle();
            Console.WriteLine($"The area is {rect1.Area()}");
            IRectangle rect2 = new Rectangle(2, 2);
            ICircle circ1 = new Circle(1.5);
            ICircle circ2 = new Circle();
            ISquare sq = new Square(2.5);

            IShape[] arr = {rect1, rect2, circ1, circ2, sq};
            Console.WriteLine(AreaCalculator.TotalArea(arr));
        }
    }
}