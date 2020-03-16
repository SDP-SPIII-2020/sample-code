using System.Threading;
using System;

namespace Threads0
{
    public class Program
    {
        private int _x = 5;
        private int _y = 7;

        public static void Main()
        {
            var t = new Program();
            t.DoTest();
        }

        private void DoTest()
        {
            var t1 = new Thread(new ThreadStart(Swap));
            var t2 = new Thread(new ThreadStart(Swap));

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }

        private void Swap()
        {
            lock (this)
            {
                Console.WriteLine($"Swap enter: x = {_x}, y = {_y}");
                var z = this._x;
                this._x = this._y;
                this._y = z;
                Console.WriteLine($"Swap leave: x = {_x}, y = {_y}");
            }
        }
    }
}