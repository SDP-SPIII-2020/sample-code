﻿using System;

namespace SOLID
{
    public class Circle : ICircle
    {
        public Circle() : this(1)
        {
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public double Area() => Math.PI * Radius * Radius;
    }
}