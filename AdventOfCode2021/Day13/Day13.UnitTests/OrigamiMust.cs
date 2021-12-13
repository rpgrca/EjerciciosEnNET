using System;
using Xunit;
using Day13.Logic;
using static Day13.UnitTests.Constants;

namespace Day13.UnitTests
{
    public class OrigamiMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidInstructions(string invalidInstructions)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Origami(invalidInstructions));
            Assert.Equal("Invalid instructions", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_INSTRUCTIONS, 18, 2)]
        [InlineData(REAL_INSTRUCTIONS, 907, 12)]
        public void ParseInstructionsCorrectly(string instructions, int expectedPoints, int expectedFolds)
        {
            var sut = new Origami(instructions);
            Assert.Equal(expectedPoints, sut.GetPoints());
            Assert.Equal(expectedFolds, sut.GetFolds());
        }

        [Fact]
        public void FoldPaperCorrectly_WhenUsingSampleInstructions()
        {
            var sut = new Origami(SAMPLE_INSTRUCTIONS);
            sut.FoldAlongY(7);
            Assert.Equal(17, sut.GetPoints());
        }
    }
}
