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

        [Fact]
        public void Test1()
        {
            var expectedResult = new int[] { 1, 2, 2, 3 };
            var sut = new Logic.GravityFlip();
            sut.Flip('R', new int[] { 3, 2, 1, 2 });
            Assert.Equal(expectedResult, sut.State);
        }

        [Fact]
        public void Test2()
        {
            var expectedResult = new int[] { 1 };
            var sut = new Logic.GravityFlip();
            sut.Flip('R', new int[] { 1 });
            Assert.Equal(expectedResult, sut.State);
        }

        [Fact]
        public void Test3()
        {
            var expectedResult = new int[] { 5, 5, 4, 3, 1 };
            var sut = new Logic.GravityFlip();
            sut.Flip('L', new int[] { 1, 4, 5, 3, 5 });
            Assert.Equal(expectedResult, sut.State);
        }
    }
}