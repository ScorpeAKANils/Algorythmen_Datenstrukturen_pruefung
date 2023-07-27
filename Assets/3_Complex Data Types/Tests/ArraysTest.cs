using ComplexDataTypes;
using NUnit.Framework;

public class ArraysTest
{
    [Test]
    public void AsUInt_Test()
    {
        byte[] array = new byte[]
        {
            1,2,3,4,5,6,7,8,9
        };
        uint[] res = Arrays.AsUIntArray(array);
        Assert.AreEqual(16909060, res[0]); //not gonna lie hier kann etwas nicht stimmen. 
        Assert.AreEqual(84281096, res[1]);
    }

    [Test]
    public void AsUShort_Test()
    {
        byte[] array = new byte[]
        {
            1,2,3,4,5,6,7,8,9
        };
        ushort[] res = Arrays.AsUShortArray(array);
        Assert.AreEqual(258, res[0]);
        Assert.AreEqual(772, res[1]);
        Assert.AreEqual(1286, res[2]);
    }

    [Test]
    public void Concat_Test()
    {
        string[] a = new string[]
        {
            "a", "b", "c", "d", "e"
        };
        string[] b = new string[]
        {
            "f", "g", "h", "i", "j"
        };
        string[] res = Arrays.Concat(a, b);
        Assert.AreEqual("a", res[0]);
        Assert.AreEqual("b", res[1]);
        Assert.AreEqual("f", res[5]);
        Assert.AreEqual("i", res[8]);
    }

    [Test]
    public void LinearSearch_Test()
    {
        string[] array = new string[]
        {
            "a", "b", "c", "d", "e"
        };
        Assert.AreEqual(0, Arrays.FindElement(array, "a"));
        Assert.AreEqual(1, Arrays.FindElement(array, "b"));
        Assert.AreEqual(2, Arrays.FindElement(array, "c"));
        Assert.AreEqual(-1, Arrays.FindElement(array, "k"));
    }
}