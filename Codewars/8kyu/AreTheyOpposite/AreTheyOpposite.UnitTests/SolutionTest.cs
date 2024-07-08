using NUnit.Framework;
using System;

namespace AreTheyOpposite.UnitTests;

[TestFixture]
public class SolutionTest
{
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
        Assert.AreEqual(true, Kata.IsOpposite("ab","AB"), "ab, AB => true");
        Assert.AreEqual(true, Kata.IsOpposite("aB","Ab"), "aB, Ab => true");
        Assert.AreEqual(true, Kata.IsOpposite("aBcd","AbCD"), "aBcd, AbCD => true");
        Assert.AreEqual(false, Kata.IsOpposite("aBcde","AbCD"), "aBcde, AbCD => false");
        Assert.AreEqual(false, Kata.IsOpposite("AB","Ab"), "AB, Ab => false");
        Assert.AreEqual(false, Kata.IsOpposite("",""), "String.Empty, String.Empty => false");
    }
}