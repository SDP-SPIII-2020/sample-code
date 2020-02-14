namespace SOLID
{
    public class Rectangle : IRectangle
    {
        public Rectangle() : this(1, 2)
        {
        }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public double Area() => Height * Width;
    }
}