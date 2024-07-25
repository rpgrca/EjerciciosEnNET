using System;
using IsYourPeriodLate.Logic;
using NUnit.Framework;

namespace IsYourPeriodLate.UnitTests;

[TestFixture]
public class KataTests
{
  [Test]
  public void SampleTest()
  {
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 06, 13), new DateTime(2016, 07, 16), 35));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2016, 06, 13), new DateTime(2016, 07, 16), 28));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 06, 13), new DateTime(2016, 07, 16), 35));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 06, 13), new DateTime(2016, 06, 29), 28));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 07, 12), new DateTime(2016, 08, 09), 28));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2016, 07, 12), new DateTime(2016, 08, 10), 28));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2016, 07, 01), new DateTime(2016, 08, 01), 28));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30), 30));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 01, 01), new DateTime(2016, 01, 31), 30));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2016, 01, 01), new DateTime(2016, 02, 01), 30));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2020, 06, 01), new DateTime(2020, 07, 01), 40));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2020, 06, 01), new DateTime(2020, 06, 30), 30));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2020, 06, 12), new DateTime(2020, 07, 12), 28));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 28));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), 30));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), 40));
  }

    private static readonly Random Rand = new();

  [Test]
  public void RandomTest()
  {
    for (var i = 0; i < 100; i++)
    {
      var last = RandomDate();
      var today = last.AddDays(Rand.Next(20, 41));
      var cycleLength = Rand.Next(20, 41);

      var expected = Solution(last, today, cycleLength);
      var actual = Kata.PeriodIsLate(last, today, cycleLength);
      var message = FailureMessage(last, today, cycleLength, expected);

      Assert.AreEqual(expected, actual, message);
    }
  }

  private static bool Solution(DateTime last, DateTime today, int cycleLength)
  {
    return (today - last).TotalDays > cycleLength;
  }

  private static DateTime RandomDate()
  {
    var start = new DateTime(2023, 1, 1);
    var range = (DateTime.Today - start).Days;
    return start.AddDays(Rand.Next(range));
  }

  private static string FailureMessage(DateTime last, DateTime today, int cycleLength, bool expected)
  {
    return $"Should return {expected} with last={last:yyyy-MM-dd}, today={today:yyyy-MM-dd}, cycleLength={cycleLength}";
  }
}
