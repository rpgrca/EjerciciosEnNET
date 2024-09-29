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

    [Test]
    public void RandomTests()
    {
        string letters = "abcdefghijklm";
        Random rnd = new Random();

        for (int test = 0; test < 300; ++test) {

            List<string> parts = new List<string>();
            for (int i = 0; i < 4; ++i)
                parts.Add(rnd.Next(256).ToString());

            int pos = rnd.Next(4);
            string someLetters = letters.Substring(rnd.Next(4), rnd.Next(2) + 1);
            bool valid = false;
            int route = rnd.Next(12);
            switch (route)
            {
                case 0: valid = true; break;
                case 1: parts[pos] = ""; break;
                case 2: parts[pos] = someLetters; break;
                case 3: parts[pos] = rnd.Next(256, 300).ToString(); break;
                case 4: parts.RemoveAt(pos); break;
                case 5: parts.Add(rnd.Next(256).ToString()); break;
                case 6: parts[0] += someLetters; break;
                case 7: parts[3] += someLetters; break;
                case 8: parts[rnd.Next(1, 3)] += " "; break;
                case 9: parts[pos] = "-" + parts[pos]; break;
                case 10: parts[pos] = "0" + rnd.Next(0, 100); break;
                case 11: parts[pos] = "00"; break;
            }

            string ip = string.Join(".", parts);
            Assert.AreEqual(valid, Kata.IsValidIp(ip), "IP address: {0}", ip);
        }
    }
}