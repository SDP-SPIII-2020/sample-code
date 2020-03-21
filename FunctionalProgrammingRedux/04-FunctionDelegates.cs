using System;

namespace FunctionalProgrammingRedux
{
    public static class FunctionDelegates
    {
#if X
        public static void Main(string[] args)
        {
            Func<int,int> multiplyByTwo = x => x * 2;
            Func<int, int, int> add = (x, y) => x + y;
            Func<int, bool> isEven = n => n % 2 == 0;
        }
#endif
    }
}