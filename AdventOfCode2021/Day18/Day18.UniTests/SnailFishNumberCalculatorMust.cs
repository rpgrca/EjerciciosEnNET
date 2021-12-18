using System;
using System.Collections.Generic;
using Xunit;
using Day18.Logic;

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
        [MemberData(nameof(SimpleExpressionFeeder))]
        public void BeInitializedCorrectly(string homework, SnailFishNumber expectedExpression)
        {
            var sut = new SnailFishNumberCalculator(homework);
            Assert.Collection(sut.Expressions,
                p1 => Assert.Equal(expectedExpression, p1));
        }

        public static IEnumerable<object[]> SimpleExpressionFeeder()
        {
            yield return new object[] { "[1,2]", new SnailFishNumber(new RegularNumber(1), new RegularNumber(2)) };
            yield return new object[] { "[[1,2],3]", new SnailFishNumber(new SnailFishNumber(new RegularNumber(1), new RegularNumber(2)), new RegularNumber(3)) };
        }
    }
}
