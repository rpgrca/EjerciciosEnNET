using Xunit;
using AdventOfCode2020.Day9.Logic;

namespace AdventOfCode2020.Day9.UnitTests
{
    public class XmasCryptMust
    {
        [Theory]
        [InlineData(26)]
        [InlineData(49)]
        public void ReturnTrue_WhenNumberCanBeAdditionOfPrevious25Ones(int expectedValue)
        {
            long[] preamble =
            {
                20,  2,  3,  4,  5,
                 6,  7,  8,  9, 10,
                11, 12, 13, 14, 15,
                16, 17, 18, 19,  1,
                21, 22, 23, 24, 25
            };

            var sut = new XmasCrypt(preamble, 25);
            Assert.True(sut.IsValid(expectedValue));
        }

        [Theory]
        [InlineData(100)]
        [InlineData(50)]
        public void ReturnFalse_WhenNumberCantBeAdditionOfPrevious25Ones(int invalidValue)
        {
            long[] preamble =
            {
                20,  2,  3,  4,  5,
                 6,  7,  8,  9, 10,
                11, 12, 13, 14, 15,
                16, 17, 18, 19,  1,
                21, 22, 23, 24, 25
            };

            var sut = new XmasCrypt(preamble, 25);
            Assert.False(sut.IsValid(invalidValue));
        }

        [Theory]
        [InlineData(26)]
        [InlineData(64)]
        [InlineData(66)]
        public void AddNextValue_WhenNextValueIsValid(int validValue)
        {
            long[] preamble =
            {
                20,  2,  3,  4,  5,
                 6,  7,  8,  9, 10,
                11, 12, 13, 14, 15,
                16, 17, 18, 19,  1,
                21, 22, 23, 24, 25
            };

            var sut = new XmasCrypt(preamble, 25);
            sut.Append(45);

            Assert.True(sut.IsValid(validValue));
        }

        [Fact]
        public void ReturnFalse_WhenNextValueIsInvalid()
        {
            long[] preamble =
            {
                20,  2,  3,  4,  5,
                 6,  7,  8,  9, 10,
                11, 12, 13, 14, 15,
                16, 17, 18, 19,  1,
                21, 22, 23, 24, 25
            };

            var sut = new XmasCrypt(preamble, 25);
            sut.Append(45);

            Assert.False(sut.IsValid(65));
        }

        [Fact]
        public void ProcessSampleDataCorrectly()
        {
            long[] preamble =
            {
                 35,  20,  15,  25,  47,
                 40,  62,  55,  65,  95,
                102, 117, 150, 182, 127,
                219, 299, 277, 309, 576
            };

            var sut = new XmasCrypt(preamble, 5);
            Assert.Equal(127, sut.InvalidValue);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new XmasCrypt(PuzzleData.PUZZLE_DATA, 25);
            Assert.Equal(27911108, sut.InvalidValue);
        }
    }
}