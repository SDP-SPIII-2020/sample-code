/*
 * Func Delegates encapsulate a method.
 * When declaring a Func, input and output parameters
 * are specified as T1-T16, and TResult.
 */

/*
 * Func<TResult> – matches a method that takes no arguments, and returns value of type TResult.
 * Func<T, TResult> – matches a method that takes an argument of type T, and returns value of type TResult.
 * Func<T1, T2, TResult> – matches a method that takes arguments of type T1 and T2, and returns value of type TResult.
 * Func<T1, T2, ..., TResult> – and so on up to 16 arguments, and returns value of type TResult.
 */

using System;

namespace FunctionDelegates
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> addOne = n => n + 1;
            Func<int, int, int> addNums = (x, y) => x + y;
            Func<int, bool> isZero = n => n == 0;

            Console.WriteLine(addOne(5)); // 6
            Console.WriteLine(isZero(addNums(-5, 5))); // True
        }
    }
}