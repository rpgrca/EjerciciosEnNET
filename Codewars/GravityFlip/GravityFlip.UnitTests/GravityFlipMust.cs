using System;
using Xunit;

namespace GravityFlip.UnitTests
{
    public class GravityFlipMust
    {
        [Fact]
        public void ReturnEmptyConfiguration_WhenFlipConfigurationIsNotRequired()
        {
            var sut = new Logic.GravityFlip();
            Assert.Equal(Array.Empty<int>(), sut.State);
        }

        [Theory]
        [InlineData('L', new int[] { 1 })]
        [InlineData('L', new int[] { 2, 2 })]
        [InlineData('L', new int[] { 3, 3, 3 })]
        [InlineData('R', new int[] { 1 })]
        [InlineData('R', new int[] { 2, 2 })]
        [InlineData('R', new int[] { 3, 3, 3 })]
        public void ReturnSameConfiguration_WhenThereAreSameAmountOfBoxesOnBothSides(char direction, int[] values)
        {
            var sut = new Logic.GravityFlip();
            sut.Flip(direction, values);
            Assert.Equal(values, sut.State);
        }

        [Fact]
        public void ReturnValuesOrderedDescending_WhenBoxesAreFlippedRight()
        {
            var expectedResult = new int[] { 1, 2, 2, 3 };
            var sut = new Logic.GravityFlip();
            sut.Flip('R', new int[] { 3, 2, 1, 2 });
            Assert.Equal(expectedResult, sut.State);
        }

        [Fact]
        public void ReturnValuesOrderedAscending_WhenBoxesAreFlippedLeft()
        {
            var expectedResult = new int[] { 5, 5, 4, 3, 1 };
            var sut = new Logic.GravityFlip();
            sut.Flip('L', new int[] { 1, 4, 5, 3, 5 });
            Assert.Equal(expectedResult, sut.State);
        }
    }
}