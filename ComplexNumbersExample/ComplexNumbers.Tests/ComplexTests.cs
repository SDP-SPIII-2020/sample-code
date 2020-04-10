using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComplexNumbers.Tests
{
    [TestClass]
    public class ComplexTests
    {
        private Complex z, z1, z2, z3;
        private const double delta = 0.0000000001;

        [TestInitialize]
        public void Setup()
        {
            z = new Complex(1.0, 0.0);
            z1 = new Complex(1.0, -2.0);
            z2 = new Complex(-3.0, -5.0);
            z3 = new Complex(0.292342, -0.394875);
        }

        [TestMethod]
        public void TestConjugate()
        {
            Assert.AreEqual(new Complex(1, 2), z1.Conjugate);
        }

        [TestMethod]
        public void TestModulus()
        {
            Assert.AreEqual(2.23606797749979, z1.Modulus, delta);
        }

        [TestMethod]
        public void TestArgument()
        {
            Assert.AreEqual(-1.1071487177940904, z1.Argument, delta);
        }

        [TestMethod]
        [TestCategory("operators")]
        public void TestOperatorAdd()
        {
            Assert.AreEqual(new Complex(re: -2, -7), z1 + z2);
        }

        [TestMethod]
        [TestCategory("operators")]
        public void TestOperatorMinus()
        {
            Assert.AreEqual(new Complex(re: 4, 3), z1 - z2);
        }

        [TestMethod]
        [TestCategory("operators")]
        public void TestOperatorMultiply()
        {
            Assert.AreEqual(new Complex(re: -13, 1), z1 * z2);
        }

        [TestMethod]
        [TestCategory("operators")]
        public void TestOperatorDivide()
        {
            Assert.AreEqual(new Complex(re: 0.20588235294117646, 0.3235294117647059), z1 / z2);
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestSin()
        {
            Assert.AreEqual(new Complex(3.165778513216168, -1.959601041421606), Complex.Sin(z1));
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestCos()
        {
            Assert.AreEqual(new Complex(2.0327230070196656, 3.0518977991517997), Complex.Cos(z1));
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestSinh()
        {
            Assert.AreEqual(new Complex(-0.48905625904129363, -1.4031192506220405), Complex.Sinh(z1));
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestCosh()
        {
            Assert.AreEqual(new Complex(-0.64214812471552, -1.0686074213827783), Complex.Cosh(z1));
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestTanh()
        {
            Assert.AreEqual(new Complex(1.16673625724092, 0.24345820118572523), Complex.Tanh(z1));
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestExp()
        {
            Assert.AreEqual(new Complex(-1.1312043837568135, -2.4717266720048188), Complex.Exp(z1));
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestLog()
        {
            Assert.AreEqual(new Complex(0.8047189562170503, -1.1071487177940904), Complex.Log(z1));
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestTan()
        {
            Assert.AreEqual(new Complex(0.03381282607989674, -1.0147936161466338), Complex.Tan(z1));
        }

        [TestMethod]
        [TestCategory("transcendental functions")]
        public void TestLog10()
        {
            Assert.AreEqual(new Complex(0.3494850021680094, -0.480828578784234), Complex.Log10(z1));
        }

        [TestMethod]
        [TestCategory("Roots")]
        public void TestSqrt()
        {
            Assert.AreEqual(new Complex(1.272019649514069, -0.7861513777574233), Complex.Sqrt(z1));
        }

        [DataTestMethod]
        [TestCategory("Roots")]
        [DataRow(4, 0, 1.1763010734364077, -0.33416248421026523)]
        [DataRow(4, 1, 0.33416248421026534, 1.1763010734364077)]
        [DataRow(4, 2, -1.1763010734364077, 0.3341624842102651)]
        [DataRow(4, 3, -0.3341624842102652, -1.1763010734364077)]
        public void TestNthRoot(int root, int value, double real, double imag)
        {
            Assert.AreEqual(new Complex(real, imag), Complex.NthRoot(z1, root, value));
        }

        [DataTestMethod]
        [TestCategory("Roots")]
        [DataRow(0, 1, 0)]
        [DataRow(1, 0.30901699437494745, 0.9510565162951535)]
        [DataRow(2, -0.8090169943749473, 0.5877852522924732)]
        [DataRow(3, -0.8090169943749475, -0.587785252292473)]
        [DataRow(4, 0.30901699437494723, -0.9510565162951536)]
        public void TestUnity(int k, double real, double imag)
        {
            Assert.AreEqual(new Complex(real, imag), Complex.NthRoot(z, 5, k));
        }

        [TestMethod]
        [TestCategory("Powers")]
        public void TestPow()
        {
            Assert.AreEqual(new Complex(0.0002692689321436034, -0.00022779290440774432), Complex.Pow(z1, z2));
            Assert.AreEqual(new Complex(29.00000000000021, -278.0000000000002), Complex.Pow(z1, 7));
        }
    }
}