using System;

// Example points with properties to access fields

namespace Properties
{
    internal class Point
    {
        // using properties to get and set the contents
        public int PointX { get; set; }
        public int PointY { get; set; }

        // constructor with initialisation
        public Point(int x, int y)
        {
            PointX = x;
            PointY = y;
        }
    }

    public static class Program
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