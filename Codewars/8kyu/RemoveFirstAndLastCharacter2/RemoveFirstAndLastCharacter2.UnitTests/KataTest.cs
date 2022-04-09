using System;
using System.Linq;
using NUnit.Framework;
using RemoveFirstAndLastCharacter2.Logic;

namespace RemoveFirstAndLastCharacter2.UnitTests;

public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(null, Kata.Array(""));
        Assert.AreEqual(null, Kata.Array("1"));
        Assert.AreEqual(null, Kata.Array("1, 3"));
        Assert.AreEqual("2", Kata.Array("1,2,3"));
        Assert.AreEqual("2 3", Kata.Array("1,2,3,4"));
    }

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 300; i++)
        {
            var str = RandomString();
            var expected = Solution(str);
            var message = FailureMessage(str, expected);
            var actual = Kata.Array(str);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string Solution(string s)
    {
        var arr = s.Split(",");
        return arr.Length > 2 ? string.Join(" ", arr[1..^1]) : null;
    }

    private static readonly Random Rand = new Random();
    private const string Chars = "abcdef123456";

    private static string RandomString()
    {
        return string.Join(",", Enumerable.Range(0, Rand.Next(15))
            .Select(x =>
                string.Concat(Enumerable.Range(0, Rand.Next(1, 4)).Select(i => Chars[Rand.Next(Chars.Length)]))));
    }

    private static string FailureMessage(string str, string value)
    {
        return $"Should return {value ?? "null"} with \"{str}\"";
    }
}