using NUnit.Framework;

namespace NextPalindromicNumber.Solution;

public class NextPalMust
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(22, Kata.NextPal(11));
            Assert.AreEqual(191, Kata.NextPal(188));
            Assert.AreEqual(202, Kata.NextPal(191));
            Assert.AreEqual(2552, Kata.NextPal(2541));
        }
    }
}