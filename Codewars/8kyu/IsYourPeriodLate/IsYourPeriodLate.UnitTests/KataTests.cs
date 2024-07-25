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
}
