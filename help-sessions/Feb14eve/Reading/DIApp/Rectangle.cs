namespace DIApp
{
    public class Rectangle : IRectangle
    {
        /*
        public Rectangle() : this(1, 1)
        {}
        
        public Rectangle(int height): this(height, 1)
        {}
        */
        
        public Rectangle(int height = 1 , int width = 1)
        {
            Height = height;
            Width = width;
        }
        
        public double Height { get;}
        public double Width { get;}

        public override string ToString() => $"Height = {Height}, Width = {Width}";
    }
}