using ConvertStringToCamelCase.Logic;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ConvertStringToCamelCase.UnitTests;

[TestFixture]
public class KataTest
{
    public string Solution(string str)
    {
        return Regex.Replace(str, @"[_-](\w)", m => m.Groups[1].Value.ToUpper());
    }
  
    [Test]
    public void KataTests()
    {
        Assert.AreEqual("theStealthWarrior", Kata.ToCamelCase("the_stealth_warrior"), "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
        Assert.AreEqual("TheStealthWarrior", Kata.ToCamelCase("The-Stealth-Warrior"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
    }
  
    [Test]
    public void SimpleTests()
    {
        Assert.AreEqual("", Kata.ToCamelCase(""), "An empty string was provided but not returned");
        Assert.AreEqual("ABC", Kata.ToCamelCase("A-B-C"), "Kata.ToCamelCase('A-B-C') did not return correct value");
    }
  
    [Test]
    public void RandomTests()
    {
        var random = new Random();
        string randomStr;
        for (int i = 0; i < 10; i++)
        {
            randomStr = 
                String.Join("", Enumerable.Range(0, 10).Select(o => (char)random.Next('a', 'z')))
                + "_"
                + String.Join("", Enumerable.Range(0, 10).Select(o => (char)random.Next('a', 'z')))
                + "-"
                + String.Join("", Enumerable.Range(0, 10).Select(o => (char)random.Next('a', 'z')));

            Assert.AreEqual(Solution(randomStr), Kata.ToCamelCase(randomStr));
        }
    }
}