using System;
using NUnit.Framework;
using CreditCardMask.Logic;

[TestFixture]
public class Tests
{
    [Test]
    public void ExamplesTests()
    {
        Assert.AreEqual("############5616", Kata.Maskify("4556364607935616"));
        Assert.AreEqual("1", Kata.Maskify("1"));
        Assert.AreEqual("#1111", Kata.Maskify("11111"));
    }

    [Test]
    public void RandomTests()
    {
        Func<string, string> solution = (cc) =>
        {
            return cc.Length <= 4 ? cc : new String('#', cc.Length - 4) + cc.Substring(cc.Length - 4);
        };
        Random rand = new Random();
        Func<string> randomToken = () =>
        {
            return rand.Next(1000, 9999).ToString();
        };

        for (int i = 0; i < 100; i++)
        {
            string t = randomToken() + randomToken() + randomToken() + randomToken();
            t = t.Substring(0, 1 + (rand.Next(1, 15) % t.Length));
            Assert.AreEqual(solution(t), Kata.Maskify(t));
        }
    }
}