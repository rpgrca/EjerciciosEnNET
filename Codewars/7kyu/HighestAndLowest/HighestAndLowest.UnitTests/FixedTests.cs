using HighestAndLowest.Logic;

namespace HighestAndLowest.UnitTests;

[TestFixture]
public class FixedTests
{
  [Test]
  public void SomeTest()
  {
    Assert.AreEqual("542 -214", Kata.HighAndLow("4 5 29 54 4 0 -214 542 -64 1 -3 6 -6"));
  }
  
  [Test]
  public void SortTest()
  {
    Assert.AreEqual("10 -20", Kata.HighAndLow("10 2 -1 -20"));
  }
  
  [Test]
  public void PlusMinusTest()
  {
    Assert.AreEqual("1 -1", Kata.HighAndLow("1 -1"));
  }
  
  [Test]
  public void PlusPlusTest()
  {
    Assert.AreEqual("1 1", Kata.HighAndLow("1 1"));
  }
  
  [Test]
  public void MinusMinusTest()
  {
    Assert.AreEqual("-1 -1", Kata.HighAndLow("-1 -1"));
  }
  
  [Test]
  public void PlusMinusZeroTest()
  {
    Assert.AreEqual("1 -1", Kata.HighAndLow("1 -1 0"));
  }
  
  [Test]
  public void PlusPlusZeroTest()
  {
    Assert.AreEqual("1 0", Kata.HighAndLow("1 1 0"));
  }
  
  [Test]
  public void MinusMinusZeroTest()
  {
    Assert.AreEqual("0 -1", Kata.HighAndLow("-1 -1 0"));
  }
  
  [Test]
  public void SingleTest()
  {
    Assert.AreEqual("42 42", Kata.HighAndLow("42"));
  }
}
