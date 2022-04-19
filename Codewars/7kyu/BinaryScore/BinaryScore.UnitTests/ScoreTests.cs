using System.Numerics;
using NUnit.Framework;

public class ScoreTests
{
    private static void Tester (BigInteger inp, BigInteger exp)
    {
        Assert.AreEqual(exp, BinaryScore.Logic.BinaryScore.Score(inp));
    }

    [Test]
    public void ExampleTests ()
    {
        Tester(BigInteger.Parse("0"), BigInteger.Parse("0"));
        Tester(BigInteger.Parse("1"), BigInteger.Parse("1"));
        Tester(BigInteger.Parse("49"), BigInteger.Parse("63"));
        Tester(BigInteger.Parse("1000000"), BigInteger.Parse("1048575"));
    }
}