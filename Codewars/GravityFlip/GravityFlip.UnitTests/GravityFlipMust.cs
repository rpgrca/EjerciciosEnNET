using System;
using Xunit;
using GravityFlip.Logic;

namespace GravityFlip.UnitTests
{
    public class GravityFlipMust
    {
        [Fact]
        public void ReturnEmptyConfiguration_WhenFlipConfigurationIsNotRequired()
        {
            var sut = new Logic.GravityFlip.Builder()
                .For(Array.Empty<int>())
                .Build();

            Assert.Equal(Array.Empty<int>(), sut.Configuration);
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
            var sut = new Logic.GravityFlip.Builder()
                .For(values)
                .To(direction)
                .Build();

            sut.Flip();
            Assert.Equal(values, sut.Configuration);
        }

        [Fact]
        public void ReturnValuesOrderedDescending_WhenBoxesAreFlippedRight()
        {
            var expectedResult = new int[] { 1, 2, 2, 3 };
            var sut = new Logic.GravityFlip.Builder()
                .For(new int[] { 3, 2, 1, 2 })
                .To('R')
                .Build();

            sut.Flip();
            Assert.Equal(expectedResult, sut.Configuration);
        }

        [Fact]
        public void ReturnValuesOrderedAscending_WhenBoxesAreFlippedLeft()
        {
            var expectedResult = new int[] { 5, 5, 4, 3, 1 };
            var sut = new Logic.GravityFlip.Builder()
                .For(new int[] { 1, 4, 5, 3, 5 })
                .To('L')
                .Build();

            sut.Flip();
            Assert.Equal(expectedResult, sut.Configuration);
        }
    }
}