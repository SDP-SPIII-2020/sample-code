// Example using private fields with explicit get function
// -----------------------------------------------------------------------------

using System;

namespace Points1
{
    internal class Point
    {
        // private access modifier: only visible in this class
        private readonly int _x;
        private readonly int _y;

        // constructor with initialisation
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // methods for read-access to these values
        public int GetX() => _x;

        public int GetY() => _y;
    }

    public static class Test
    {
        public static void Main()
        {
            // NB: because we don't have methods for write-access, 
            //     x and y won't change after initialisation, i.e. they are immutable
            var point1 = new Point(5, 10);
            var point2 = new Point(20, 15);
            Console.WriteLine($"Point1({point1.GetX()}, {point1.GetY()})");
            Console.WriteLine($"Point2({point2.GetX()}, {point2.GetY()})");

            // NB: this doesn't work, because x and y are private in the Point class; try it!
            // Console.WriteLine("Point1({0}, {1})", point1.x, point1.y);
            // Console.WriteLine("Point2({0}, {1})", point2.x, point2.y);
        }
    }
}