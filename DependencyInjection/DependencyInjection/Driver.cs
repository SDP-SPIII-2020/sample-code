using System;
namespace DemoApp
{
    class Driver
    {
        static void Main(string[] args)
        {
            new TodayWriter(new ConsoleOutput()).WriteDate();
        }
    }
}
