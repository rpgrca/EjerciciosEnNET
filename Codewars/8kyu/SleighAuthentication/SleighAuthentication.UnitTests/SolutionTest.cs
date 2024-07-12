namespace SleighAuthentication.UnitTests;

using NUnit.Framework;
using SleighAuthentication.Logic;
using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("The Sleigh must authenticate with correct credentials")]
    public void CorrectTest()
    {
      Assert.That(Sleigh.Authenticate("Santa Claus", "Ho Ho Ho!"));
    }
    
    private static Random rnd = new Random();
    
    private static object[] incorrectTests = new object[]
    {
      new object[] {"Santa", "Ho Ho Ho!"},
      new object[] {"Santa Claus", "Ho Ho Ho"},
      new object[] {"Santa Claus", "Ho Ho!"},
      new object[] {"Easter Bunny", "Ho Ho Ho!"},
      new object[] {"jhoffner", "CodeWars"},
    }.OrderBy(_ => rnd.Next()).ToArray();
    
    [Test, Description("The Sleigh must not authenticate with incorrect credentials")]
    public void IncorrectTest()
    {
      for (int i = 0; i < incorrectTests.Length; ++i)
      {
        Assert.That(!Sleigh.Authenticate(((incorrectTests[i] as object[])[0] as string), ((incorrectTests[i] as object[])[1] as string)));
      }
    }
  }