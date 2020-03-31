using System;

namespace GenericDelegateConstraints
{
    static class Extend
    {
        public static TDelegate TypeSafeCombine<TDelegate>(this TDelegate source, TDelegate target)
            where TDelegate : System.Delegate
            => Delegate.Combine(source, target) as TDelegate;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Action first = () => Console.WriteLine("this");
            Action second = () => Console.WriteLine("that");

            var combined = first.TypeSafeCombine(second);
            combined();

            Func<bool> test = () => true;
            // Combine signature ensures combined delegates must have the same type.
            //var badCombined = first.TypeSafeCombine(test);
        }
    }
}