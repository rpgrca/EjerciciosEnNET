using System;
using NUnit.Framework;
using CountTheDigit.Logic;

[TestFixture]
public static class NbDigTests 
{
    private static void testing(int actual, int expected)
    {
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public static void test1()
    {
        Console.WriteLine("Fixed Tests NbDig");
        testing(CountDig.NbDig(5750, 0), 4700);
        testing(CountDig.NbDig(11011, 2), 9481);
        testing(CountDig.NbDig(12224, 8), 7733);
        testing(CountDig.NbDig(11549, 1), 11905);
    }
}