using System.Linq;

namespace SOLID
{
    public class AreaCalculator
    {
        public static double TotalArea(IShape[] arrOfShapes) =>
            arrOfShapes.Sum(rect => rect.Area());
    }
}