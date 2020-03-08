namespace SOLID
{
    public class Square : ISquare
    {
        public Square() : this(1.0)
        {
        }

        public Square(double length)
        {
            Length = length;
        }

        public double Area() => Length * Length;

        public double Length { get; set; }
    }
}