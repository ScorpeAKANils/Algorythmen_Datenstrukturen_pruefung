using NUnit.Framework;
using System.Collections.Generic;

namespace Iteration_VS_Recursion.Tests
{
    public class ConvertToRecursionTest
    {
        [Test]
        public void MyAlgorithmRec_Test()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,
            };
            List<int> itRes = ConvertToRecursion.MyAlgorithmIt(list);
            List<int> recRes = ConvertToRecursion.MyAlgorithmRec(list);
            Assert.AreEqual(itRes, recRes);
        }
    }
}