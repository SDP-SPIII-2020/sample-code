using System;

namespace Example
{
    public interface IThing
    {
        public static IThing operator +(IThing a, IThing b) => a.Add(b);

        IThing Add(IThing item);
        string ToString();
    }
}