namespace Solution; 

using NUnit.Framework;
using System;
using FindTheNthDigitOfNumber.Logic;

[TestFixture]
public class SolutionTest
{
[Test]
public void SampleTest()
{
  Assert.AreEqual(5, Kata.FindDigit(5673, 4));
  Assert.AreEqual(2, Kata.FindDigit(129, 2));
  Assert.AreEqual(8, Kata.FindDigit(-2825, 3));
  Assert.AreEqual(0, Kata.FindDigit(-456, 4));
  Assert.AreEqual(0, Kata.FindDigit(0, 20));
  Assert.AreEqual(-1, Kata.FindDigit(65, 0));
  Assert.AreEqual(-1, Kata.FindDigit(24, -8));
}
}