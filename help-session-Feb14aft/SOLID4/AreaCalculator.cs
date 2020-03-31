using System.Linq;

namespace SOLID
{
    public static class AreaCalculator
    {
        public static double TotalArea(IShape[] arrOfShapes) =>
            arrOfShapes.Sum(shape => shape.Area());
    }
}