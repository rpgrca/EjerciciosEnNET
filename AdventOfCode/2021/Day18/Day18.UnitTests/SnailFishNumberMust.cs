using Xunit;
using Day18.Logic;

namespace Day18.UnitTests
{
    public class SnailFishNumberMust
    {
        [Fact]
        public void ReturnTrue_WhenTwoDifferentInstancesHaveSameValue()
        {
            var value = (5, 6).AsNumber();
            var sut = (5, 6).AsNumber();

            Assert.Equal(value, sut);
        }

        [Fact]
        public void ReturnFalse_WhenTwoDifferentInstancesHaveDifferentValue()
        {
            var value = (5, 5).AsNumber();
            var sut = (6, 6).AsNumber();

            Assert.NotEqual(value, sut);
        }

        [Fact]
        public void ReturnFalse_WhenSecondNumberIsDifferent()
        {
            var value = (5, 5).AsNumber();
            var sut = (5, 6).AsNumber();

            Assert.NotEqual(value, sut);
        }

        [Fact]
        public void ReturnFalse_WhenRegularNumberIsComparedWithSnailFishNumber()
        {
            var value = 6.AsNumber();
            var sut = (5, 6).AsNumber();

            Assert.False(sut.Equals(value));
        }

        [Theory]
        [InlineData("[9,1]", 29)]
        [InlineData("[1,9]", 21)]
        [InlineData("[[9,1],[1,9]]", 129)]
        [InlineData("[[1,2],[[3,4],5]]", 143)]
        [InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
        [InlineData("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
        [InlineData("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
        [InlineData("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
        [InlineData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
        public void CalculateItsMagnitudeCorrectly(string number, int expectedMagnitude)
        {
            var parser = new SnailFishNumberParser(number);
            var sut = parser.Value;
            Assert.Equal(expectedMagnitude, sut.GetMagnitude());
        }
    }
}