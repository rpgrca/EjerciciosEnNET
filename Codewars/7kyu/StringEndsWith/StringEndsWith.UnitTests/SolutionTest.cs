using NUnit.Framework;
using System;
using StringEndsWith.Logic;

namespace Solution;
[TestFixture]
public class SolutionTest
{
    private static object[] sampleTestCases = new object[]
    {
        new object[] {"samurai", "ai", true},
        new object[] {"sumo", "omo", false},
        new object[] {"ninja", "ja", true},
        new object[] {"sensei", "i", true},
        new object[] {"samurai", "ra", false},
        new object[] {"abc", "abcd", false},
        new object[] {"abc", "abc", true},
        new object[] {"abcabc", "bc", true},
        new object[] {"ails", "fails", false},
        new object[] {"fails", "ails", true},
        new object[] {"this", "fails", false},
        new object[] {"abc", "", true},
        new object[] {":-)", ":-(", false},
        new object[] {"!@#$%^&*() :-)", ":-)", true},
        new object[] {"abc\n", "abc", false},
    };

    [Test, TestCaseSource("sampleTestCases")]
    public void SampleTest(string str, string ending, bool expected)
    {
        Assert.AreEqual(expected, Kata.Solution(str, ending));
    }

    private static Random rnd = new Random();

    private static bool solution(string str, string ending)
    {
        if (str.Length - ending.Length < 0) { return false; }
        return str.Substring(str.Length - ending.Length) == ending;
    }

    private static string chars = "abcdefghijklmnopqrstuvwxyz";

    [Test, Description("Random Tests")]
    public void RandomTest()
    {
        for (int i = 0; i < 100; ++i)
        {
            string str = "";
            string ending = "";
            for (int j = 0; j < 8; ++j)
            {
                str += chars[rnd.Next(0, chars.Length)];
                ending += chars[rnd.Next(0, chars.Length)];
            }

            if (rnd.Next(0, 2) == 0) { ending = str.Substring(4); }

            bool expected = solution(str, ending);
            bool actual = Kata.Solution(str, ending);

            Assert.AreEqual(expected, actual);
        }
    }
}