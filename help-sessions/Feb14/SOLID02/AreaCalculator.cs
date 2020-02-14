using System.Linq;
using SOLID;

namespace SOLID02
{
    public class AreaCalculator
    {
        public static double TotalArea(IRectangle[] arrOfRectangles)
        {
            return arrOfRectangles.Sum(rect => rect.Area());
        }
    }
}