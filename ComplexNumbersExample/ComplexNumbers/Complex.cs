//////////////////////////////////////
// Complex.cs - Complex Class
// Original copyright © PliaTech Software 2007
// Author: Michael B. Pliam
// Revised by KLM: January 2020

using System;
using System.Globalization;

namespace ComplexNumbers
{
    /// <summary>
    ///     <remarks>
    ///         Complex struct encapsulates fields double real and double imag.
    ///         Struct objects are designed to behave as complex numbers.
    ///     </remarks>
    /// </summary>
    public struct Complex : IComplex
    {
        #region fields

        private static readonly Random Rnd = new Random();

        #endregion

        #region initializers

        /// <summary>
        ///     <remarks>
        ///         Complex struct creates a new Complex struct from an existing one (copy constructor).
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        public Complex(Complex z) : this(z.Real, z.Imag)
        {
        }

        /// <summary>
        ///     <remarks>
        ///         Set an existing Complex object with new components.
        ///     </remarks>
        /// </summary>
        /// <param name="re"></param>
        /// <param name="im"></param>
        /// <returns></returns>
        public Complex(double re, double im)
        {
            Real = re;
            Imag = im;
        }

        /// <summary>
        ///     <remarks>
        ///         Create a random Complex number with real and imaginary components between 0 and 1.
        ///     </remarks>
        /// </summary>
        /// <returns>Complex</returns>
        public static Complex Random() =>
            new Complex {Real = Rnd.NextDouble(), Imag = Rnd.NextDouble()};

        /// <summary>
        ///     <remarks>
        ///         Create a random Complex number with real and imaginary components within
        ///         and including the selected range from lo to hi
        ///     </remarks>
        /// </summary>
        /// <returns>Complex</returns>
        public static Complex Random(double lo, double hi)
        {
            var range = hi - lo;
            var real = lo + range * Rnd.NextDouble();
            var imag = lo + range * Rnd.NextDouble();

            return new Complex(real, imag);
        }

        #endregion

        #region accessors

        /// <summary>
        ///     <remarks>
        ///         Access the real component property of the Complex number.
        ///         This accessor is both read and write.
        ///     </remarks>
        /// </summary>
        private double Real { get; set; }

        /// <summary>
        ///     <remarks>
        ///         Access the imaginary component property of the Complex number.
        ///         This accessor is both read and write.
        ///     </remarks>
        /// </summary>
        private double Imag { get; set; }

        #endregion

        #region operators

        /// <summary>
        ///     <remarks>
        ///         Complex addition operator facilitates addition of two complex numbers.
        ///         Note that overriding this operator automatically overrides the += operator as well.
        ///     </remarks>
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns>Complex</returns>
        public static Complex operator +(Complex z1, Complex z2) =>
            new Complex(z1.Real + z2.Real, z1.Imag + z2.Imag);

        /// <summary>
        ///     <remarks>
        ///         Complex subtraction operator facilitates subtraction of two complex numbers.
        ///         Note that overriding this operator automatically overrides the -= operator as well.
        ///     </remarks>
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns>Complex</returns>
        public static Complex operator -(Complex z1, Complex z2) =>
            new Complex(z1.Real - z2.Real, z1.Imag - z2.Imag);


        /// <summary>
        ///     <remarks>
        ///         The unary negation operator placed before a complex number negates both real
        ///         and imaginary components of that number.
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex operator -(Complex z) => new Complex(-z.Real, -z.Imag);


        /// <summary>
        ///     <remarks>
        ///         Complex multiplication operator facilitates multiplication of two complex numbers.
        ///         Note that overriding this operator automatically overrides the *= operator as well.
        ///     </remarks>
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns>Complex</returns>
        public static Complex operator *(Complex z1, Complex z2) =>
            new Complex(
                z1.Real * z2.Real - z1.Imag * z2.Imag,
                z1.Real * z2.Imag + z1.Imag * z2.Real);


        /// <summary>
        ///     <remarks>
        ///         This version of the * operator allows you to multiply a complex number
        ///         by a double value.  The result is a complex number.
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <param name="dval"></param>
        /// <returns>Complex</returns>
        public static Complex operator *(Complex z, double dval)
        {
            var real = z.Real * dval;
            var imag = z.Imag * dval;
            return new Complex(real, imag);
        }

        /// <summary>
        ///     <remarks>
        ///         This version of the * operator allows you to multiply a double value
        ///         by a complex number.  The result is a complex number.
        ///     </remarks>
        /// </summary>
        /// <param name="dval"></param>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex operator *(double dval, Complex z) => z * dval;

        /// <summary>
        ///     <remarks>
        ///         Complex division operator facilitates division of one complex number by another.
        ///         Note that overriding this operator automatically overrides the /= operator as well.
        ///     </remarks>
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns>Complex</returns>
        public static Complex operator /(Complex z1, Complex z2)
        {
            var value = z2.Real * z2.Real + z2.Imag * z2.Imag;

            return new Complex(
                (z1.Real * z2.Real + z1.Imag * z2.Imag) / value,
                (z1.Imag * z2.Real - z1.Real * z2.Imag) / value);
        }

        /// <summary>
        ///     <remarks>
        ///         This version of the / operator allows you to divide a complex number
        ///         by a real scalar double value.  The result is a complex number.
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <param name="dval"></param>
        /// <returns>Complex</returns>
        public static Complex operator /(Complex z, double dval)
        {
            var real = z.Real / dval;
            var imag = z.Imag / dval;
            return new Complex(real, imag);
        }

        /// <summary>
        ///     <remarks>
        ///         The comparison operator '==' facilitates the comparison of two distinct complex numbers.  The method
        ///         returns true if complex numbers are identical, false if they are not.  The comparison is made between
        ///         the two real doubles and the two imaginary doubles respectively.
        ///     </remarks>
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Complex z1, Complex z2) =>
            (z1.Real == z2.Real) && (z1.Imag == z2.Imag); // tolerance?

        /// <summary>
        ///     <remarks>
        ///         The comparison operator '!=' facilitates the comparison of two distinct complex numbers.
        ///         The method returns true if complex numbers are not identical, false if they are identical.
        ///         The comparison is made between the two real doubles and the two imaginary doubles respectively.
        ///     </remarks>
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns>bool</returns>
        public static bool operator !=(Complex z1, Complex z2) =>
            z1.Real != z2.Real || z1.Imag != z2.Imag; // tolerance?

        #endregion

        #region algebra

        /// <summary>
        ///     <remarks>
        ///         The complex conjugate of a complex number is obtained by changing the sign of the imaginary part.
        ///         Thus, the conjugate of the complex number z = (a, b) (where a and b are real numbers, a is the real
        ///         part and b the imaginary part) is (a, -b).
        ///         In polar form, the complex conjugate of z = r*e^(i*t) is r*e^(-i*t).
        ///     </remarks>
        /// </summary>
        public Complex Conjugate => new Complex(Real, -Imag);

        /// <summary>
        ///     <remarks>
        ///         The complex norm of a complex number z = (a, ib), also called the  modulus, is denoted |z|
        ///         and defined by sqrt(real*real + imag*imag). If z is expressed as a complex exponential
        ///         (i.e., a phasor), then the norm can be expressed as |r*e^(i*t)| = |r|.  For some reason,
        ///         some authors refer to the complex norm as simply real*real + imag*imag (without taking the
        ///         square root of the sum). This makes little sense from a geometric point of view and is
        ///         probably an error.
        ///     </remarks>
        /// </summary>
        public double Norm => Math.Sqrt(Real * Real + Imag * Imag);

        /// <summary>
        ///     <remarks>
        ///         The square |z|^2 of |z| is sometimes called the absolute square. The absolute square of
        ///         a complex number z, also known as the squared norm, is defined as |z|^2 = z * z_, where
        ///         z_ is the complex conjugate of z and |z| is the complex modulus. If the complex number is
        ///         written z = (a, b), with a and b real, then the absolute square can be written |z| = a^2 + b^2.
        ///         Note that even though the absolute square is the product of two complex numbers, the result is
        ///         a real number of type double because the imaginary part is always zero.
        ///     </remarks>
        /// </summary>
        public double AbsoluteSquare => (this * Conjugate).Real;

        /// <summary>
        ///     <remarks>
        ///         Provides the modulus (norm, absolute value) of a complex number.  Recall that
        ///         any complex number z = |z| * e^(i * t) where t = argument and |z| = modulus.
        ///         The modulus is the value of the radial vector in the Argand Plane that extends
        ///         from the origin to a point representing the complex number [x(real), y(imag)].
        ///     </remarks>
        /// </summary>
        public double Modulus => Math.Sqrt(Real * Real + Imag * Imag);

        /// <summary>
        ///     <remarks>
        ///         Provides the argument or angle t in radians of a complex number.  Recall that
        ///         any complex number z = |z| * e^(i * t) where t = argument and |z| = modulus.
        ///         Recall that a complex number has arguments between 0 and 2PI.  This algorithm
        ///         automatically compensates for angles greater than 2PI by using Math.Atan2.
        ///     </remarks>
        /// </summary>
        public double Argument => Math.Atan2(Imag, Real);

        /// <summary>
        ///     <remarks>
        ///         Create a new complex number by inputing the modulus and argument.
        ///     </remarks>
        /// </summary>
        /// <param name="modulus"></param>
        /// <param name="argument"></param>
        /// <returns>Complex</returns>
        public static Complex Polar(double modulus, double argument) =>
            new Complex(modulus * Math.Cos(argument), modulus * Math.Sin(argument));


        /// <summary>
        ///     <remarks>
        ///         Calculates the complex value of a complex number z raised to a complex power n.
        ///     </remarks>
        /// </summary>
        /// <param name="baseNumber"></param>
        /// <param name="index"></param>
        /// <returns>Complex</returns>
        public static Complex Pow(Complex baseNumber, Complex index) => Exp(index * Log(baseNumber));


        /// <summary>
        ///     <remarks>
        ///         Calculates the complex value of a complex number z raised to an integral power n.
        ///     </remarks>
        /// </summary>
        /// <param name="baseNumber"></param>
        /// <param name="index"></param>
        /// <returns>Complex</returns>
        public static Complex Pow(Complex baseNumber, long index) =>
            Exp(new Complex(index, 0.0) * Log(baseNumber));

        /// <summary>
        ///     <remarks>
        ///         Find the complex square root of a complex number.
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Sqrt(Complex z)
        {
            var value = Math.Sqrt(z.Real * z.Real + z.Imag * z.Imag) + z.Real;

            return new Complex(Math.Sqrt(0.5 * value), Math.Sqrt(0.5 / value) * z.Imag);
        }

        /// <summary>
        ///     <remarks>
        ///         The reciprocal of a complex number, z = (a, b), sometimes referred to as the
        ///         'multiplicative inverse', can be computed as follows:
        ///         z^(-1) = Complex(1.0, 0.0)/ z.
        ///         Using the Recip method is essentially the same as using the division operator
        ///         on complex(1.0, 0.0).
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Recip(Complex z)
        {
            if (z.Real == 0.0 && z.Imag == 0.0)
            {
                Console.WriteLine("multiplicative inverse (reciprocal) not defined for complex zero");
                return z;
            }

            var zr = new Complex(1.0, 0.0);
            var real = z.Real / (z.Real * z.Real + z.Imag * z.Imag);
            var imag = -z.Imag / (z.Real * z.Real + z.Imag * z.Imag);

            return new Complex(real, imag);
        } // Recip(ComplexNumbers z)

        /// <summary>
        ///     <remarks>
        ///         According to Euler's formula, for any real number x,
        ///         e^(ix) = cos(x) + i sin(x)
        ///         where
        ///         e is the base of the natural logarithm
        ///         i is the imaginary unit
        ///         cos and sin are trigonometric functions
        ///         Complex numbers z = (a, ib) can be expressed in polar form:
        ///         z = r * e^(i*t) or mod * e^(i*arg) or z = |z|* e^(i*t)
        ///         Using the Euler relationship, The polar form can also be expressed
        ///         in terms of trigonometric functions:
        ///         z = r*e^(i*t) = r * (cos(t) + i sin(t))
        ///         = |z|* e^(i*t) = |z| * (cos(t) + i sin(t))
        ///         The SetPolar function resets the current complex number
        ///         with Modulus mod and Argument arg.
        ///     </remarks>
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Complex SetPolar(double mod, double arg)
        {
            var real = mod * Math.Cos(arg);
            var imag = mod * Math.Sin(arg);

            return new Complex(real, imag);
        }

        /// <summary>
        ///     <remarks>
        ///         De Moivre's formula states that for any complex number x
        ///         and any integer n it holds that
        ///         cos(x)+ i*sin(x))^n = cos(n*x) + i*sin(n*x)
        ///         Since z = r*e^(i*t) = r * (cos(t) + i sin(t))
        ///         where
        ///         z = (a, ib)
        ///         r = modulus of z
        ///         t = argument of z
        ///         i = sqrt(-1.0)
        ///         thence, one can calculate the nth root of z by the formula:
        ///         z^(1/n) = r^(1/n) * (cos(x/n) + i sin(x/n))
        ///         by using log division which makes this relatively simple.
        ///         Note that there exists a multiplicity of complex roots which must be n - 1 in number.
        ///         The k nth roots of z = r cis t are: ( where 'cis' stands for  cos(t) + i sin(t) )
        ///         z^(1/n) = r^(1/n) cis ( t/n + k * 2 * PI /n) for k = 0, 1, 2, 3, ... n-1.
        ///         This method returns the kth Nth root where k = 0, 1, 2, 3,...,n - 1.
        ///         Notice that when k > n-1 the roots simply recycle since there are only n-1.
        ///         unique roots. Do not confuse the "nth root" with the "nth root of unity".  Recall
        ///         that an "nth root of unity" is just another name for an nth root of one (or minus
        ///         one).  Thus the 5th root of unity is: b = Complex.NthRoots(a, 5, k) where a = (1.0, 0.0).
        ///         Similar calculations can be made for a = (0.0, 1.0).
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns>Complex</returns>
        public static Complex NthRoot(Complex z, long n, long k)
        {
            var mod = z.Modulus;
            var arg = z.Argument;

            var lmod = Math.Log(mod);
            var rlmod = lmod / n;
            var rmod = Math.Exp(rlmod);

            var t = arg / n + 2 * k * Math.PI / n;
            var real = rmod * Math.Cos(t);
            var imag = rmod * Math.Sin(t);

            return new Complex(real, imag);
        }

        #endregion

        #region transcendentals

        /// <summary>
        ///     <remarks>
        ///         Calculates the complex cosine of the complex number z through use of the formula
        ///         cos(z) = ( exp(i*z) + exp(-i*z) ) / 2.
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Cos(Complex z)
        {
            var z1 = Exp(new Complex(-z.Imag, z.Real));
            var z2 = Exp(new Complex(z.Imag, -z.Real));

            return new Complex(0.5 * (z1.Real + z2.Real), 0.5 * (z1.Imag + z2.Imag));
        }

        /// <summary>
        ///     <remarks>
        ///         Calculates the complex hyperbolic cosine of the complex number z through use of the formula
        ///         cosh(z) = ( exp(z) + exp(-z) ) / 2.
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Cosh(Complex z)
        {
            var z1 = Exp(z);
            var z2 = Exp(new Complex(-z.Real, -z.Imag));

            return new Complex(0.5 * (z1.Real + z2.Real), 0.5 * (z1.Imag + z2.Imag));
        }

        /// <summary>
        ///     <remarks>
        ///         Calculates the complex sine of the complex number z through use of the formula
        ///         sin(z) = ( exp(i*z) - exp(-i*z) ) / (2*i).
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Sin(Complex z)
        {
            var z1 = Exp(new Complex(-z.Imag, z.Real));
            var z2 = Exp(new Complex(z.Imag, -z.Real));

            return new Complex(0.5 * (z1.Imag - z2.Imag), 0.5 * (z2.Real - z1.Real));
        }

        /// <summary>
        ///     <remarks>
        ///         Calculates the complex hyperbolic sine of the complex number z through use of the formula
        ///         sinh(z) = ( exp(z) - exp(-z) ) / 2.
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Sinh(Complex z)
        {
            var z1 = Exp(z);
            var z2 = Exp(new Complex(-z.Real, -z.Imag));

            return new Complex(0.5 * (z1.Real - z2.Real), 0.5 * (z1.Imag - z2.Imag));
        }

        /// <summary>
        ///     <remarks>
        ///         Calculates the complex tangent of the complex number z through use of the formula
        ///         tan(z) = sin(z)/cos(z).
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Complex Tan(Complex z) => Sin(z) / Cos(z);

        /// <summary>
        ///     <remarks>
        ///         Calculates the complex hyperbolic tangent of the complex number z through use of the formula
        ///         tanh(z) = sinh(z)/cosh(z) = (exp(2*z) - 1) / (exp(2*z) + 1) = -i * tan(i*z).
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Tanh(Complex z) => Sinh(z) / Cosh(z);

        /// <summary>
        ///     <remarks>
        ///         Calculates the complex exponential of the complex number z = (a, b) through use of the formula
        ///         exp(z) = exp(a) * (cos(b) + i*sin(b)).  In power form, it can be expressed e^(z) where e is
        ///         Euler's number which is 2.7182818284590452...
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Exp(Complex z)
        {
            var value = Math.Exp(z.Real);

            return new Complex(
                value * Math.Cos(z.Imag),
                value * Math.Sin(z.Imag));
        }

        /// <summary>
        ///     <remarks>
        ///         If the non-zero complex number z is expressed in polar coordinates as z = r * e^(i*t)
        ///         with r > 0 and t is between -pi and pi, then log(z) = ln(r) + i*t, where ln(r) is the
        ///         usual natural logarithm of a real number. Recall that r is the complex modulus and
        ///         t is the complex argument of z. So defined, log (z) is holomorphic for all complex
        ///         numbers which are not real numbers less than or equal to 0, and it has the property
        ///         e^(log(z)) = z.  Recall that some familiar properties of the real-valued natural
        ///         logarithm are no longer valid for this complex extension. For example, log(e^(z)) does
        ///         not always equal z, and log(z*w) does not always equal log(z) + log(w) – in either case,
        ///         the result might have to be adjusted modulo 2*pi*i to stay within the range of this
        ///         principal branch of the complex log function.  A somewhat more natural definition of
        ///         log(z) interprets it as a multi-valued function. Thus for z = r*e^(i*t), it would be
        ///         possible to choose log(z) = ln(r) + i*(t + 2*pi*k) for any integer k.
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Log(Complex z) => new Complex(Math.Log(z.Modulus), z.Argument);

        /// <summary>
        ///     <remarks>
        ///         Given any real number greater than zero, the logarithm of that number to base (a)
        ///         is related to the logarithm of that number base (b) by the scaling formula
        ///         log[b](x) = log[a](x)/log(b).  Consider the logarithm of a complex number z is
        ///         log(z) = ln(r) + i*t, where ln(r) is the usual natural logarithm of a real number,
        ///         r is the complex modulus, and t is the complex argument of z.  Applying the above
        ///         logarithmic scaling factor to the natural complex logarithm, we can obtain the
        ///         complex logarithm to virtually any desired base.  Using ln(10) = 2.30258... as
        ///         the scaling factor for ln(z).
        ///     </remarks>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Complex</returns>
        public static Complex Log10(Complex z)
        {
            const double log10 = 2.3025850929940459;

            var value = Log(z);

            value.Real /= log10;
            value.Imag /= log10;

            return value;
        }

        #endregion

        #region display

        /// <summary>
        ///     <remarks>
        ///         Provides a string representation of the complex number z = (x, y), where x and y are real
        ///         numbers.  The representation of a complex number in this way is cleaner and less confusing
        ///         than the more traditional z = (x + iy).  Provided the imaginary part always appears on the
        ///         right, there is no need for the additional 'i'.  And since x and y are really components of
        ///         a two element vector, the addition sign is superfluous and inaccurate unless the assumption
        ///         is made that it signifies vector addition.  For example, with higher dimensional vectors,
        ///         it seems sensible to use V = (a1, a2, a3,...,an).
        ///     </remarks>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"( {Real},  {Imag} )";

        /// <summary>
        ///     <remarks>
        ///         Allows comparison of two Complex numbers
        ///     </remarks>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///     <remarks>
        ///         Attempts to provide a unique integer code for this complex object. The method employed here
        ///         is to use the exclusive or (XOR) of the two hash code integers obtained from the real and
        ///         imaginary parts of this number.  It should be obvious that this will not always provide a
        ///         unique hash code and so should be used reservedly.
        ///     </remarks>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Real.GetHashCode() ^ Imag.GetHashCode();

        /// <summary>
        ///     <remarks>
        ///         Uses the string form of the rectangular representation of a complex number to
        ///         display the number in Console mode.  z = (a, b) where a = real part, b = imaginary part.
        ///         Notice that the imaginary 'i' is to be understood to be a multiplier of b and has
        ///         been left out. Also, the '+' sign between a and b which is sometimes used to suggest
        ///         vector addition has been omitted.
        ///     </remarks>
        /// </summary>
        public void Show() => Console.WriteLine(ToString());

        /// <summary>
        ///     <remarks>
        ///         Shows the polar representation of the complex number z in the form in Console mode.
        ///         z = |z| * e^(i * t)
        ///         where |z| = modulus of z
        ///         t  = argument of z
        ///         i  = complex(0.0, 1.0)
        ///     </remarks>
        /// </summary>
        public void ShowPolar() => Console.WriteLine($"{Modulus} * e^(i * {Argument})");

        /// <summary>
        ///     <remarks>
        ///         Provides a string representation of the polar form of the complex number.
        ///         Compare with ShowPolar method which shows the polar representation only
        ///         in Console mode.
        ///     </remarks>
        /// </summary>
        /// <returns></returns>
        public string Polar()
        {
            var z = new Complex(this);

            return z.Modulus.ToString(CultureInfo.InvariantCulture) + " * e^(i * " +
                   z.Argument.ToString(CultureInfo.InvariantCulture) + ")";
        }

        /// <summary>
        ///     <remarks>
        ///         This algorithm truncates a double type value to
        ///         a specified number of decimal digits (those digits
        ///         to the right of the decimal point).  It is used by
        ///         Complex::Round(int ndigs).  Warning: if more than
        ///         17 significant digits are present, regardless of
        ///         their position with respect to the decimal point,
        ///         overflow could occur and/or significant accuracy
        ///         be lost.
        ///     </remarks>
        /// </summary>
        /// <param name="dval"></param>
        /// <param name="ndigs"></param>
        /// <returns>double</returns>
        private double Truncate(double dval, int ndigs)
        {
            // MBP rounding algorithm
            // ndigs = number of decimal digits
            var rndfac = Math.Pow(10, ndigs);
            dval *= rndfac;
            dval = Math.Round(dval);
            dval /= rndfac;
            return dval;
        }

        /// <summary>
        ///     <remarks>
        ///         This method used the Complex::(double dval, int ndigs)
        ///         method to round to a specified (ndigs) number of
        ///         decimal digits (those digits to the right of the decimal
        ///         point). Warning: if more than 17 significant digits are
        ///         present, regardless of their position with respect to the
        ///         decimal point, overflow could occur and/or significant accuracy
        ///         could be lost.  If that is the case, don't use this method.
        ///     </remarks>
        /// </summary>
        /// <param name="ndigs"></param>
        /// <returns></returns>
        public Complex Round(int ndigs)
        {
            var real = Truncate(Real, ndigs);
            var imag = Truncate(Imag, ndigs);
            return new Complex(real, imag);
        }

        #endregion
    } // Complex
} // ComplexNumbers