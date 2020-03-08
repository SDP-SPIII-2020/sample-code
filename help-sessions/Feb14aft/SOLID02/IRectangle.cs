namespace SOLID
{
    public interface IRectangle
    {
        double Height { get; set; }
        double Width { get; set; }
        double Area();
    }
}