using Xunit;
using Day2.Logic;

namespace Day2.UnitTests
{
    public class SubmarineMust
    {
        [Theory]
        [InlineData("forward 5", 5)]
        [InlineData(@"forward 5
down 5
forward 8", 13)]
        [InlineData(@"forward 5
down 5
forward 8
forward 2", 15)]
        public void CalculateHorizontalPositionCorrectly(string course, int expectedPosition)
        {
            var sut = new Submarine(course);

            Assert.Equal(expectedPosition, sut.HorizontalPosition);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(@"forward 5
down 5", 5)]
        public void CalculateDepthCorrectly(string course, int expectedDepth)
        {
            var sut = new Submarine(course);
            Assert.Equal(expectedDepth, sut.Depth);
        }
    }
}