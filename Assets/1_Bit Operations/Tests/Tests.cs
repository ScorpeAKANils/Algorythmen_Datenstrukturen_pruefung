using NUnit.Framework;

namespace BitOperations.Tests
{
    public class Tests
    {
        [Test]
        public void BitwiseAnd_Test()
        {
            // 1100 AND 0011
            Assert.AreEqual(0, ImplementMe.BitwiseAnd(12, 3));
            // 1010 AND 0011
            Assert.AreEqual(2, ImplementMe.BitwiseAnd(10, 3));
            // 11001100 AND 01100111
            Assert.AreEqual(68, ImplementMe.BitwiseAnd(204, 103));
        }

        [Test]
        public void ConvertToDecimal_Test()
        {
            Assert.AreEqual(0, ImplementMe.ConvertToDecimal("0"));
            Assert.AreEqual(57, ImplementMe.ConvertToDecimal("111001"));
            Assert.AreEqual(53, ImplementMe.ConvertToDecimal("110101"));
            Assert.AreEqual(9, ImplementMe.ConvertToDecimal("1001"));
        }

        [Test]
        public void DivideBy2_Test()
        {
            Assert.AreEqual(0, ImplementMe.DivideBy2(0));
            Assert.AreEqual(16, ImplementMe.DivideBy2(32));
            Assert.AreEqual(512, ImplementMe.DivideBy2(1024));
            Assert.AreEqual(-16, ImplementMe.DivideBy2(-32));
        }

        [Test]
        public void MultiplyBy2_Test()
        {
            Assert.AreEqual(0, ImplementMe.MultiplyBy2(0));
            Assert.AreEqual(2, ImplementMe.MultiplyBy2(1));
            Assert.AreEqual(10, ImplementMe.MultiplyBy2(5));
            Assert.AreEqual(-64, ImplementMe.MultiplyBy2(-32));
        }

        [Test]
        public void MultiplyBy8_Test()
        {
            Assert.AreEqual(0, ImplementMe.MultiplyBy8(0));
            Assert.AreEqual(8, ImplementMe.MultiplyBy8(1));
            Assert.AreEqual(40, ImplementMe.MultiplyBy8(5));
            Assert.AreEqual(-256, ImplementMe.MultiplyBy8(-32));
        }
    }
}