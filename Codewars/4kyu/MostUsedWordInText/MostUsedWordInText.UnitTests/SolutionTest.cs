using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MostUsedWordInText.Logic;

namespace MostUsedWordInText.UnitTests;

public class SolutionTest
{

    [Test]
    public void SampleTests()
    {
        Assert.AreEqual(new List<string> { "e", "d", "a" }, TopWords.Top3("a a a  b  c c  d d d d  e e e e e"));
        Assert.AreEqual(new List<string> { "e", "ddd", "aa" }, TopWords.Top3("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"));
        Assert.AreEqual(new List<string> { "won't", "wont" }, TopWords.Top3("  //wont won't won't "));
        Assert.AreEqual(new List<string> { "e" }, TopWords.Top3("  , e   .. "));
        Assert.AreEqual(new List<string> { }, TopWords.Top3("  ...  "));
        Assert.AreEqual(new List<string> { }, TopWords.Top3("  '  "));
        Assert.AreEqual(new List<string> { }, TopWords.Top3("  '''  "));
        Assert.AreEqual(new List<string> { "a", "of", "on" }, TopWords.Top3(
            string.Join("\n", new string[]{"In a village of La Mancha, the name of which I have no desire to call to",
                  "mind, there lived not long since one of those gentlemen that keep a lance",
                  "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
                  "coursing. An olla of rather more beef than mutton, a salad on most",
                  "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
                  "on Sundays, made away with three-quarters of his income." })));
    }
}