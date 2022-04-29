namespace Solution {
  using NUnit.Framework;
  using System;
  using Holiday4SharkPontoon.Logic;

  [TestFixture]
  public class BasicTests
  {
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual("Alive!", Kata.Shark(12, 50, 4, 8, true));
      Assert.AreEqual("Alive!", Kata.Shark(12, 50, 4, 8, false));
      Assert.AreEqual("Alive!", Kata.Shark(7, 55, 4, 16, true));
      Assert.AreEqual("Shark Bait!", Kata.Shark(24, 0, 4, 8, true));
      Assert.AreEqual("Shark Bait!", Kata.Shark(40, 35, 3, 20, true));
      Assert.AreEqual("Alive!", Kata.Shark(7, 8, 3, 4, true));
      Assert.AreEqual("Shark Bait!", Kata.Shark(7, 8, 3, 4, false));
    }
  }
}