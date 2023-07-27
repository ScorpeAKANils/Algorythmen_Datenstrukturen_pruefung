using NUnit.Framework;

namespace Iteration_VS_Recursion.Tests
{
    public class FactorialTest
    {
        [Test]
        public void FacIt_Test()
        {
            Assert.AreEqual(1, Factorial.FacIt(0));
            Assert.AreEqual(1, Factorial.FacIt(1));
            Assert.AreEqual(2, Factorial.FacIt(2));
            Assert.AreEqual(720, Factorial.FacIt(6));
            Assert.AreEqual(3628800, Factorial.FacIt(10));
        }

        [Test]
        public void FacRec_Test()
        {
            Assert.AreEqual(1, Factorial.FacRec(0));
            Assert.AreEqual(1, Factorial.FacRec(1));
            Assert.AreEqual(2, Factorial.FacRec(2));
            Assert.AreEqual(720, Factorial.FacRec(6));
            Assert.AreEqual(3628800, Factorial.FacRec(10));
        }
    }
}