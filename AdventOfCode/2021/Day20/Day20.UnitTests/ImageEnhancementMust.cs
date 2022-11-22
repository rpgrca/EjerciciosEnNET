using System;
using Xunit;
using Day20.Logic;
using static Day20.UnitTests.Constants;

namespace Day20.UnitTests
{
    public class ImageEnhancementMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new ImageEnhancement(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_INPUT, 5, 5)]
        [InlineData(REAL_INPUT, 100, 100)]
        public void BeInitializedCorrectly(string input, int expectedWidth, int expectedHeight)
        {
            var sut = new ImageEnhancement(input);
            Assert.Equal(512, sut.Algorithm.Length);
            Assert.Equal(expectedWidth, sut.ImageWidth);
            Assert.Equal(expectedHeight, sut.ImageHeight);
        }

        [Fact]
        public void EnhanceImageCorrectly_WhenOneEnhancementIsApplied()
        {
            var sut = new ImageEnhancement(SAMPLE_INPUT);
            sut.Enhance(1);

            Assert.Equal(@".##.##.
#..#.#.
##.#..#
####..#
.#..##.
..##..#
...#.#.", sut.GetOutputImage());
        }

        [Fact]
        public void EnhanceImageCorrectly_WhenTwoEnhancementsAreApplied()
        {
            var sut = new ImageEnhancement(SAMPLE_INPUT);
            sut.Enhance(2);

            Assert.Equal(@".......#.
.#..#.#..
#.#...###
#...##.#.
#.....#.#
.#.#####.
..#.#####
...##.##.
....###..", sut.GetOutputImage());
        }

        [Fact]
        public void CountLitPixelsInSampleImage_WhenEnhancingTwice()
        {
            var sut = new ImageEnhancement(SAMPLE_INPUT);
            sut.Enhance(2);

            Assert.Equal(35, sut.CountLitPixels());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new ImageEnhancement(REAL_INPUT);
            sut.Enhance(2);

            Assert.Equal(5483, sut.CountLitPixels());
        }

        [Fact]
        public void CountLitPixelsInSampleImage_WhenEnhancing50Times()
        {
            var sut = new ImageEnhancement(SAMPLE_INPUT);
            sut.Enhance(50);

            Assert.Equal(3351, sut.CountLitPixels());
        }

#if !CI_CONTEXT
        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new ImageEnhancement(REAL_INPUT);
            sut.Enhance(50);

            Assert.Equal(18732, sut.CountLitPixels());
        }
#endif
    }
}