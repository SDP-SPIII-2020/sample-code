namespace Delegates2
{
    public class Twice
    {
        // delegate, specifying the type of the function argument
        public delegate int Worker(int i);

        // the higher-order function twice applies the worker function twice
        public static int twice(Worker worker, int x)
        {
            return worker(worker(x));
        }
    }
}