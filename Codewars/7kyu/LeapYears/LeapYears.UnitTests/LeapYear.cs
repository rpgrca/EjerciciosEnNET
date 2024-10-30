using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using LeapYears.Logic;

namespace LeapYears.Tests;

static class KataTest {
  public static void DoTest(int year, bool expected) =>
    Assert.That(Kata.IsLeapYear(year), Is.EqualTo(expected), $"Incorrect answer for year={year}");
}

[TestFixture]
public static class FixedTests
{
  [Description("Years divisible by 400")]
  [TestCase(1600, Description = "Year 1600")]
  [TestCase(2000, Description = "Year 2000")]
  [TestCase(4000, Description = "Year 4000")]
  public static void TestYearMul400(int year) =>
    KataTest.DoTest(year, true);
  
  [Description("Years divisible by 100, but not by 400")]
  [TestCase(1800, Description = "Year 1800")]
  [TestCase(1900, Description = "Year 1900")]
  [TestCase(2100, Description = "Year 2100")]
  [TestCase(2200, Description = "Year 2200")]
  public static void TestYearMul100(int year) =>
    KataTest.DoTest(year, false);
  
  [Description("Years divisible by 4")]
  [TestCase(2020, Description = "Year 2020")]
  [TestCase(1824, Description = "Year 1824")]
  [TestCase(2152, Description = "Year 2152")]
  public static void TestYearMul4(int year) =>
    KataTest.DoTest(year, true);
  
  [Description("Non-leap years")]
  [TestCase(1821, Description = "Year 1821")]
  [TestCase(1942, Description = "Year 1942")]
  [TestCase(2113, Description = "Year 2113")]
  [TestCase(2254, Description = "Year 2254")]
  public static void TestYearNonLeap(int year) =>
    KataTest.DoTest(year, false);  
}

[TestFixture]
public static class RandomTests
{
  [Test]
  public static void TestRandom() {
    
    var rnd = new Random();
    int RandInt(int lo, int hi_incl) =>
      rnd.Next(lo, hi_incl + 1);
    
    IEnumerable<T> Shuffle<T>(IEnumerable<T> col) =>
      col.Select(e => (Elem: e, Key: rnd.Next())).OrderBy(t => t.Key).Select(t => t.Elem);
    
    var yearMul400  = new[] { 1600, 2000, 2400, 2800, 3200, 3600 };
    var yearMul100  = yearMul400.SelectMany( y => new[] { y + 100, y + 200, y + 300 });
    var yearMul4    = yearMul400.Concat(yearMul100).Select(y => y + RandInt(1, 24) * 4);
    var yearNonMul4 = yearMul4.Select(y => y + RandInt(1, 3)); 
    
    var testCases =
      yearMul400.Concat(yearMul4).Select(y => (y, true))
      .Concat(
        yearMul100.Concat(yearNonMul4).Select(y => (y, false)))
      .ToList();

    foreach(var (year, expected) in Shuffle(testCases)) {
      KataTest.DoTest(year, expected);
    }        
  }
}