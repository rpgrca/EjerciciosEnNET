using NUnit.Framework;
using SumOfSequence.Logic;
using System;

namespace SumOfSequence.UnitTests;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void BasicTest()
    {
        Assert.AreEqual(12, Kata.SequenceSum(2, 6, 2));
        Assert.AreEqual(15, Kata.SequenceSum(1, 5, 1));
        Assert.AreEqual(5, Kata.SequenceSum(1, 5, 3));
        Assert.AreEqual(45, Kata.SequenceSum(0, 15, 3));
        Assert.AreEqual(0, Kata.SequenceSum(16, 15, 3));
        Assert.AreEqual(26, Kata.SequenceSum(2, 24, 22));
        Assert.AreEqual(2, Kata.SequenceSum(2, 2, 2));
        Assert.AreEqual(2, Kata.SequenceSum(2, 2, 1));
        Assert.AreEqual(35, Kata.SequenceSum(1, 15, 3));
        Assert.AreEqual(0, Kata.SequenceSum(15, 1, 3));
    }

    [Test]
    public void RandomTests()
    {
        Random rand = new Random();

        for (int i = 1; i <= 100; i++)
        {
            int start = rand.Next(500 * i);
            int end = rand.Next(1000 * i);
            int step = rand.Next(1,10 * i);
            var expected = MyCode(start,end,step);
            var actual = Kata.SequenceSum(start,end,step);
            Assert.AreEqual(expected, actual);
            Console.WriteLine($"{start} .. {end} |{step}| = {actual}");
        }
    }

    private int MyCode(int start, int end, int step) => (start > end ? 0 : ((end -= (end - start) % step) + start) * (1 + (end - start) / step) / 2);
}