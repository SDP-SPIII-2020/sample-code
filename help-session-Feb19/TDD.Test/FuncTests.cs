using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD.Test
{
    [TestClass]
    public class FuncTests
    {
        [TestMethod]
        public void TestEven() => Assert.IsTrue(FuncClass.IsEven(12));
        
        [TestMethod]
        public void TestOdd() => Assert.IsFalse(FuncClass.IsEven(11));

        [TestMethod]
        public void TestNegative()
        {
            Assert.IsFalse(FuncClass.IsEven(-1));
            Assert.IsFalse(FuncClass.IsEven(-2));
        }
    }
}