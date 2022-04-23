namespace PlayingWithCubes2.UnitTests;

using System;
using NUnit.Framework;
using PlayingWithCubes2.Logic;

[TestFixture]
public class Test
{  
    [Test]
    public static void TestConstructor()
    {
        Cube c = new Cube(10);
        Assert.AreEqual(10, c.GetSide(), "Should be 10");
    }
}