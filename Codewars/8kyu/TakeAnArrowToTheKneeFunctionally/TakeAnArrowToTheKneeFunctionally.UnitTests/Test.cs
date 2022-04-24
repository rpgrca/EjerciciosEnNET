using NUnit.Framework;
using System;
using TakeAnArrowToTheKneeFunctionally.Logic;

[TestFixture]
public class Test
{
    [Test]
    public static void FixedTests()
    {
        Assert.AreEqual("Test", Kata.ArrowFunc(new int[]{84,101,115,116}), "");
    }
}