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

        [Fact]
        public void CalculateDepthCorrectly()
        {
            var sut = new Submarine(string.Empty);
            Assert.Equal(0, sut.Depth);
        }
    }
}