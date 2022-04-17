using System;
using System.Text;
using NUnit.Framework;
using GiveMeAdiamond.Logic;

[TestFixture]
public class DiamondTest
{
	[Test]
	public void TestNull()
	{
		Assert.IsNull(Diamond.Print(0));
		Assert.IsNull(Diamond.Print(-2));
		Assert.IsNull(Diamond.Print(2));
	}

    [Test]
	public void TestDiamond1()
	{
		var expected = new StringBuilder();
		expected.Append("*\n");
		Assert.AreEqual(expected.ToString(), Diamond.Print(1));
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
}