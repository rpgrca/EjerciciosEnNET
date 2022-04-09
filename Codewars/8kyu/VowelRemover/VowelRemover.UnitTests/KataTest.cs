using System;
using NUnit.Framework;
using VowelRemover.Logic;

[TestFixture]
public class KataTest
{
  [Test]
  public void Test1()
  {
    KataTest.Assert("hello", "hll");
    KataTest.Assert("how are you today?", "hw r y tdy?");
    KataTest.Assert("complain", "cmpln");
    KataTest.Assert("never", "nvr");
  }

  private static void Assert(string input, string expected)
  {
      var result = Kata.Shortcut(input);
      NUnit.Framework.Assert.AreEqual(expected, result, String.Format("Expected \"{0}\" but got \"{1}\"", expected, result));
  }
}