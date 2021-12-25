using System;
using Xunit;
using Day25.Logic;
using static Day25.UnitTests.Constants;

namespace Day25.UnitTests
{
    public class SeaCucumberHerdMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidSeafloor(string invalidSeafloor)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SeaCucumberHerd(invalidSeafloor));
            Assert.Equal("Invalid seafloor", exception.Message);
        }

        [Fact]
        public void BeInitializedCorrectly_WhenLoadingSampleMap()
        {
            var sut = new SeaCucumberHerd(SAMPLE_SEAFLOOR);
            Assert.Equal(9, sut.Height);
            Assert.Equal(10, sut.Width);
        }

        [Fact]
        public void BeInitializedCorrectly_WhenLoadingRealMap()
        {
            var sut = new SeaCucumberHerd(REAL_SEAFLOOR);
            Assert.Equal(137, sut.Height);
            Assert.Equal(139, sut.Width);
        }

        [Fact]
        public void MoveCucumbersOnePositionEast()
        {
            var sut = new SeaCucumberHerd("...>>>>>...");
            sut.MoveEast();

            Assert.Equal("...>>>>.>..", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersTwoPositionsEast()
        {
            var sut = new SeaCucumberHerd("...>>>>>...");
            sut.MoveEast();
            sut.MoveEast();

            Assert.Equal("...>>>.>.>.", sut.ToString());
        }

        [Fact]
        public void MoveCucumbersOnePositionSout()
        {
            var sut = new SeaCucumberHerd(@".
.
.
v
v
v
v
v
.
.
.");
            sut.MoveSouth();
            Assert.Equal(@".
.
.
v
v
v
v
.
v
.
.", sut.ToString());
        }
    }
}
