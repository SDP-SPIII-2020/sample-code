using System.Linq;
using SOLID;

namespace SOLID
{
    public class AreaCalculator
    {
        public static double TotalArea(IShape[] arrOfShapes)
        {
            return arrOfShapes.Sum(rect => rect.Area());
        }
    }
}