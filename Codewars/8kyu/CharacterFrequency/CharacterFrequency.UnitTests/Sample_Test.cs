using NUnit.Framework;

namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using CharacterFrequency.Logic;

  public class Debug
  {
    public static string DictionaryToJson(Dictionary<char, int> dict)
    {
      IEnumerable<string> entries = dict.OrderBy(x => (int)x.Key).Select(d =>
          String.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
      return "{" + String.Join(",", entries) + "}";
    }
  }

  [TestFixture]
  public class Sample_Test
  {
    [Test]
    public void Test()
    {
      Dictionary<char, int> expected = new Dictionary<char, int> {{'a', 1}, {' ', 2}, {'c', 1}, {'e', 1}, {'I', 1}, {'k', 1}, {'l', 1}, {'i', 1}, {'s', 1}, {'t', 1}};
      Dictionary<char, int> actual = Kata.CharFreq("I like cats");

      Assert.AreEqual(expected, actual, String.Format("Expected: {0}\n  Actual: {1}", Debug.DictionaryToJson(expected), Debug.DictionaryToJson(actual)));
    }
  }
}