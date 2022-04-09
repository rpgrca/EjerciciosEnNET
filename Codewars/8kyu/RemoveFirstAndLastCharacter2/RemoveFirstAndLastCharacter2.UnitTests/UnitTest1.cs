using System;
using System.Linq;
using NUnit.Framework;
using RemoveFirstAndLastCharacter2.Logic;

namespace RemoveFirstAndLastCharacter2.UnitTests;

public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(null, Kata.Array(""));
        Assert.AreEqual(null, Kata.Array("1"));
        Assert.AreEqual(null, Kata.Array("1, 3"));
        Assert.AreEqual("2", Kata.Array("1,2,3"));
        Assert.AreEqual("2 3", Kata.Array("1,2,3,4"));
    }
}