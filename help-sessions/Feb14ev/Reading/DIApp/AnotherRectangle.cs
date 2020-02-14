namespace DIApp
{
    public class AnotherRectangle : IRectangle
    {
        public AnotherRectangle(int height = 1 , int width = 1)
        {
            Height = height;
            Width = width;
        }
        
        public double Height { get;}
        public double Width { get;}

        public override string ToString() => $"Another Rectangle is here - Height = {Height}, Width = {Width}";
    }
}