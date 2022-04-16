namespace Solution {
    using System;
    using NUnit.Framework;
    using YouGotChange.Logic;

    [TestFixture]
    public class Test
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(new int[] {0, 1, 1, 0, 1, 3}, Kata.GiveChange(365));
            Assert.AreEqual(new int[] {2, 1, 1, 0, 0, 2}, Kata.GiveChange(217));
        }
    }
}