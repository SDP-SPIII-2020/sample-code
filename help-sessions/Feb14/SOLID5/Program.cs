#define NAME
using System;

namespace SOLID
{
    class Program
    {
#if NAME
        static void Main(string[] args)
        {
            IRectangle rect1 = (IRectangle) ShapeFactory.GetInstance("Rectangle", 3, 4);
            Console.WriteLine($"The area is {rect1.Area()}");
            IRectangle rect2 = (IRectangle) ShapeFactory.GetInstance("Rectangle");
            ICircle circ1 = new Circle(1.5);
            ICircle circ2 = new Circle();
            ISquare sq = //new Square(2.5);
                (ISquare) ShapeFactory.GetInstance("Square", 3);
//            IRectangle ir = new NewRectangle();

            IShape[] arr = {rect1, rect2, circ1, circ2, sq};

            foreach (var shape in arr)
            {
                Console.WriteLine(shape);
            }
        }
#endif
    }
}