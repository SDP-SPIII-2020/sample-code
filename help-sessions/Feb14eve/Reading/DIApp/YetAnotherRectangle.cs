namespace DIApp
{
    public class YetAnotherRectangle : IRectangle
    {
        public YetAnotherRectangle(int height = 1 , int width = 1)
        {
            Height = height;
            Width = width;
        }
        
        public double Height { get;}
        public double Width { get;}

        public override string ToString() => $" Yet Another Rectangle Height = {Height}, Width = {Width}";
    }
}