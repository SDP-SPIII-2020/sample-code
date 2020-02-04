using System;

namespace Composition
{
    public static class Extensions
    {
        public static Func<T, TReturn2> Compose<T, TReturn1, TReturn2>(this Func<TReturn1, TReturn2> func1,
            Func<T, TReturn1> func2)
        {
            return x => func1(func2(x));
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            Func<int, int> square = (x) => x * x;
            Func<int, int> negate = x => x * -1;
            Func<int, string> toString = s => s.ToString();
            Func<int, string> squareNegateThenToString = toString.Compose(negate).Compose(square);

            Console.WriteLine(squareNegateThenToString(2));
        }
    }
}