using System;
using NUnit.Framework;
using RoundUpToNextMultipleOf5.Logic;

[TestFixture]
public class Tests
{
    [Test]
    [TestCase(0, ExpectedResult=0)]
    [TestCase(1, ExpectedResult=5)]
    [TestCase(-1, ExpectedResult=0)]
    [TestCase(-5, ExpectedResult=-5)]
    [TestCase(3, ExpectedResult=5)]
    [TestCase(5, ExpectedResult=5)]
    [TestCase(7, ExpectedResult=10)]
    [TestCase(39, ExpectedResult=40)]
    public static int FixedTest(int n)
    {
        return Kata.RoundToNext5(n);
    }

    [Test]
    public static void RandomTest([Random(-1000000,1000000, 100)] int n)
    {
        Assert.AreEqual(Solution(n), Kata.RoundToNext5(n), "Should work for "+n);
    }

    private static int Solution(int n)
    {
        while(n % 5 != 0) n++;
        return n;
    }
}