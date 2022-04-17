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
		Assert.IsNull(Diamond.print(0));
		Assert.IsNull(Diamond.print(-2));
		Assert.IsNull(Diamond.print(2));
	}

    [Test]
	public void TestDiamond1()
	{
		var expected = new StringBuilder();
		expected.Append("*\n");
		Assert.AreEqual(expected.ToString(), Diamond.print(1));
	}

	[Test]
	public void TestDiamond3()
	{
		var expected = new StringBuilder();
		expected.Append(" *\n");
		expected.Append("***\n");
		expected.Append(" *\n");

		Assert.AreEqual(expected.ToString(), Diamond.print(3));
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

		Assert.AreEqual(expected.ToString(), Diamond.print(5));
	}
}