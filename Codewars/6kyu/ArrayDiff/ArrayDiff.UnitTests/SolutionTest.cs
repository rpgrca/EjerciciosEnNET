namespace Solution
{
    using NUnit.Framework;
    using System;
    using ArrayDiff.Logic;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new int[] {2},       Kata.ArrayDiff(new int[] {1, 2},    new int[] {1}));
            Assert.AreEqual(new int[] {2, 2},    Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {1}));
            Assert.AreEqual(new int[] {1},       Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {2}));
            Assert.AreEqual(new int[] {1, 2, 2}, Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {}));
            Assert.AreEqual(new int[] {},        Kata.ArrayDiff(new int[] {},        new int[] {1, 2}));
            Assert.AreEqual(new int[] {3},       Kata.ArrayDiff(new int[] {1, 2, 3}, new int[] {1, 2}));
        }
    }
}