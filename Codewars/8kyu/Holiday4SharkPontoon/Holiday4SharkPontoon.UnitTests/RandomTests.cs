namespace Solution;

using NUnit.Framework;
using System;
using Holiday4SharkPontoon.Logic;

[TestFixture]
public class RandomTests
{
    private static string sol(int pd, int sd, int ys, int ss, bool d)
    {
        double yt = 1.0 * pd / ys;
        double st = sd * (d ? 2.0 : 1.0) / ss;
        return yt < st ? "Alive!" : "Shark Bait!";
    }

    [Test]
    public void RandomTest()
    {
        Random rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            int pd = rand.Next(1, 50);
            int sd = rand.Next(1, 200);
            int ys = rand.Next(1, 4);
            int ss = rand.Next(1, 20);
            bool d = rand.Next(0, 1) == 1;
            Assert.AreEqual(sol(pd, sd, ys, ss, d), Kata.Shark(pd, sd, ys, ss, d), $"Shark({pd}, {sd}, {ys}, {ss}, {d})");
        }
    }
}