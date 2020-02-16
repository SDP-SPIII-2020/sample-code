using System;
using SOLID;

namespace SOLID02
{
    class Program
    {
        static void Main(string[] args)
        {
            IRectangle rect1 = new Rectangle();
            IRectangle rect2 = new Rectangle(2, 2);
            ICircle circ1 = new Circle(1.5);
            ICircle circ2 = new Circle();

            var arr = new[] {rect1, rect2};
            var carr = new[] {circ1, circ2};

            //Console.WriteLine(arr.GetType());
            Console.WriteLine(AreaCalculator.TotalArea(arr));
            //Console.WriteLine(AreaCalculator.TotalArea(carr));
        }
    }
}