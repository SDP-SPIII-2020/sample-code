using System.Linq;
using SOLID;

namespace SOLID
{
    public class AreaCalculator
    {
        public static double TotalArea(IShape[] arrOfShapes) =>
            arrOfShapes.Sum(shape => shape.Area());
    }
}