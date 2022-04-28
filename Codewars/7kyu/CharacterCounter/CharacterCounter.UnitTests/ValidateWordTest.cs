using NUnit.Framework;
using System;
using CharacterCounter.Logic;

[TestFixture]
public class ValidateWordTest
{
  [Test]
  public void GenericTests()
  {
    Assert.AreEqual(true,Kata.ValidateWord("abcabc"), "The word was: \"abcabc\"");
    Assert.AreEqual(true,Kata.ValidateWord("Abcabc"), "The word was: \"Abcabc\"");
    Assert.AreEqual(true,Kata.ValidateWord("abc123"), "The word was: \"abc123\"");
    Assert.AreEqual(false,Kata.ValidateWord("abcabcd"), "The word was: \"abcabcd\"");
    Assert.AreEqual(true,Kata.ValidateWord("abc!abc!"), "The word was: \"abc!abc!\"");
    Assert.AreEqual(false,Kata.ValidateWord("abc:abc"), "The word was: \"abc:abc\"");
  }
}