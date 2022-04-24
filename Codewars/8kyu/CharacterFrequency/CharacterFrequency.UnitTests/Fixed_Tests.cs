namespace Solution;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using CharacterFrequency.Logic;

[TestFixture]
public class Fixed_Tests
{
    private static string[] testCases = new string[]
    {
        "How can mirrors be real when our eyes aren't real?",
        "Everybody dance now!",
        "Can I haz cheezburger?",
        "Everybody do the flop!",
        "Io sono giovanni rana!",
        "It's-a me, Mario!",
        "The End ( of the line ) "
    };

    [Test, TestCaseSource("testCases")]
    public void Test(string test)
    {
        Dictionary<char, int> expected = Solution.CharFreq(test);
        Dictionary<char, int> actual = Kata.CharFreq(test);

        Assert.AreEqual(expected, actual, String.Format("Expected: {0}\n  Actual: {1}", Debug.DictionaryToJson(expected), Debug.DictionaryToJson(actual)));
    }
}