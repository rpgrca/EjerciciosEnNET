using System;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class ScoreTests
{
    private static Random rand = new Random();

    private static void Tester (BigInteger inp, BigInteger exp)
    {
        Assert.AreEqual(exp, BinaryScore.Logic.BinaryScore.Score(inp));
    }

    private static BigInteger RandBigInteger(BigInteger min, BigInteger max)
    {
        var res = new BigInteger();
        while(res <= (max - min))
        {
            if(rand.Next(2) % 2 == 0)
            {
                res += new BigInteger(rand.Next());
            }
            else
            {
                res *= new BigInteger(rand.Next());
            }
        }
        return (res % (max - min + 1)) + min;
    }
    private static BigInteger Ans (BigInteger n)
    {
        return n > 0 ? BigInteger.Pow(new BigInteger(2), (int)BigInteger.Log(n, 2) + 1) - 1 : n;
    }
    [Test]
    public void BasicTests ()
    {
        Tester(BigInteger.Parse("0"), BigInteger.Parse("0"));
        Tester(BigInteger.Parse("1"), BigInteger.Parse("1"));
        Tester(BigInteger.Parse("2"), BigInteger.Parse("3"));
        Tester(BigInteger.Parse("49"), BigInteger.Parse("63"));
        Tester(BigInteger.Parse("1000000"), BigInteger.Parse("1048575"));
        Tester(BigInteger.Parse("10000000"), BigInteger.Parse("16777215"));
    }
    [Test]
    public void RandomTests ()
    {
        for(int i = 0; i < 100; i++)
        {
            BigInteger n = RandBigInteger(BigInteger.Parse("0"), BigInteger.Parse("100000"));
            Tester(n, Ans(n));
        }
        for(int i = 0; i < 100; i++)
        {
            BigInteger n = RandBigInteger(BigInteger.Parse("100000"), BigInteger.Parse("100000000"));
            Tester(n, Ans(n));
        }
        for(int i = 0; i < 100; i++)
        {
            BigInteger n = RandBigInteger(BigInteger.Parse("1000000000"), BigInteger.Parse("100000000000000"));
            Tester(n, Ans(n));
        }
        for(int i = 0; i < 100; i++)
        {
            BigInteger n = RandBigInteger(BigInteger.Parse("1000000000000000"), BigInteger.Parse("1000000000000000000000"));
            Tester(n, Ans(n));
        }
    }
}