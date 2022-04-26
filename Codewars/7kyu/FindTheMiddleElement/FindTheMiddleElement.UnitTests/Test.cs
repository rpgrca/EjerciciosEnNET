namespace Solution {
  using NUnit.Framework;
  using System;
  using FindTheMiddleElement.Logic;

  [TestFixture]
  public class Test
  {
    [Test]
    public void SampleTests()
    {
      Assert.AreEqual(0, Kata.Gimme(new double[] {2, 3, 1}));
      Assert.AreEqual(1, Kata.Gimme(new double[] {5, 10, 14}));
    }
  }
}