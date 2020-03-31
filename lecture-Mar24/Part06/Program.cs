using System;
using System.Runtime.InteropServices.ComTypes;

// Partial application of functions (currying)

namespace Part06
{
    public static class Program
    {
        public static void Main()
        {
            Func<int, int, int, string> function = SimpleFunction;

            var result1 = function(1, 2, 3);

            Func<int, Func<int, Func<int, string>>> f1 = Curry(function);
            Func<int, Func<int, string>> f2 = f1(1);
            Func<int, string> f3 = f2(2);
            var result2 = f3(3);
            
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            
            //
            var curried = Curry(function);
            var result3 = curried(1)(2)(3);
            Console.WriteLine(result3);

            #region X

            // Partial application of "function"
            // Func<int, int, string> partial1 = ApplyPartial(function, 1);
            // Func<int, string> partial2 = ApplyPartial(partial1, 2);
            // Func<string> partial3 = ApplyPartial(partial2, 3);
            // Console.WriteLine(partial1(2, 3));

            //Console.WriteLine(function.Invoke(1, 2, 3));

            // DoIt(DoubleIt,3);
            // DoIt(CubeIt,3);
            //
            // Func<int, int> thing = DoubleIt;
            // DoIt(thing,3);
            // thing = CubeIt;
            // DoIt(thing, 4);

            #endregion
        }

        static Func<T1, Func<T2, Func<T3, Tresult>>> Curry<T1, T2, T3, Tresult>
            (Func<T1, T2, T3, Tresult> funct) => a => b => c => funct(a, b, c);
        
        
        static Func<T2, T3, TResult> ApplyPartial<T1, T2, T3, TResult>
            (Func<T1, T2, T3, TResult> funct, T1 arg1) =>
            (b, c) => funct(arg1, b, c);

        static string SimpleFunction(int a, int b, int c) => $"a = {a}, b = {b}, c = {c}";

        static void DoIt(Func<int, int> f, int item)
        {
            Console.WriteLine(f(item));
            Console.WriteLine(f(item + 1));
        }


        static int DoubleIt(int i) => i * i;
        static int CubeIt(int i) => i * i * i;
    }
}