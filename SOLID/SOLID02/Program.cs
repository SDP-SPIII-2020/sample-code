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

            IRectangle[] arr = new[] {rect1, rect2};
            ICircle[] carr = new[] {circ1, circ2};
            
            Console.WriteLine(AreaCalculator.TotalArea(arr));
           // Console.WriteLine(AreaCalculator.TotalArea(carr));
        }
    }
}