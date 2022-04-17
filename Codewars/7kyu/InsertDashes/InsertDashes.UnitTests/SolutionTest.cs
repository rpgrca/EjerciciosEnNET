using NUnit.Framework;
using InsertDashes.Logic;
using System;

namespace Solution
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("4547-9-3", Kata.InsertDash(454793));
            Assert.AreEqual("123456", Kata.InsertDash(123456));
            Assert.AreEqual("1003-567", Kata.InsertDash(1003567));
        }
    }
}