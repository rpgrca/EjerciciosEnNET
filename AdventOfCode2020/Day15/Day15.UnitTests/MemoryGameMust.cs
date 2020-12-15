using Xunit;
using AdventOfGame2020.Day15.Logic;

namespace AdventOfCode2020.Day15.UnitTests
{
    public class MemoryGameMust
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(4, 0)]
        [InlineData(5, 3)]
        [InlineData(6, 3)]
        [InlineData(7, 1)]
        [InlineData(8, 0)]
        [InlineData(9, 4)]
        [InlineData(10, 0)]
        public void CalculateTheNthElement_WhenItsNoLongerInTheInitializationArray(int order, int expectedResult)
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(expectedResult, sut.CalculateFor(order));
        }

        [Theory]
        [InlineData(0, 3, 6, 436)]
        [InlineData(1, 3, 2, 1)]
        [InlineData(2, 1, 3, 10)]
        [InlineData(1, 2, 3, 27)]
        [InlineData(2, 3, 1, 78)]
        [InlineData(3, 2, 1, 438)]
        [InlineData(3, 1, 2, 1836)]
        public void FindThe2020thElementFromSamples(int firstNumber, int secondNumber, int thirdNumber, int expectedNumber)
        {
            var sut = new MemoryGame(new int[] { firstNumber, secondNumber, thirdNumber });
            Assert.Equal(expectedNumber, sut.CalculateFor(2020));
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            int[] numbers = { 2, 20, 0, 4, 1, 17 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(758, sut.CalculateFor(2020));
        }

        [Theory]
        [InlineData(0, 3, 6, 175594)]
        [InlineData(1, 3, 2, 2578)]
        [InlineData(2, 1, 3, 3544142)]
        [InlineData(1, 2, 3, 261214)]
        [InlineData(2, 3, 1, 6895259)]
        [InlineData(3, 2, 1, 18)]
        [InlineData(3, 1, 2, 362)]
        public void FindThe30millionthElementFromSamples(int firstNumber, int secondNumber, int thirdNumber, int expectedNumber)
        {
            var sut = new MemoryGame(new int[] { firstNumber, secondNumber, thirdNumber });
            Assert.Equal(expectedNumber, sut.CalculateFor(30000000));
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            int[] numbers = { 2, 20, 0, 4, 1, 17 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(814, sut.CalculateFor(30000000));
        }
    }
}