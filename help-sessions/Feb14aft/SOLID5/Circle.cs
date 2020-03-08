using System;

namespace SOLID
{
    public class Circle : ICircle
    {
      public Circle(double radius = 1.0)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public double Area() => Math.PI * Radius * Radius;
    }
}