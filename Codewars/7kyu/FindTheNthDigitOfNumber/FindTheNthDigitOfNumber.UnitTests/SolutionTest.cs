namespace Solution;

using NUnit.Framework;
using System;
using System.Linq;
using FindTheNthDigitOfNumber.Logic;

[TestFixture]
public class SolutionTest
{
    private static Random rnd = new Random();

    private static int Solution(int num, int nth)
    {
        if (nth < 1) return -1;
        if (nth == 1) return Math.Abs(num % 10);
        return Solution(num / 10, --nth);
    }

    [Test, Description("Normal Values")]
    public void SampleTest()
    {
        Action[] tests = new Action[]
        {
            () => Assert.AreEqual(5, Kata.FindDigit(5673, 4)),
            () => Assert.AreEqual(2, Kata.FindDigit(129, 2)),
            () => Assert.AreEqual(8, Kata.FindDigit(-2825, 3)),
            () => Assert.AreEqual(0, Kata.FindDigit(-456, 4)),
            () => Assert.AreEqual(0, Kata.FindDigit(0, 20)),
            () => Assert.AreEqual(-1, Kata.FindDigit(65, 0)),
            () => Assert.AreEqual(-1, Kata.FindDigit(24, -8)),
        };

        tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }

    [Test, Description("Num is Negative")]
    public void NumNegativeTest()
    {
        Action[] tests = new Action[]
        {
            () => Assert.AreEqual(3, Kata.FindDigit(-1234, 2)),
            () => Assert.AreEqual(0, Kata.FindDigit(-5540, 1)),
        };

        tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }

    [Test, Description("Nth is not Positive")]
    public void NthNegativeTest()
    {
        Action[] tests = new Action[]
        {
            () => Assert.AreEqual(-1, Kata.FindDigit(678998, 0)),
            () => Assert.AreEqual(-1, Kata.FindDigit(-67854, -57)),
            () => Assert.AreEqual(-1, Kata.FindDigit(0, -3)),
        };

        tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }

    [Test, Description("Random Tests")]
    public void RandomTest()
    {
        for (int i = 0; i < 100; ++i)
        {
            int num = rnd.Next(0, 10000000);
            int nth = rnd.Next(-2, 6);
            int expected = Solution(num, nth);
            int actual = Kata.FindDigit(num, nth);
            Assert.AreEqual(expected, actual);
        }
    }
}