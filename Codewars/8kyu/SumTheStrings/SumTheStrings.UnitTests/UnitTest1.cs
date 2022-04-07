namespace Solution {
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SolutionTest
    {
        [Test(Description = "Tests")]
        public void Tests()
        {
            Assert.AreEqual("9", Program.StringsSum("4","5"));
            Assert.AreEqual("39", Program.StringsSum("34","5"));
            Assert.AreEqual("9", Program.StringsSum("","9"));
            Assert.AreEqual("9", Program.StringsSum("9",""));
            Assert.AreEqual("0", Program.StringsSum("",""));
        }
    }
}