namespace Solution
{
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
        }
    }
}