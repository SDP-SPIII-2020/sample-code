//#define OLD

using System;
using System.Reflection;

namespace Immutable
{
    // Before
    public class Rectangle
    {
        internal int Length { get; set; }
        internal int Height { get; set; }

        public void Grow(int length, int height)
        {
            Length += length;
            Height += height;
        }
    }


// After
    public class ImmutableRectangle
    {
        internal int Length { get; }
        internal int Height { get; }

        public ImmutableRectangle(int length, int height)
        {
            Length = length;
            Height = height;
        }

        public ImmutableRectangle Grow(int length, int height) =>
            new ImmutableRectangle(Length + length, Height + height);
    }

    internal static class Harness
    {
        static void Main()
        {
#if OLD
            Rectangle r = new Rectangle();
            r.Length = 5;
            r.Height = 10;
            r.Grow(10, 10); // r.Length is 15, r.Height is 20, same instance of r
            Console.WriteLine(r.Length + " and " + r.Height);
#else
            ImmutableRectangle r = new ImmutableRectangle(5, 10);
            r = r.Grow(10, 10); // r.Length is 15, r.Height is 20, is a new instance of r
            Console.WriteLine(r.Length + " and " + r.Height);
#endif
        }
    }
}