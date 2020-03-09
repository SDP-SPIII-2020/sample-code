using System;

namespace Example
{
    public class Thing : IThing
    {
        public Thing(int x)
        {
            X = x;
        }

        private int X { set; get; }

        public IThing Add(IThing item)
        {
            var res = this.X + ((Thing) item).X;
            return new Thing(res);
        }

        public override string ToString() => $"X = {X}";
    }
}