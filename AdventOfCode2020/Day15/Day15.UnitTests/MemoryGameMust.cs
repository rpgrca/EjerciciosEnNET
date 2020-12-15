using System;
using Xunit;
using AdventOfGame2020.Day15.Logic;

namespace AdventOfCode2020.Day15.UnitTests
{
    public class MemoryGameMust
    {
        [Fact]
        public void Test1()
        {
            int[] numbers = { 0, 3, 6 };

            var sut = new MemoryGame(numbers);

            Assert.Equal(0, sut.Next());
        }

        [Fact]
        public void Test2()
        {
            int[] numbers = { 0, 3, 6 };

            var sut = new MemoryGame(numbers);
            sut.Next();

            Assert.Equal(3, sut.Next());
        }

        [Fact]
        public void Test3()
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);
            sut.Next();
            sut.Next();

            Assert.Equal(6, sut.Next());
        }

        [Fact]
        public void Test4()
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(0, sut.Next(4));
        }

        [Fact]
        public void Test5()
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(3, sut.Next(5));
        }

        [Fact]
        public void Test6()
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(3, sut.Next(6));
        }

        [Fact]
        public void Test7()
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(1, sut.Next(7));
        }

        [Fact]
        public void Test8()
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(0, sut.Next(8));
        }

        [Fact]
        public void Test9()
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(4, sut.Next(9));
        }

        [Fact]
        public void Test10()
        {
            int[] numbers = { 0, 3, 6 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(0, sut.Next(10));
        }

        [Theory]
        [InlineData(0, 3, 6, 436)]
        [InlineData(1, 3, 2, 1)]
        [InlineData(2, 1, 3, 10)]
        [InlineData(1, 2, 3, 27)]
        [InlineData(2, 3, 1, 78)]
        [InlineData(3, 2, 1, 438)]
        [InlineData(3, 1, 2, 1836)]
        public void Test11(int firstNumber, int secondNumber, int thirdNumber, int expectedNumber)
        {
            var sut = new MemoryGame(new int[] { firstNumber, secondNumber, thirdNumber });
            Assert.Equal(expectedNumber, sut.Next(2020));
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            int[] numbers = { 2, 20, 0, 4, 1, 17 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(758, sut.Next(2020));
        }

        [Theory]
        [InlineData(0, 3, 6, 175594)]
        [InlineData(1, 3, 2, 2578)]
        [InlineData(2, 1, 3, 3544142)]
        [InlineData(1, 2, 3, 261214)]
        [InlineData(2, 3, 1, 6895259)]
        [InlineData(3, 2, 1, 18)]
        [InlineData(3, 1, 2, 362)]
        public void Test12(int firstNumber, int secondNumber, int thirdNumber, int expectedNumber)
        {
            var sut = new MemoryGame(new int[] { firstNumber, secondNumber, thirdNumber });
            Assert.Equal(expectedNumber, sut.Next(30000000));
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            int[] numbers = { 2, 20, 0, 4, 1, 17 };
            var sut = new MemoryGame(numbers);

            Assert.Equal(814, sut.Next(30000000));
        }
    }
}