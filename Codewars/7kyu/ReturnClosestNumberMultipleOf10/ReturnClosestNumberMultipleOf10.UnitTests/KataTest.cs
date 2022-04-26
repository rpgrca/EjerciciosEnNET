using System;
using NUnit.Framework;
using ReturnClosestNumberMultipleOf10.Logic;

[TestFixture]
public class KataTest
{
    private Random random = new Random();
    private Kata kata = new Kata();

    public int Solution(int num)
    {
        return (int)Math.Round(num / 10.0, MidpointRounding.AwayFromZero) * 10;
    }

    [Test]
    public void _0_ShouldReturn10ForNumbersFrom10To14()
    {
        for (int i = 10; i <= 14; ++i)
        {
            Assert.AreEqual(10, kata.ClosestMultiple10(i));
        }
    }

    [Test]
    public void _1_ShouldReturn20ForNumbersFrom15To20()
    {
        for (int i = 15; i <= 20; ++i)
        {
            Assert.AreEqual(20, kata.ClosestMultiple10(i));
        }
    }

    [Test]
    public void _2_RandomTests()
    {
        for (int i = 1337; i < 13337; i += 333 + random.Next(0, 10))
        {
            Assert.AreEqual(Solution(i), kata.ClosestMultiple10(i));
        }
    }
}