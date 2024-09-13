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
}