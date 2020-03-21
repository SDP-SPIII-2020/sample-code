using System;

namespace Feb19
{
    public class ABoringOldClass
    {
        private int i;
        private int j;

        public ABoringOldClass(): this(1,1)
        {
        }

        public ABoringOldClass(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public int GetI()
        {
            return i;
        }

        public int GetJ()
        {
            return j;
        }

        public void SetI(int i)
        {
            this.i = i;
        }

        public void SetJ(int j)
        {
            this.j = j;
        }

        public override string ToString()
        {
            return $"i = {i}, j = {j}";
        }
    }
}