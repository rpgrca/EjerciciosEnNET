namespace Solution;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using CharacterFrequency.Logic;

[TestFixture]
public class Random_Tests
{
    private static Random rnd = new Random();

    [Test, Description("Random Tests")]
    public void RandomTests()
    {
        const int Tests = 100;

        for (int i = 0; i < Tests; ++i)
        {
            string test = String.Concat(new string[200].Select(_ => (char)rnd.Next(32, 127)));

            Dictionary<char, int> expected = Solution.CharFreq(test);
            Dictionary<char, int> actual = Kata.CharFreq(test);

            Assert.AreEqual(expected, actual, String.Format("Expected: {0}\n  Actual: {1}", Debug.DictionaryToJson(expected), Debug.DictionaryToJson(actual)));
        }
    }
}