using NUnit.Framework;
using System;
using SubtractTheSum.Logic;

namespace SubtractTheSum.UnitTests;

[TestFixture]
public class TestTemplate
{
    [Test]
    public void Test1()
    {
        StringAssert.AreEqualIgnoringCase("apple", Kata.SubtractSum(11));
    }
}