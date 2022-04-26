namespace Kata {
    using NUnit.Framework;
    using System;
    using CircleAreaInsideSquare.Logic;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test9()
        {
            var result = CircleAreaInsideSquare.Logic.Convert.SquareAreaToCircle(9);
            Assert.AreEqual(result.GetType(), typeof(double),"should a be double");
            Assert.AreEqual(Math.Round(result,8), Math.Round(7.0685834705770345d,8));
        }

        [Test]
        public void Test20()
        {
            var result = CircleAreaInsideSquare.Logic.Convert.SquareAreaToCircle(20);
            Assert.AreEqual(Math.Round(result,8), Math.Round(15.707963267948969d,8));
        }
    }
}