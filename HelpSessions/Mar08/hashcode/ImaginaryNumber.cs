using System;

namespace hashcode
{
    public class ImaginaryNumber
    {
        public ImaginaryNumber(double real = 1.0, double imag = 1.0)
        {
            Real = real;
            Imag = imag;
        }
        private double Real { get; set; }
        private double Imag { get; set; }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Calling Equals with an object");
            //return base.Equals(obj);
            return Equals(obj as ImaginaryNumber);
        }

        public bool Equals(ImaginaryNumber other)
        {
            Console.WriteLine("Calling the custom Equals");
            return other != null && Real == other.Real && Imag == other.Imag;
        }

        public override int GetHashCode()
        {
            var hashCode = 352022299;
            hashCode = hashCode * -123123123 + Real.GetHashCode();
            hashCode *= -123123123 + Imag.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Real = {Real}, Imag = {Imag}";

    }
}