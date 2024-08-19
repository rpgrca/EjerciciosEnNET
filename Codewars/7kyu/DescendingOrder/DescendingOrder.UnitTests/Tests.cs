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
}
