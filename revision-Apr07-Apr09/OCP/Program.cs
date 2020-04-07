using System;
using System.Linq;

namespace OpenClosed
{
        internal class Rectangle
        {
            internal double Height { get; set; }
            internal double Width { get; set; }
        }

        // internal class AreaCalculation
        // {
        //     public double TotalArea(Rectangle[] arrRect) =>
        //         arrRect.Sum(rect => rect.Height * rect.Width);
        // }

        internal class Circle
        {
            public double Radius { get; set; }
        }

        internal class AreaCalculation
        {
            public double TotalArea(object[] arrObj)
            {
                var area = 0.0;
                foreach (var obj in arrObj)
                {
                    if (obj is Rectangle)
                    {
                        var rect = (Rectangle) obj;
                        area += rect.Height * rect.Width;
                    }
                    else
                    {
                        var circ = (Circle) obj;
                        area += circ.Radius * circ.Radius * Math.PI;
                    }
                }

                return area;
            }
        }

    public static class Program
    {
        public static void Main(string[] args)
        {
            // nothing
        }
    }
}