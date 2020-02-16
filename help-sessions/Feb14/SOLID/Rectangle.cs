namespace SOLID
{
    public class Rectangle
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public double Area() => Height * Width;

        public static double TotalArea(Rectangle[] arrOfRectangles)
        {
            double area = 0.0;
            foreach (var rect in arrOfRectangles)
            {
                area += rect.Area();
            }

            return area;
        }
    }
}