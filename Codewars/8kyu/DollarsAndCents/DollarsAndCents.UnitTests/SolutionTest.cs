namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using DollarsAndCents.Logic;

    [TestFixture]
    public class SolutionTest
    {
        private static Random rng = new Random();

        [Test, Description("Fixed tests")]
        public void SampleTest()
        {
            Action[] tests = new Action[]
            {
                () => Assert.AreEqual("$39.99", Kata.FormatMoney(39.99), "That's not formatted the way we expected."),
                () => Assert.AreEqual("$3.00", Kata.FormatMoney(3), "That's not formatted the way we expected."),
                () => Assert.AreEqual("$3.10", Kata.FormatMoney(3.10), "That's not formatted the way we expected."),
                () => Assert.AreEqual("$314.16", Kata.FormatMoney(314.16), "That's not formatted the way we expected."),
            };
            tests.OrderBy(x => rng.Next()).ToList().ForEach(a => a.Invoke());
        }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        double test = rng.NextDouble() * 10000;
        string expected = test.ToString("$###0.00");
        string actual = Kata.FormatMoney(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}