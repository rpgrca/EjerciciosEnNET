namespace Solution
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Random_Tests
    {
        private static Random rnd = new Random();

        private static double solution(double A) => Math.Round(Math.Pow(A * 4 / (Math.PI * 2), 2), 2);

        [Test, Description("Random Tests")]
        public void RandomTests()
        {
            const int Tests = 100;
            const double Min = 1;
            const double Max = 50;

            for (int i = 0; i < Tests; ++i)
            {
                double A = rnd.NextDouble() * (Max - Min) + Min;

                double expected = solution(A);
                double actual = Kata.SquareArea(A);

                Assert.AreEqual(expected, actual, $"Should determine area of a square for a length of line A of {A}");
            }
        }
    }
}