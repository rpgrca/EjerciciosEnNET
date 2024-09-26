using IpValidation.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IpValidation.UnitTests;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void TestCases()
    {
        Assert.AreEqual(true, Kata.IsValidIp("0.0.0.0"));
        Assert.AreEqual(true, Kata.IsValidIp("12.255.56.1"));
        Assert.AreEqual(true, Kata.IsValidIp("137.255.156.100"));

        Assert.AreEqual(false, Kata.IsValidIp(""));
        Assert.AreEqual(false, Kata.IsValidIp("abc.def.ghi.jkl"));
        Assert.AreEqual(false, Kata.IsValidIp("123.456.789.0"));
        Assert.AreEqual(false, Kata.IsValidIp("12.34.56"));
        Assert.AreEqual(false, Kata.IsValidIp("12.34.56.00"));
        Assert.AreEqual(false, Kata.IsValidIp("12.34.56.7.8"));
        Assert.AreEqual(false, Kata.IsValidIp("12.34.256.78"));
        Assert.AreEqual(false, Kata.IsValidIp("1234.34.56"));
        Assert.AreEqual(false, Kata.IsValidIp("pr12.34.56.78"));
        Assert.AreEqual(false, Kata.IsValidIp("12.34.56.78sf"));
        Assert.AreEqual(false, Kata.IsValidIp("12.34.56 .1"));
        Assert.AreEqual(false, Kata.IsValidIp("12.34.56.-1"));
        Assert.AreEqual(false, Kata.IsValidIp("123.045.067.089"));
    }
}