using Xunit;

namespace GravityFlip.UnitTests
{
    public class GravityFlipMust
    {
        [Fact]
        public void ThrowException_WhenDirectionIsInvalid() =>
            Assert.Throws<ArgumentOutOfRangeException>("direction", () => Logic.GravityFlip.For(new int[] { 1 }).To('Z'));

        [Theory]
        [InlineData('L', new int[] { 1 })]
        [InlineData('L', new int[] { 2, 2 })]
        [InlineData('L', new int[] { 3, 3, 3 })]
        [InlineData('R', new int[] { 1 })]
        [InlineData('R', new int[] { 2, 2 })]
        [InlineData('R', new int[] { 3, 3, 3 })]
        public void ReturnSameConfiguration_WhenThereAreSameAmountOfBoxesOnBothSides(char direction, int[] values)
        {
            var sut = Logic.GravityFlip
                .For(values)
                .To(direction)
                .Build();

            Assert.Equal(values, sut.NewConfiguration);
        }

        [Fact]
        public void ReturnValuesOrderedDescending_WhenBoxesAreFlippedRight()
        {
            var expectedResult = new int[] { 1, 2, 2, 3 };
            var sut = Logic.GravityFlip
                .For(new int[] { 3, 2, 1, 2 })
                .To('R')
                .Build();

            Assert.Equal(expectedResult, sut.NewConfiguration);
        }

        [Fact]
        public void ReturnValuesOrderedAscending_WhenBoxesAreFlippedLeft()
        {
            var expectedResult = new int[] { 5, 5, 4, 3, 1 };
            var sut = Logic.GravityFlip
                .For(new int[] { 1, 4, 5, 3, 5 })
                .To('L')
                .Build();

            Assert.Equal(expectedResult, sut.NewConfiguration);
        }
    }
}