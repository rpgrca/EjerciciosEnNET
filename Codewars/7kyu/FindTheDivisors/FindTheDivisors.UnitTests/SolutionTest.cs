using FindTheDivisors.Logic;
using NUnit.Framework;
using System;

namespace FindTheDivisors.UnitTests;

[TestFixture]
public class SolutionTest
{
  [Test]
  public void SampleTest()
  {
    Assert.AreEqual(new int[] {3, 5}, Kata.Divisors(15), "n = 15");
    Assert.AreEqual(new int[] {2, 4, 8}, Kata.Divisors(16), "n = 16");
    Assert.AreEqual(new int[] {11, 23}, Kata.Divisors(253), "n = 253");
    Assert.AreEqual(new int[] {2, 3, 4, 6, 8, 12}, Kata.Divisors(24), "n = 24");
    Assert.AreEqual(null, Kata.Divisors(7), "n = 7");
  }
}