using NUnit.Framework;
using System;
using System.Linq;
using NarcissisticNumbers.Logic;

[TestFixture]
class Tests
{
    [TestCase(1)]
    [TestCase(153)]
    [TestCase(370)]
    [TestCase(371)]
    [TestCase(407)]
    [TestCase(1634)]
    [TestCase(8208)]
    [TestCase(9474)]
    [TestCase(54748)]
    [TestCase(92727)]
    [TestCase(93084)]
    [TestCase(548834)]
    [TestCase(1741725)]
    [TestCase(4210818)]
    [TestCase(9800817)]
    [TestCase(9926315)]
    [TestCase(24678050)]
    [TestCase(88593477)]
    [TestCase(146511208)]
    [TestCase(472335975)]
    [TestCase(534494836)]
    [TestCase(912985153)]
    [TestCase(4679307774)]
    public void TrueTests(long n)
    {
        Assert.IsTrue(Kata.IsNarcissistic(n));
    }

    [TestCase(435)]
    [TestCase(324)]
    [TestCase(4328)]
    [TestCase(3248)]
    [TestCase(234229983)]
    [TestCase(26548238692458)]
    [TestCase(11513221922401)]
    public void FalseTests(long n)
    {
        Assert.IsFalse(Kata.IsNarcissistic(n));
    }

    [Test]
    public void RandomTests()
    {
        var rnd = new Random();
        var limit = (int)Math.Pow(10,8);
        for (int i = 0; i < 40; i++)
        {
            var n = (long)rnd.Next(0, limit);
            Assert.That(Kata.IsNarcissistic(n), Is.EqualTo(SolutionIsNarcissistic(n)));
        }
    }
    bool SolutionIsNarcissistic(long n) => n.ToString().Select(x => (long)Math.Pow(char.GetNumericValue(x), n.ToString().Length)).Sum() == n;
}