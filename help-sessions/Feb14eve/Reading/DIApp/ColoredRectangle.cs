namespace DIApp
{
    public class ColoredRectangle : IColorRectangle
    {
        /*
        public Rectangle() : this(1, 1)
        {}
        
        public Rectangle(int height): this(height, 1)
        {}
        */
        
        public ColoredRectangle(int height = 1 , int width = 1, string color = "red")
        {
            Height = height;
            Width = width;
            Color = color;
        }
        
        public double Height { get;}
        public double Width { get;}
        public string Color { get; }

        public override string ToString() => $"Height = {Height}, Width = {Width}, Color = {Color}";
    }
}