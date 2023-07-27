using NUnit.Framework;
using UnityEngine;
namespace BasicDataTypes.Tests
{
    public class Tests
    {
        [Test]
        public void CombineByte_Test()
        {
            Assert.AreEqual(0, ImplementMe.Combine((byte)0, 0));
            Assert.AreEqual(49152, ImplementMe.Combine((byte)192, 0));
            Assert.AreEqual(2572, ImplementMe.Combine((byte)10, 12));
        }

        [Test]
        public void CombineInt_Test()
        {
            Assert.AreEqual(0, ImplementMe.Combine((uint)0, 0));
            Assert.AreEqual(824633720832, ImplementMe.Combine((uint)192, 0));
            Assert.AreEqual(42949672972, ImplementMe.Combine((uint)10, 12));
        }

        [Test]
        public void Compare_Test()
        {
            Assert.IsTrue(ImplementMe.Compare(1, 1, 1));
            Assert.IsTrue(ImplementMe.Compare(0.3 * 3 + 0.1, 1, 2));
        }

        [Test]
        public void CountOnes_Test()
        {
            Assert.AreEqual(0, ImplementMe.CountOnes(0));
            Assert.AreEqual(1, ImplementMe.CountOnes(1));
            Assert.AreEqual(2, ImplementMe.CountOnes(3));
            Assert.AreEqual(12, ImplementMe.CountOnes(46974));
        }
    }
}