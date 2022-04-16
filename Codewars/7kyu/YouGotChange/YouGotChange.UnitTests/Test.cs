namespace Solution;

using NUnit.Framework;
using System;
using YouGotChange.Logic;

[TestFixture]
public class Test
{
    [Test]
    public void BasicTest()
    {
        Assert.AreEqual(new int[] {0, 1, 1, 0, 1, 3}, Kata.GiveChange(365));
        Assert.AreEqual(new int[] {2, 1, 1, 0, 0, 2}, Kata.GiveChange(217));
    }

    [Test]
    public void ZeroTest()
    {
        Assert.AreEqual(new int[] {0, 0, 0, 0, 0, 0}, Kata.GiveChange(0));
    }

    private int[] Solution(int amount)
    {
        int[] arr = new int[] {0, 0, 0, 0, 0, 0};

        while (amount >= 100) {
            amount -= 100;
            ++arr[5];
        }

        while (amount >= 50) {
            amount -= 50;
            ++arr[4];
        }

        while (amount >= 20) {
            amount -= 20;
            ++arr[3];
        }

        while (amount >= 10) {
            amount -= 10;
            ++arr[2];
        }

        while (amount >= 5) {
            amount -= 5;
            ++arr[1];
        }

        while (amount >= 1) {
            amount -= 1;
            ++arr[0];
        }

        return arr;
    }

    private static Random rnd = new Random();

    [Test]
    public void RandomTest()
    {
        for (int i = 0; i < 100; ++i)
        {
            int randAmount = rnd.Next(0, 10001);
            Assert.AreEqual(Solution(randAmount), Kata.GiveChange(randAmount));
        }
    }
}