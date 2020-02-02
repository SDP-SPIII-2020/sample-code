// set value based upon which example you wish to run

// #define PUBLIC
// #define GET

#define PROP

using System;

namespace PropertiesExample
{
    #region Example using publicly accessible fields

#if PUBLIC
    class Point
    {
        // public access modifier: no restrictions on access 
        public int x;
        public int y;

        // constructor with initialisation
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Test
    {
        public static void Main()
        {
            Point point1 = new Point(5, 10);
            Point point2 = new Point(20, 15);
            Console.WriteLine($"Point1({point1.x}, {point1.y})");
            Console.WriteLine($"Point2({point2.x}, {point2.y})");
        }
    }
#endif

    #endregion

    #region Example using private fields with explicit get function

#if GET
    class Point
    {
        // private access modifier: only visible in this class
        private int x;
        private int y;

        // constructor with initialisation
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // methods for read-access to these values
        public int GetX()
        {
            return (x);
        }

        public int GetY()
        {
            return (y);
        }
    }

    class Test
    {
        public static void Main()
        {
            // NB: because we don't have methods for write-access, 
            //     x and y won't change after initialisation, i.e. they are immutable
            Point point1 = new Point(5, 10);
            Point point2 = new Point(20, 15);
            Console.WriteLine($"Point1({point1.GetX()}, {point1.GetY()})");
            Console.WriteLine($"Point2({point2.GetX()}, {point2.GetY()})");
            // NB: this doesn't work, because x and y are private in the Point class; try it!
            // Console.WriteLine("Point1({0}, {1})", point1.x, point1.y);
            // Console.WriteLine("Point2({0}, {1})", point2.x, point2.y);
        }
    }
#endif

    #endregion

    #region Example points with properties to access fields

#if PROP
    class Point
    {
        // private access modifier: only visible in this class
        private int x;
        private int y;

        // using properties to get and set the contents of x and y
        // Q: is there a shorter way to write this code?
        public int PointX
        {
            get { return x; }
            set { this.x = value; } // illustrates the "value" keyword
        }

        public int PointY
        {
            get { return y; }
            set { this.y = value; }
        }

        // constructor with initialisation
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Test
    {
        public static void Main()
        {
            Point point1 = new Point(5, 10);
            Point point2 = new Point(20, 15);
            // this doesn't work, because x and y are private in the Point class; try it!
            // Console.WriteLine("Point1({0}, {1})", point1.x, point1.y);
            // Console.WriteLine("Point2({0}, {1})", point2.x, point2.y);
            Console.WriteLine($"Point1({point1.PointX}, {point1.PointY})");
            Console.WriteLine($"Point2({point2.PointX}, {point2.PointY})");
            point1.PointX += 10;
            Console.WriteLine("Increasing Point1's x val by 10 ...");
            Console.WriteLine($"Point1({point1.PointX}, {point1.PointY})");
        }
    }
#endif

    #endregion
}