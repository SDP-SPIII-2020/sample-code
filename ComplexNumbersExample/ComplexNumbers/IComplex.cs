namespace ComplexNumbers
{
    public interface IComplex
    {
        /// <summary>
        ///     <remarks>
        ///         The complex conjugate of a complex number is obtained by changing the sign of the imaginary part.
        ///         Thus, the conjugate of the complex number z = (a, b) (where a and b are real numbers, a is the real
        ///         part and b the imaginary part) is (a, -b).
        ///         In polar form, the complex conjugate of z = r*e^(i*t) is r*e^(-i*t).
        ///     </remarks>
        /// </summary>
        Complex Conjugate { get; }

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
        double Norm { get; }

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
        double AbsoluteSquare { get; }

        /// <summary>
        ///     <remarks>
        ///         Provides the modulus (norm, absolute value) of a complex number.  Recall that
        ///         any complex number z = |z| * e^(i * t) where t = argument and |z| = modulus.
        ///         The modulus is the value of the radial vector in the Argand Plane that extends
        ///         from the origin to a point representing the complex number [x(real), y(imag)].
        ///     </remarks>
        /// </summary>
        double Modulus { get; }

        /// <summary>
        ///     <remarks>
        ///         Provides the argument or angle t in radians of a complex number.  Recall that
        ///         any complex number z = |z| * e^(i * t) where t = argument and |z| = modulus.
        ///         Recall that a complex number has arguments between 0 and 2PI.  This algorithm
        ///         automatically compensates for angles greater than 2PI by using Math.Atan2.
        ///     </remarks>
        /// </summary>
        double Argument { get; }

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
        Complex SetPolar(double mod, double arg);

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
        string ToString();

        /// <summary>
        ///     <remarks>
        ///         Allows comparison of two Complex numbers
        ///     </remarks>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Equals(object obj);

        /// <summary>
        ///     <remarks>
        ///         Attempts to provide a unique integer code for this complex object. The method employed here
        ///         is to use the exclusive or (XOR) of the two hash code integers obtained from the real and
        ///         imaginary parts of this number.  It should be obvious that this will not always provide a
        ///         unique hash code and so should be used reservedly.
        ///     </remarks>
        /// </summary>
        /// <returns></returns>
        int GetHashCode();

        /// <summary>
        ///     <remarks>
        ///         Uses the string form of the rectangular representation of a complex number to
        ///         display the number in Console mode.  z = (a, b) where a = real part, b = imaginary part.
        ///         Notice that the imaginary 'i' is to be understood to be a multiplier of b and has
        ///         been left out. Also, the '+' sign between a and b which is sometimes used to suggest
        ///         vector addition has been omitted.
        ///     </remarks>
        /// </summary>
        void Show();

        /// <summary>
        ///     <remarks>
        ///         Shows the polar representation of the complex number z in the form in Console mode.
        ///         z = |z| * e^(i * t)
        ///         where |z| = modulus of z
        ///         t  = argument of z
        ///         i  = complex(0.0, 1.0)
        ///     </remarks>
        /// </summary>
        void ShowPolar();

        /// <summary>
        ///     <remarks>
        ///         Provides a string representation of the polar form of the complex number.
        ///         Compare with ShowPolar method which shows the polar representation only
        ///         in Console mode.
        ///     </remarks>
        /// </summary>
        /// <returns></returns>
        string Polar();

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
        Complex Round(int ndigs);
    }
}