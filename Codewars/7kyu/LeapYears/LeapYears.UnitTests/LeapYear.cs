using LeapYears.Logic;

namespace LeapYears.UnitTests;

[TestFixture]
public static class LeapYear
{
  [Test]
  public static void TestYear2020()
  {
    Assert.That(Kata.IsLeapYear(2020), Is.EqualTo(true), "Incorrect answer for year=2020");
  }
  
  [Test]
  public static void TestYear2000()
  {
    Assert.That(Kata.IsLeapYear(2000), Is.EqualTo(true), "Incorrect answer for year=2000");
  }
  
  [Test]
  public static void TestYear2015()
  {
    Assert.That(Kata.IsLeapYear(2015), Is.EqualTo(false), "Incorrect answer for year=2015");
  }
  
  
  [Test]
  public static void TestYear2100()
  {
    Assert.That(Kata.IsLeapYear(2100), Is.EqualTo(false), "Incorrect answer for year=2100");
  }
}