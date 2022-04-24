using System;
using NUnit.Framework;
using OnlineRpgPlayerToQualifyingStage.Logic;

[TestFixture]
public class PlayerRankUp
{
    [Test]
    public static void Test64()
    {
        Assert.AreEqual(Kata.PlayerRankUp(64), false);
    }

    [Test]
    public static void Test101()
    {
        Assert.AreEqual(Kata.PlayerRankUp(101), "Well done! You have advanced to the qualifying stage. Win 2 out of your next 3 games to rank up.");
    }
}