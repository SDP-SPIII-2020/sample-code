using System.Threading.Tasks;

namespace Parallel05
{
    internal static class Futures
    {
        private static int Fib(int n)
        {
            switch (n)
            {
                case 0:
                case 1:
                    return 1;
                default:
                {
                    var n1 = Fib(n - 1);
                    var n2 = Fib(n - 2);
                    return n1 + n2;
                }
            }
        }

        private static int F1(int n) => Fib(n);

        private static int F2(int n) => n + 1; // Next(n);}

        private static int F3(int n) => Fib(n);

        private static int F4(int m, int n) => m + n;

        public static int SeqCode(int a)
        {
            var b = F1(a);
            var c = F2(a);
            var d = F3(c);
            var f = F4(b, d);
            return f;
        }

        public static int ParCode(int a)
        {
            // construct a future generates potential parallelism
            var futureB = Task.Factory.StartNew<int>(() => F1(a));
            var c = F2(a);
            var d = F3(c);
            var f = F4(futureB.Result, d);
            return f;
        }
    }
}