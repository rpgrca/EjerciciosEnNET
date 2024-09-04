using HighestAndLowest.Logic;
using NUnit.Framework;

namespace HighestAndLowest.UnitTests;

[TestFixture]
public class ExampleTests
{
  [Test]
  public void Test1()
  {
    Assert.AreEqual("42 -9", Kata.HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
  }
  [Test]
  public void Test2()
  {
    Assert.AreEqual("3 1", Kata.HighAndLow("1 2 3"));
  }
}
