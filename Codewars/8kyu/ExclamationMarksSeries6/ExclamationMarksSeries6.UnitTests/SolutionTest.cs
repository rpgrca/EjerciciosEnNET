namespace Solution;

using NUnit.Framework;
using System;
using ExclamationMarksSeries6.Logic;

[TestFixture]
public class SolutionTest
{
    [Test, Description("It should work for basic tests")]
    public void SampleTest()
    {
        Assert.AreEqual("Hi", Kata.Remove("Hi!", 1));
        Assert.AreEqual("Hi", Kata.Remove("Hi!", 100));
        Assert.AreEqual("Hi!!", Kata.Remove("Hi!!!", 1));
        Assert.AreEqual("Hi", Kata.Remove("Hi!!!", 100));
        Assert.AreEqual("Hi", Kata.Remove("!Hi", 1));
        Assert.AreEqual("Hi!", Kata.Remove("!Hi!", 1));
        Assert.AreEqual("Hi", Kata.Remove("!Hi!", 100));
        Assert.AreEqual("!!Hi !!hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 1));
        Assert.AreEqual("Hi !!hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 3));
        Assert.AreEqual("Hi hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 5));
        Assert.AreEqual("Hi hi hi", Kata.Remove("!!!Hi !!hi!!! !hi", 100));
    }
}