using System;

namespace SOLID
{
    public static class ShapeFactory
    {
        public static IShape GetInstance(string s, double item1 = 1.0, double item2 = 1.0, double item3 = 1.0 ) =>
            s switch
            {
                "Rectangle" => new NewRectangle(item1, item2),
                "Square" => new Square(item1),
                _ => null
            };
    }
}