namespace Solution;

using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ExclamationMarksSeries6.Logic;

[TestFixture]
public class SolutionTest
{
    private static Random rng = new Random();

    [Test, Description("It should work for basic tests")]
    public void SampleTest()
    {
        Action[] tests = new Action[]
        {
            () => Assert.AreEqual("Hi", Kata.Remove("Hi!", 1)),
            () => Assert.AreEqual("Hi", Kata.Remove("Hi!", 100)),
            () => Assert.AreEqual("Hi!!", Kata.Remove("Hi!!!", 1)),
            () => Assert.AreEqual("Hi", Kata.Remove("Hi!!!", 100)),
            () => Assert.AreEqual("Hi", Kata.Remove("!Hi", 1)),
            () => Assert.AreEqual("Hi!", Kata.Remove("!Hi!", 1)),
            () => Assert.AreEqual("Hi", Kata.Remove("!Hi!", 100)),
            () => Assert.AreEqual("!!Hi !!hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 1)),
            () => Assert.AreEqual("Hi !!hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 3)),
            () => Assert.AreEqual("Hi hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 5)),
            () => Assert.AreEqual("Hi hi hi", Kata.Remove("!!!Hi !!hi!!! !hi", 100)),
        };
        tests.OrderBy(x => rng.Next()).ToList().ForEach(a => a.Invoke());
    }

    private static string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ     !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";

    [Test, Description("It should work for random tests too")]
    public void RandomTest()
    {
        for (int i = 0; i < 100; ++i)
        {
            int length = rng.Next(4, 101);
            StringBuilder sb = new StringBuilder(length);
            for (int j = 0; j < sb.Capacity; ++j)
            {
                sb.Append(chars[rng.Next(0, chars.Length)]);
            }
            string test = sb.ToString();
            int num = rng.Next(1, 101);
            string expected = new Regex("!").Replace(test, "", num);
            string actual = Kata.Remove(test, num);
            Assert.AreEqual(expected, actual);
        }
    }

    [Test, Description("<font color='#00aa00' size=2><b>I'm waiting for your <font color='#dddd00'>feedback, rank and vote.<font color='#00aa00'>many thanks! ;-)</b></font>")]
    public void Advertisement()
    {
    }
}