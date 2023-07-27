using UnityEngine;
using NUnit.Framework;

namespace Iteration_VS_Recursion.Tests
{
    public class ConvertToIterationTest
    {
        [Test]
        public void MyAlgorithmIt_Test()
        {
            Assert.AreEqual(ConvertToIteration.MyAlgorithmRec(1), ConvertToIteration.MyAlgorithmIt(1));
            Assert.AreEqual(ConvertToIteration.MyAlgorithmRec(2), ConvertToIteration.MyAlgorithmIt(2));
            Assert.AreEqual(ConvertToIteration.MyAlgorithmRec(3), ConvertToIteration.MyAlgorithmIt(3));
            Assert.AreEqual(ConvertToIteration.MyAlgorithmRec(4), ConvertToIteration.MyAlgorithmIt(4));
            Assert.AreEqual(ConvertToIteration.MyAlgorithmRec(5), ConvertToIteration.MyAlgorithmIt(5));
            Assert.AreEqual(ConvertToIteration.MyAlgorithmRec(6), ConvertToIteration.MyAlgorithmIt(6));
            Assert.AreEqual(ConvertToIteration.MyAlgorithmRec(7), ConvertToIteration.MyAlgorithmIt(7));
        }
    }
}