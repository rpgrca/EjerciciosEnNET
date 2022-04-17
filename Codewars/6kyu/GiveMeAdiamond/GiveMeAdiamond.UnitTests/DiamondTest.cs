using System;
using System.Text;
using NUnit.Framework;
using GiveMeAdiamond.Logic;

[TestFixture]
public class DiamondTest
{
    private readonly Random random = new Random();

    [Test]
    public void TestZero()
    {
        Assert.IsNull(Diamond.Print(0));
    }

    [Test]
    public void TestNegativeInput()
    {
        for (int i = 0; i < 10; i++)
        {
            int n = -random.Next(20);
            Assert.IsNull(Diamond.Print(n));
        }
    }

    [Test]
    public void TestEvenInput()
    {
        for (int i = 0; i < 10; i++)
        {
            int n = random.Next(20) * 2;
            Assert.IsNull(Diamond.Print(n));
        }
    }

    [Test]
    public void TestDiamond3()
    {
        var expected = new StringBuilder();
        expected.Append(" *\n");
        expected.Append("***\n");
        expected.Append(" *\n");

        Assert.AreEqual(expected.ToString(), Diamond.Print(3));
    }

    [Test]
    public void TestDiamond5()
    {
        var expected = new StringBuilder();
        expected.Append("  *\n");
        expected.Append(" ***\n");
        expected.Append("*****\n");
        expected.Append(" ***\n");
        expected.Append("  *\n");

        Assert.AreEqual(expected.ToString(), Diamond.Print(5));
    }

    [Test]
    public void TestDiamond15()
    {
        var expected = new StringBuilder();
        expected.Append("       *\n");
        expected.Append("      ***\n");
        expected.Append("     *****\n");
        expected.Append("    *******\n");
        expected.Append("   *********\n");
        expected.Append("  ***********\n");
        expected.Append(" *************\n");
        expected.Append("***************\n");
        expected.Append(" *************\n");
        expected.Append("  ***********\n");
        expected.Append("   *********\n");
        expected.Append("    *******\n");
        expected.Append("     *****\n");
        expected.Append("      ***\n");
        expected.Append("       *\n");

        Assert.AreEqual(expected.ToString(), Diamond.Print(15));
    }
}