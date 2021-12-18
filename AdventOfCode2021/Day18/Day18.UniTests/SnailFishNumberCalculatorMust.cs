using System;
using Day18.Logic;
using Xunit;

namespace Day18.UniTests
{
    public class SnailFishNumberCalculatorMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidHomework(string invalidHomework)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SnailFishNumberCalculator(invalidHomework));
            Assert.Equal("Invalid homework", exception.Message);
        }

        [Theory]
        [InlineData("[1,2]")]
        public void BeInitializedCorrectly(string homework)
        {
            var sut = new SnailFishNumberCalculator(homework);
            Assert.Collection(sut.Expressions,
                p1 => Assert.Equal((1, 2), p1));
        }
    }
}
