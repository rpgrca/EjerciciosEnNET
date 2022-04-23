namespace PlayingWithCubes2.UnitTests;

using System;
using NUnit.Framework;
using PlayingWithCubes2.Logic;

[TestFixture]
public class Test
{
    [Test]
    public static void BasicTest()
    {
        Cube c = new Cube();
        Assert.AreEqual(0, c.GetSide(), "when not set before, Side should be 0");
        c.SetSide(5);
        Assert.AreEqual(5, c.GetSide(), "Should return 5");
    }

    [Test]
    public static void TestConstructor()
    {
        Cube c = new Cube(10);
        Assert.AreEqual(10, c.GetSide(), "Should be 10");
    }

    [Test]
    public static void TestNegativeValues()
    {
        Cube c = new Cube(-7);
        Assert.AreEqual(7, c.GetSide(), "Should be 7");
    }

    [Test]
    public static void TestNegativeValues2()
    {
        Cube c = new Cube(3);
        c.SetSide(-9);
        Assert.AreEqual(9, c.GetSide(), "Should be 9");
    }
}