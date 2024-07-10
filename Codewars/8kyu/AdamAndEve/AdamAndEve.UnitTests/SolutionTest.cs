namespace AdamAndEve.UnitTests;

using AdamAndEve.Logic;
using NUnit.Framework;
using System;

[TestFixture]
public class SolutionTest
{
  [Test]
  public void SampleTest()
  {
    Human[] humans = God.Create();
    Assert.That(humans[0] is Man, "The first object in the array should be a Man");
  }
}