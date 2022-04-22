namespace Solution
{
    using NUnit.Framework;
    using System;
    using PossibilitiesArray.Logic;

    [TestFixture]
    public class SolutionTest
    {
        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.AreEqual(true, Kata.IsAllPossibilities(new int[] {0, 1, 2, 3}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {1, 2, 3, 4}));
        }
    }
}