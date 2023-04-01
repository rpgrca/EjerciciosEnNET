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
    
    [Test]
    public void FixedTests()
    {
        new List<string> {
        "a a a  b  c c  d d d d  e e e e e",
        "e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e",
        "  //wont won't won't ",
        "  , e   .. ",
        "  ...  ",
        "  '  ",
        "  '''  ",
        string.Join("\n",new string[]{"In a village of La Mancha, the name of which I have no desire to call to",
                  "mind, there lived not long since one of those gentlemen that keep a lance",
                  "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
                  "coursing. An olla of rather more beef than mutton, a salad on most",
                  "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
                  "on Sundays, made away with three-quarters of his income." }),

        "a a a  b  c c X",
        "a a c b b"}.ForEach(CustomAssert);
    }

    private static void CustomAssert(string s)
    {
        var re = new Regex("[a-z][a-z']*");

        var cnt = new Dictionary<string, int>();
        var matches = re.Matches(s.ToLower());
        foreach (Match match in matches)
        {
            var word = match.Value;
            var r = cnt.TryGetValue(word, out var o);
            if (r) cnt[word] = o + 1;
            else cnt.Add(word, 1);
        }

        var returnedResult = TopWords.Top3(s);
        var exp = new List<string>();
        var expF = new List<int>();
        var actualFreq = returnedResult.Select(ss => cnt.GetValueOrDefault(ss, 0)).ToList();
        cnt.OrderBy(x => x, Comparer<KeyValuePair<string, int>>.Create(Compare))
                                       .Take(3)
                                       .ToList()
                                       .ForEach(me =>
                                       {
                                           exp.Add(me.Key);
                                           expF.Add(me.Value);
                                       });
        var wrongWords = Enumerable.Range(0, returnedResult.Count)
                                             .Where(i => actualFreq[i] == 0)
                                             .Select(i => returnedResult[i])
                                             .ToList();
        var setSize = returnedResult.Distinct().Count();
        var msg = "";

        if (!(wrongWords.Count == 0))
            msg = $"Incorrect match: words not present in the string. Your output: {string.Join(", ", returnedResult)}. One possible valid answer: {string.Join(", ", exp)}";
        else if (returnedResult.Count != setSize)
            msg = $"The result should not contain copies of the same word. Your output {string.Join(", ", returnedResult)}. One posible output: {string.Join(", ", exp)}";
        else if (!actualFreq.SequenceEqual(expF))
            msg = $"Incorrect frequencies: {string.Join(", ", actualFreq)} should be {string.Join(", ", expF)}. Your output: {string.Join(", ", returnedResult)}. One possible output: {string.Join(", ", exp)}";

        Assert.IsTrue(string.IsNullOrEmpty(msg), msg);
    }

    private static int Compare(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
    {
        var cmpI = a.Value - b.Value;
        var cmpS = a.Key.CompareTo(b.Key);
        return cmpI != 0 ? -cmpI : cmpS;
    }

    //---------------------------
    private static string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'";
    private static string JOINER = "-,.?!_:;/          ";

    private Random rnd = new Random();

    private int Rand(int a, int b) => a + rnd.Next(b - a);
    private int Rand(int a) => rnd.Next(a);
    private string ChoiceChar(int x) => $"{CHARS[Rand(CHARS.Length - x)]}";
    private string ChoiceJoin() => $"{JOINER[Rand(JOINER.Length)]}";
    private string GenWord() => string.Concat(Enumerable.Range(0, Rand(3, 11)).Select(n => ChoiceChar(n == 0 ? 1 : 0)));
    private string GenJoiner() => string.Concat(Enumerable.Range(0, Rand(1, 5)).Select(n => ChoiceJoin()));
    private static void Shuffle<T>(List<T> deck)
    {
        var rnd = new Random();
        for (int n = deck.Count - 1; n > 0; --n)
        {
            int k = rnd.Next(n + 1);
            T temp = deck[n];
            deck[n] = deck[k];
            deck[k] = temp;
        }
    }

    [Test]
    public void RandomTests()
    {

        for (int i = 0; i < 100; i++)
        {
            var words = new List<string>();

            Enumerable.Range(0, 1 + Rand(20))
                     .Select(x => GenWord())
                     .ToList()
                     .ForEach(w => words.AddRange(Enumerable.Repeat(w, Rand(1, 31))));

            Shuffle(words);
            var sb = new StringBuilder();
            words.ForEach(w => sb.Append(w + ChoiceJoin()));
            var s = sb.ToString();
            CustomAssert(s);
        }
    }
}