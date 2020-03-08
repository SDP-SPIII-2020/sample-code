namespace SOLID
{
    public class Rectangle : IRectangle
    {
        // public Rectangle() : this(1, 2)
        // {
        // }

        public Rectangle(double height= 1.0, double width=2.0) // removes the requirement for multiple cons
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public double Area() => Height * Width;
    }
}