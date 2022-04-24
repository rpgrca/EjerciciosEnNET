namespace Solution;

using NUnit.Framework;
using System;
using System.Linq;
using ReversingWordsInString.Logic;

[TestFixture]
public class KataTests
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual("World Hello", Kata.Reverse("Hello World"));
        Assert.AreEqual("There. Hi", Kata.Reverse("Hi There."));

        Assert.AreEqual("this at expert an am I", Kata.Reverse("I am an expert at this"));
        Assert.AreEqual("easy so is This", Kata.Reverse("This is so easy"));
        Assert.AreEqual("cares one no", Kata.Reverse("no one cares"));
        Assert.AreEqual("", Kata.Reverse(""));
        Assert.AreEqual("CodeWars", Kata.Reverse("CodeWars"));

        Assert.AreEqual("World  Hello", Kata.Reverse("Hello  World"));
    }

    [Test]
    public void RandomTests()
    {
        var rand = new Random();
        Func<string,string> sol = s => string.Join(" ", s.Split(' ').Reverse());
        var chars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        for (var i=0;i<40;i++)
        {
            var text = string.Join(" ", Enumerable.Range(1, rand.Next(3,13)).Select(a => string.Concat(Enumerable.Range(5,rand.Next(8,21)).Select(b => chars[rand.Next(0, chars.Length)]))));
            Assert.AreEqual(sol(text), Kata.Reverse(text),"It should work for random inputs too");
        }
    }
}