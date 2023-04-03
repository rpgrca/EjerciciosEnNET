namespace CountCharactersInString.UnitTests;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using CountCharactersInString.Logic;

[TestFixture]
public class Tests
{
  [Test]
  public static void FixedTest_aaaa()
  {
    Dictionary<char, int> d = new Dictionary<char, int>();
    d.Add('a', 4);
    Assert.AreEqual(d, Kata.Count("aaaa"));
  }
  
  [Test]
  public static void FixedTest_aabb()
  {
    Dictionary<char, int> d = new Dictionary<char, int>();
    d.Add('a', 2);
    d.Add('b', 2);
    Assert.AreEqual(d, Kata.Count("aabb"));
  }
}