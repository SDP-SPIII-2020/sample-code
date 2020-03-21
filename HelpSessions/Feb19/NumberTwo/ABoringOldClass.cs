using System;

namespace Feb19
{
    public class ABoringOldClass
    {
        private int _i;
        internal int I
        {
            get => _i;
            set => _i = value;
        }
        internal int J { get; set; }

        // public ABoringOldClass(): this(1,1)
        // {
        // }

        public ABoringOldClass(int i=1, int j=1)
        {
            I = i; // this.SetI(i)
            J = j;
        }

        public override string ToString() => $"i = {I}, j = {J}"; // this.GetI() this.GetJ()
    }
}