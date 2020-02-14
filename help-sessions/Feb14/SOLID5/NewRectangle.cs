namespace SOLID
{
    public class NewRectangle : IRectangle
    {
        public NewRectangle(double height = 1.0, double width = 2.0)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public double Area() => Height * Width;

        public override string ToString() => $"Width: {Width} Height: {Height}";
    }
}