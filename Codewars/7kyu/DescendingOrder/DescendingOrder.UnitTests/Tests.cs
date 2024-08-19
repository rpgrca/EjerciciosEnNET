using DescendingOrder.Logic;
using NUnit.Framework;

namespace DescendingOrder.UnitTests;

[TestFixture]
public class Tests
{
    [Test]
    public void Test0()
    {
        Assert.AreEqual(0, Kata.DescendingOrder(0));
    }

    [Test]
    public void Test1()
    {
        Assert.AreEqual(1, Kata.DescendingOrder(1));
    }
}
