using System;
using System.Linq;

namespace OCP_revised
{
    public interface IShape
    {
        public double Area();
    }

    internal class Rectangle : IShape
    {
        internal double Height { get; set; }
        internal double Width { get; set; }
        public double Area() => Height * Width;
    }

    internal class Circle : IShape
    {
        public double Radius { get; set; }
        public double Area() => Radius * Radius * Math.PI;
    }

    internal class AreaCalculation
    {
        public double TotalArea(IShape[] arrObj) =>
            arrObj.Sum(obj => obj.Area());
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            // nothing
        }
    }
}