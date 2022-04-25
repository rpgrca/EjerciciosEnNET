namespace CreditCardMask.UnitTests;

using NUnit.Framework;
using CreditCardMask.Logic;

[TestFixture]
public class Tests
{
  [Test]
  public void ExamplesTests()
  {
    Assert.AreEqual("############5616", Kata.Maskify("4556364607935616"));
    Assert.AreEqual("1", Kata.Maskify("1"));
    Assert.AreEqual("#1111", Kata.Maskify("11111"));
  }
}