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
            yield return new object[] { "[1,2]", (1, 2).AsNumber() };
            yield return new object[] { "[[1,2],3]", ((1, 2).AsNumber(), 3).AsNumber() };
            yield return new object[] { "[9,[8,7]]", (9, (8, 7).AsNumber()).AsNumber() };
            yield return new object[] { "[[1,9],[8,5]]", ((1, 9).AsNumber(), (8, 5).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[1,2],[3,4]],[[5,6],[7,8]]],9]", ((((1, 2).AsNumber(), (3, 4).AsNumber()).AsNumber(), ((5, 6).AsNumber(), (7, 8).AsNumber()).AsNumber()).AsNumber(), 9).AsNumber() };
            yield return new object[] { "[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]", (((9,(3,8).AsNumber()).AsNumber(),((0,9).AsNumber(),6).AsNumber()).AsNumber(),(((3,7).AsNumber(),(4,9).AsNumber()).AsNumber(),3).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]", ((((1,3).AsNumber(),(5,3).AsNumber()).AsNumber(),((1,3).AsNumber(),(8,7).AsNumber()).AsNumber()).AsNumber(),(((4,9).AsNumber(),(6,9).AsNumber()).AsNumber(),((8,2).AsNumber(),(7,3).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
        }
    }
}
