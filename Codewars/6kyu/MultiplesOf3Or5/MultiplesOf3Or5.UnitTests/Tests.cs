using NUnit.Framework;
using MultiplesOf3Or5.Logic;

namespace MultiplesOf3Or5.UnitTests;

[TestFixture]
public class Tests
{
    [Test]
    public void Test()
    {
        Assert.AreEqual(23, Kata.Solution(10));
    }

    [Test]
    public void Test2()
    {
        Assert.AreEqual(23, Kata.Solution(10));
        Assert.AreEqual(78, Kata.Solution(20));
        Assert.AreEqual(9168, Kata.Solution(200));
        Assert.AreEqual(0, Kata.Solution(0));
    }
}