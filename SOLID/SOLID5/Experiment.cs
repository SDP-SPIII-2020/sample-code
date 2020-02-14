using System;

namespace SOLID
{
    public class Experiment
    {
        static int Main()
        {
            Console.WriteLine(new NewRectangle());
            Console.WriteLine(new NewRectangle(1.5));
            Console.WriteLine(new NewRectangle(1.0, 2.0));
            return 1;
        }
    }
}