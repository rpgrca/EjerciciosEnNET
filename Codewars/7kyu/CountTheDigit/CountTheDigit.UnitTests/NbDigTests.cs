using System;
using NUnit.Framework;
using CountTheDigit.Logic;

[TestFixture]
public static class NbDigTests
{
    private static Random rnd = new Random();

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
        testing(CountDig.NbDig(14550, 7), 8014);
        testing(CountDig.NbDig(8304, 7), 3927);
        testing(CountDig.NbDig(10576, 9), 7860);
        testing(CountDig.NbDig(12526, 1), 13558);
        testing(CountDig.NbDig(7856, 4), 7132);
        testing(CountDig.NbDig(14956, 1), 17267);
    }

    //-----------------------
    private static int NbDigSol(int n, int d)
    {
        int k = 0, cnt = 0;
        char c = d.ToString()[0];
        while (k <= n)
        {
            int a = 0;
            string s = (k*k).ToString();
            for(int i = 0; i < s.Length; i++)
                if(s[i] == c)
                    a++;
            if (a > 0)
                cnt += a;
            k++;
        }
        return cnt;
    }

    //-----------------------
    [Test]
    public static void RandomTest()
    {
        Console.WriteLine("100 Random Tests");
        for (int i = 0; i < 100; i++)
        {
            int n = rnd.Next(2000, 15000);
            int d = rnd.Next(0,9);
            int r = NbDigSol(n, d);
            //Console.WriteLine("n " + n + " d " + d + " --> " + r);
            testing(CountDig.NbDig(n, d), r);
        }
    }
}