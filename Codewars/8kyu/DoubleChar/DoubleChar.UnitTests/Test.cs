using System;
using System.Linq;
using NUnit.Framework;
using DoubleChar.Logic;

namespace DoubleChar.UnitTests;

[TestFixture]
public class Test
{
    [Test]
    [TestCase("abcd", ExpectedResult="aabbccdd")]
    [TestCase("Adidas", ExpectedResult="AAddiiddaass")]
    [TestCase("1337", ExpectedResult="11333377")]
    [TestCase("illuminati", ExpectedResult="iilllluummiinnaattii")]
    [TestCase("123456", ExpectedResult="112233445566")]
    [TestCase("%^&*(", ExpectedResult="%%^^&&**((")]
    public static string FixedTest(string s)
    {
        return Kata.DoubleChar(s);
    }

    private static string Solution(string s)
    {
        return string.Join("", s.Select(x => "" + x + x));
    }

    [Test]
    public static void RandomTest([Random(1,30,100)] int len)
    {
        string s = RandomString(len, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!§$%&/()=0987654321");
        Assert.AreEqual(Solution(s), Kata.DoubleChar(s), string.Format("Should work for {0}", s));
    }

    private static string RandomString(int randStrLength, string allowedChars)
    {
        string randStr = string.Empty;
        Random r = new Random();
        for(int i = 0; i < randStrLength; i++)
        {
            randStr += allowedChars[r.Next(allowedChars.Length)];
        }
        return randStr;
    }
}