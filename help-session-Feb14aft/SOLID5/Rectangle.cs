namespace SOLID
{
    public class Rectangle : IRectangle
    {
      public Rectangle(double height = 1.0, double width = 1.0)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public double Area() => Height * Width;
    }
}