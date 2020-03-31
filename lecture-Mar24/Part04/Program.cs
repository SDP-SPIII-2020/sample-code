using System;

namespace Part04
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var p = new Pair(3, 4);
        }
    }

    class Pair
    {
        public Pair(int a, int b) // an operator -- just like + is for those whole numbers
        {
            A = a;
            B = b;
        }

        int A { get; set; }
        int B { get; set; }
    }

    interface Idirection
    {
    }

    sealed class North : Idirection
    {
    }

    sealed class West : Idirection
    {
    }
    
    // enumerated type?
}