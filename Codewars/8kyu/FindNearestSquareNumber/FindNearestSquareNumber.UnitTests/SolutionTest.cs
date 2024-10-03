using FindNearestSquareNumber.Logic;
using NUnit.Framework;
using System;

namespace FindNearestSquareNumber.UnitTests;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void SampleTest()
    {
        Assert.That(Kata.NearestSq(1), Is.EqualTo(1));
        Assert.That(Kata.NearestSq(2), Is.EqualTo(1));
        Assert.That(Kata.NearestSq(10), Is.EqualTo(9));
        Assert.That(Kata.NearestSq(111), Is.EqualTo(121));
        Assert.That(Kata.NearestSq(9999), Is.EqualTo(10000));
    }
}