namespace Tester {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using MaxDiffEasy.Logic;

  [TestFixture]
  public class TestingMaxDiff
  {
    [Test]
    public void SampleTests()
    {
      Assert.AreEqual( 6, Kata.MaxDiff(new[]{ 0, 1, 2, 3, 4, 5, 6 }));
      Assert.AreEqual(11, Kata.MaxDiff(new[] {-0, 1, 2, -3, 4, 5, -6}));
      Assert.AreEqual(16, Kata.MaxDiff(new[] {0, 1, 2, 3, 4, 5, 16}));
      Assert.AreEqual( 0, Kata.MaxDiff(new[] {16}));
      Assert.AreEqual( 0, Kata.MaxDiff(new int[] {}));
    }
  }
}