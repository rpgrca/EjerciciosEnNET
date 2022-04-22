using System;
using NUnit.Framework;
using MaximumLengthDifference.Logic;

[TestFixture]
public static class MaxDiffLengthTests
{
    [Test]
    public static void test1()
    {
        string[] s1 = new string[]{"hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz"};
        string[] s2 = new string[]{"cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww"};
        Assert.AreEqual(13, MaxDiffLength.Mxdiflg(s1, s2));
    }
}