using System;

namespace hashcode
{
    public static class HashCode
    {
        public static void Main(string[] args)
        {
            ImaginaryNumber imag = new ImaginaryNumber();
            Console.WriteLine(imag);
            var imagTwo = new ImaginaryNumber(1.0,1.0);
            
            Console.WriteLine(imag.GetHashCode());
            Console.WriteLine(imagTwo.GetHashCode());
            Console.WriteLine("-------------------");

            Console.WriteLine(imag.Equals((object)imagTwo));
            Console.WriteLine("-------------------");
            
            var result = imag.Equals(imagTwo);
            Console.WriteLine(result);
            Console.WriteLine("-------------------");
            
            result = imag == imagTwo; // they aren't identical objects
            Console.WriteLine(result);
            Console.WriteLine("-------------------");
            
            result = imag.Equals((1.0, 1.0));
            Console.WriteLine(result);
        }
    }
}