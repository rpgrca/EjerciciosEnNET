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
            Assert.Equal(expectedPoints, sut.GetPointCount());
            Assert.Equal(expectedFolds, sut.GetFoldCount());
        }

        [Fact]
        public void FoldPaperAlongYaxisCorrectly_WhenUsingSampleInstructions()
        {
            var sut = new Origami(SAMPLE_INSTRUCTIONS);
            sut.FoldAlongY(7);
            Assert.Equal(17, sut.GetPointCount());
        }

        [Fact]
        public void FoldPaperAlongXaxisCorrectly_WhenUsingSampleInstructions()
        {
            var sut = new Origami(SAMPLE_INSTRUCTIONS);
            sut.FoldAlongY(7);
            sut.FoldAlongX(5);
            Assert.Equal(16, sut.GetPointCount());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Origami(REAL_INSTRUCTIONS);
            sut.FoldAlongX(655);
            Assert.Equal(751, sut.GetPointCount());
        }

        [Fact]
        public void PlotPointsCorrectly()
        {
            var sut = new Origami(SAMPLE_INSTRUCTIONS);
            sut.FoldAccordingToInstructions();
            Assert.Equal(@"#####
#...#
#...#
#...#
#####
.....
.....", sut.PlotPoints());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Origami(REAL_INSTRUCTIONS);
            sut.FoldAccordingToInstructions();
            Assert.Equal(@"###...##..#..#.###..#..#.#....#..#.#....
#..#.#..#.#..#.#..#.#.#..#....#.#..#....
#..#.#....####.#..#.##...#....##...#....
###..#.##.#..#.###..#.#..#....#.#..#....
#....#..#.#..#.#.#..#.#..#....#.#..#....
#.....###.#..#.#..#.#..#.####.#..#.####.", sut.PlotPoints());
        }
    }
}
