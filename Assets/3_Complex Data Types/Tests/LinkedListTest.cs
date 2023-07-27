using NUnit.Framework;

namespace ComplexDataTypes.Tests
{
    public class LinkedListTest
    {
        [Test]
        public void LinkedList_Test()
        {
            LinkedNode firstNode = new LinkedNode("first node");
            LinkedNode secondNode = new LinkedNode("second node");
            LinkedNode thirdNode = new LinkedNode("third node");
            LinkedNode fourthNode = new LinkedNode("fourth node");
            LinkedList list = new LinkedList(firstNode);

            Assert.AreEqual(0, list.IndexOf(firstNode));

            list.AddToFront(secondNode);
            Assert.AreEqual(0, list.IndexOf(secondNode));
            Assert.AreEqual(1, list.IndexOf(firstNode));

            list.AddToEnd(thirdNode);
            Assert.AreEqual(0, list.IndexOf(secondNode));
            Assert.AreEqual(1, list.IndexOf(firstNode));
            Assert.AreEqual(2, list.IndexOf(thirdNode));
            
            list.InsertAfterX(firstNode, fourthNode);
            Assert.AreEqual(0, list.IndexOf(secondNode));
            Assert.AreEqual(1, list.IndexOf(firstNode));
            Assert.AreEqual(2, list.IndexOf(fourthNode));
            Assert.AreEqual(3, list.IndexOf(thirdNode));
            
            list.Remove(firstNode);
            Assert.AreEqual(0, list.IndexOf(secondNode));
            Assert.AreEqual(1, list.IndexOf(fourthNode));
            Assert.AreEqual(2, list.IndexOf(thirdNode));
        }
    }
}