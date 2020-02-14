using System;

namespace DIApp
{
    public static class RectangleFactory
    {
        private static Random r = new Random();

        public static IRectangle GetInstance(params int[] args)
        //public static IRectangle GetInstance(int arg1 = 1, int arg2 = 1)
        {
            if (r.Next(0, 10) > 5)
            {
                return new Rectangle();
            }
            return new AnotherRectangle();
        }
    }
}