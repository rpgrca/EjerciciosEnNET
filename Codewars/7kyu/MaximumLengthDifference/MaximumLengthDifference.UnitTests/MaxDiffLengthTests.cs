using System;
using NUnit.Framework;
using MaximumLengthDifference.Logic;

[TestFixture]
public static class MaxDiffLengthTests
{
    private static Random rnd = new Random();

    [Test]
    public static void test1()
    {
        string[] s1 = new string[]{"hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz"};
        string[] s2 = new string[]{"cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww"};
        Assert.AreEqual(13, MaxDiffLength.Mxdiflg(s1, s2)); // 13
        s1 = new string[]{"ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh"};
        s2 = new string[]{"bbbaaayddqbbrrrv"};
        Assert.AreEqual(10, MaxDiffLength.Mxdiflg(s1, s2)); // 10
        s1 = new string[]{"ccct", "tkkeeeyy", "ggiikffsszzoo", "nnngssddu", "rrllccqqqqwuuurdd", "kkbbddaakkk"};
        s2 = new string[]{"tttxxxxxxgiiyyy", "ooorcvvj", "yzzzhhhfffaaavvvpp", "jjvvvqqllgaaannn", "tttooo", "qmmzzbhhbb"};
        Assert.AreEqual(14, MaxDiffLength.Mxdiflg(s1, s2)); // 14  
        s1 = new String[]{};
        s2 = new String[]{"bbbaaayddqbbrrrv"};
        Assert.AreEqual(-1, MaxDiffLength.Mxdiflg(s1, s2));
        s1 = new String[]{"ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh"};
        s2 = new String[]{};
        Assert.AreEqual(-1, MaxDiffLength.Mxdiflg(s1, s2));
        s1 = new String[]{};
        s2 = new String[]{};
        Assert.AreEqual(-1, MaxDiffLength.Mxdiflg(s1, s2));
    }

    //-----------------------
    public static string[] DoEx(int k)
    {
        string[] a1 = new string[k];
        for (int u = 0; u < k; u++)
        {
            string res = "";
            int n = -1;
            for (int i = 0; i < rnd.Next(1, 15); i++)
            {
                n = rnd.Next(97, 122); 
                for (int j = 0; j < rnd.Next(1, 4); j++)
                    res += (char)n;
            }
            a1[u] = res;
        }
        return a1;
    }

    public static int MxdiflgSol(string[] a1, string[] a2)
    {
        int mx = -1;
        foreach (string x in a1)
            foreach (string y in a2) 
            {
                int diff = Math.Abs(x.Length - y.Length);
                if (diff > mx)
                    mx = diff;
            }
        return mx;
    }
    //-----------------------
    [Test]
    public static void RandomTest()
    {
        Console.WriteLine("100 Random Tests MaxDifLength");
        for (int i = 0; i < 100; i++) { 
            string[] s1 = DoEx(rnd.Next(1, 10));
            string[] s2 = DoEx(rnd.Next(1, 8));
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //Console.WriteLine(MxdiflgSol(s1, s2));
            //Console.WriteLine("****");
            Assert.AreEqual(MxdiflgSol(s1, s2), MaxDiffLength.Mxdiflg(s1, s2));
        }
    }
}