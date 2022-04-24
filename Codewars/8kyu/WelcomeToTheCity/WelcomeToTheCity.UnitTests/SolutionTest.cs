namespace Solution {
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("Hello, John Smith! Welcome to Phoenix, Arizona!", Kata.SayHello(new string[] {"John", "Smith"}, "Phoenix", "Arizona"));
        }
    }
}