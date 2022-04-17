using NUnit.Framework;
using InsertDashes.Logic;
using System;
using System.Text.RegularExpressions;

namespace Solution
{
    [TestFixture]
    public class SolutionTest
    {
        private static Random rnd = new Random();

        private static string solution(int num) =>
            new Regex("([13579])(?=[13579])", RegexOptions.IgnoreCase).Replace(num.ToString(), "$1-");

        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("4547-9-3", Kata.InsertDash(454793));
            Assert.AreEqual("123456", Kata.InsertDash(123456));
            Assert.AreEqual("1003-567", Kata.InsertDash(1003567));
        }

        [Test]
        public void RandomTest()
        {
            const int Tests = 100;

            for (int i = 0; i < Tests; ++i)
            {
                int num = rnd.Next();

                string expected = solution(num);
                string actual = Kata.InsertDash(num);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}