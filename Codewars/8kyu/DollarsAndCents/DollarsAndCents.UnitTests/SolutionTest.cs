namespace Solution
{
    using System;
    using NUnit.Framework;
    using DollarsAndCents.Logic;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("$39.99", Kata.FormatMoney(39.99), "That's not formatted the way we expected.");
        }
    }
}