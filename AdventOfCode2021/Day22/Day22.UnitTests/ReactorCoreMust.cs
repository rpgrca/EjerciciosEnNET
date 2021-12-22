using System;
using Day22.Logic;
using Xunit;

namespace Day22.UnitTests
{
    public class ReactorCoreMustst
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidSteps(string invalidSteps)
        {
            var exception = Assert.Throws<ArgumentException>(() => new ReactorCore(invalidSteps));
            Assert.Equal("Invalid steps", exception.Message);
        }

        [Theory]
        [InlineData("on x=10..12,y=10..12,z=10..12", 27)]
        [InlineData(@"on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13", 46)]
        public void BeInitializedCorrectly(string steps, int expectedCount)
        {
            var sut = new ReactorCore(steps);
            Assert.Equal(expectedCount, sut.GetTurnedOnCubesCount());
        }
    }
}
