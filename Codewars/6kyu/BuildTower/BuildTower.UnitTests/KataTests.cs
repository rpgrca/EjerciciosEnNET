namespace Solution 
{
  using NUnit.Framework;
  using System;
  using BuildTower.Logic;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(string.Join(",", new [] { "*" }), string.Join(",", Kata.TowerBuilder(1)));
      Assert.AreEqual(string.Join(",", new [] { " * ", "***" }), string.Join(",", Kata.TowerBuilder(2)));
      Assert.AreEqual(string.Join(",", new [] { "  *  ", " *** ", "*****" }), string.Join(",", Kata.TowerBuilder(3)));
    }
  }
}