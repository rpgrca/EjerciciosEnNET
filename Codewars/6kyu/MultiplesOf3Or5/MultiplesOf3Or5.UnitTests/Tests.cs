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
}