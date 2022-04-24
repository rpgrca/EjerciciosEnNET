namespace Solution
{
    using NUnit.Framework;
    using Grader.Logic;

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(1, ExpectedResult='A')]
        [TestCase(1.01, ExpectedResult='F')]
        [TestCase(0.2, ExpectedResult='F')]
        [TestCase(0.7, ExpectedResult='C')]
        [TestCase(0.8, ExpectedResult='B')]
        [TestCase(0.9, ExpectedResult='A')]
        [TestCase(0.6, ExpectedResult='D')]
        [TestCase(0.5, ExpectedResult='F')]
        [TestCase(0, ExpectedResult='F')]
        public static char FixedTest(double score)
        {
            return Kata.Grader(score);
        }

        [Test]
        public static void RandomTest([Random(0,150,100)] double score)
        {
            score /= 100;
            Assert.AreEqual(Solution(score), Kata.Grader(score), string.Format("Should work for {0}", score));
        }

        private static char Solution(double score)
        {
            if(score < 0.6) return 'F';
            if(score < 0.7) return 'D';
            if(score < 0.8) return 'C';
            if(score < 0.9) return 'B';
            if(score <= 1 ) return 'A';
            return 'F';
        }
    }
}