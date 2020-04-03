// Example points with properties to access fields
// -----------------------------------------------------------------------------

using System;

namespace Points2
{
    internal class Point
    {
        // private access modifier: only visible in this class

        // using properties to get and set the contents of x and y
        public int PointX { get; set; }

        public int PointY { get; set; }

        // constructor with initialisation
        public Point(int x, int y)
        {
            PointX = x;
            PointY = y;
        }
    }

    internal static class Test
    {
        public static void Main()
        {
            var point1 = new Point(5, 10);
            var point2 = new Point(20, 15);
            Console.WriteLine($"Point1({point1.PointX}, {point1.PointY})");
            Console.WriteLine($"Point2({point2.PointX}, {point2.PointY})");

            point1.PointX += 10;
            Console.WriteLine("Increasing Point1's x val by 10 ...");
            Console.WriteLine($"Point1({point1.PointX}, {point1.PointY})");
        }
    }
}