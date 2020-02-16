using System;
using System.Linq;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            IRectangle rect1 = ShapeFactory.GetInstance("Rectangle", 3, 4) as IRectangle;
            Console.WriteLine($"The area is {rect1.Area()}");
            IRectangle rect2 = ShapeFactory.GetInstance("Rectangle") as IRectangle;
            // "as" - type cast without exceptions
            // ICircle circ1 = new Circle(1.5);
            // ICircle circ2 = new Circle();
            ISquare sq = ShapeFactory.GetInstance("Square", 3) as ISquare;

            //IRectangle ir = new NewRectangle();

            IShape[] arr = {rect1, rect2, sq};

            arr.ToList().ForEach(Console.WriteLine);
        }
    }
}