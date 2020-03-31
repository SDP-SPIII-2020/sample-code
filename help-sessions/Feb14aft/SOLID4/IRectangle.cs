namespace SOLID
{
    public interface IRectangle : IShape
    {
        double Height { get; set; }
        double Width { get; set; }
    }
}