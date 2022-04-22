namespace Solution
{
    using System;
    using NUnit.Framework;
    using BinaryAddition.Logic;

    [TestFixture]
    public class ConvertTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("10", Converter.ToBinary(2));
            Assert.AreEqual("11", Converter.ToBinary(3));
            Assert.AreEqual("100", Converter.ToBinary(4));
            Assert.AreEqual("101", Converter.ToBinary(5));
            Assert.AreEqual("111", Converter.ToBinary(7), "Failed for 7");
            Assert.AreEqual("1010", Converter.ToBinary(10), "Failed for 10");
            Assert.AreEqual("11111111111111111111111111111101", Converter.ToBinary(-3), "Failed for -3");
            Assert.AreEqual("0", Converter.ToBinary(0), "Failed for 0");
            Assert.AreEqual("1111101000", Converter.ToBinary(1000), "Failed for 1000");
            Assert.AreEqual("11111111111111111111111111110001", Converter.ToBinary(-15), "Failed for -15");
            Assert.AreEqual("11111111111111111111110000011000", Converter.ToBinary(-1000), "Failed for -1000");
            Assert.AreEqual("11111111111100001011110111000001", Converter.ToBinary(-999999), "Failed for -999999");
            Assert.AreEqual("11110100001000111111", Converter.ToBinary(999999), "Failed for 999999");
        }

        [Test]
        public void RandomTests()
        {
            var rand = new Random();
            for(var i = 0; i < 20; i++)
            {
                var n = rand.Next(int.MinValue, int.MaxValue);
                Assert.AreEqual(Convert.ToString(n, 2), Converter.ToBinary(n), "Failed for " + n);
            }
        }
    }
}