using NUnit.Framework;
using NarcissisticNumbers.Logic;

namespace NarcissisticNumbers.UnitTests;

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
}