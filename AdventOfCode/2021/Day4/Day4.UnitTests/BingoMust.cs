using System;
using Xunit;
using Day4.Logic;
using static Day4.UnitTests.Constants;

namespace Day4.UnitTests
{
    public class BingoMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void BeInitializedCorrectly(string invalidBoards)
        {
            var exception = Assert.Throws<ArgumentException>(() => Bingo.CreateForBestSolution(invalidBoards));
            Assert.Equal("Invalid boards", exception.Message);
        }

        [Fact]
        public void LoadBoardsCorrectly_WhenThereIsOnlyOne()
        {
            const string BOARD = @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19";

            var sut = Bingo.CreateForBestSolution(BOARD);
            Assert.True(sut.DoesBoardContainAtPosition(0, 0, 22));
            Assert.True(sut.DoesBoardContainAtPosition(0, 1, 13));
            Assert.True(sut.DoesBoardContainAtPosition(0, 2, 17));
            Assert.True(sut.DoesBoardContainAtPosition(0, 3, 11));
            Assert.True(sut.DoesBoardContainAtPosition(0, 4, 0));
            Assert.True(sut.DoesBoardContainAtPosition(0, 5, 8));
            Assert.True(sut.DoesBoardContainAtPosition(0, 6, 2));
            Assert.True(sut.DoesBoardContainAtPosition(0, 7, 23));
            Assert.True(sut.DoesBoardContainAtPosition(0, 8, 4));
            Assert.True(sut.DoesBoardContainAtPosition(0, 9, 24));
            Assert.True(sut.DoesBoardContainAtPosition(0, 10, 21));
            Assert.True(sut.DoesBoardContainAtPosition(0, 11, 9));
            Assert.True(sut.DoesBoardContainAtPosition(0, 12, 14));
            Assert.True(sut.DoesBoardContainAtPosition(0, 13, 16));
            Assert.True(sut.DoesBoardContainAtPosition(0, 14, 7));
            Assert.True(sut.DoesBoardContainAtPosition(0, 15, 6));
            Assert.True(sut.DoesBoardContainAtPosition(0, 16, 10));
            Assert.True(sut.DoesBoardContainAtPosition(0, 17, 3));
            Assert.True(sut.DoesBoardContainAtPosition(0, 18, 18));
            Assert.True(sut.DoesBoardContainAtPosition(0, 19, 5));
            Assert.True(sut.DoesBoardContainAtPosition(0, 20, 1));
            Assert.True(sut.DoesBoardContainAtPosition(0, 21, 12));
            Assert.True(sut.DoesBoardContainAtPosition(0, 22, 20));
            Assert.True(sut.DoesBoardContainAtPosition(0, 23, 15));
            Assert.True(sut.DoesBoardContainAtPosition(0, 24, 19));
        }

        [Fact]
        public void LoadBoardsCorrectly_WhenThereAreMoreThanOneBoard()
        {
            const string BOARD = @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19
 
 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6";

            var sut = Bingo.CreateForBestSolution(BOARD);
            Assert.True(sut.DoesBoardContainAtPosition(0, 0, 22));
            Assert.True(sut.DoesBoardContainAtPosition(0, 1, 13));
            Assert.True(sut.DoesBoardContainAtPosition(0, 2, 17));
            Assert.True(sut.DoesBoardContainAtPosition(0, 3, 11));
            Assert.True(sut.DoesBoardContainAtPosition(0, 4, 0));
            Assert.True(sut.DoesBoardContainAtPosition(0, 5, 8));
            Assert.True(sut.DoesBoardContainAtPosition(0, 6, 2));
            Assert.True(sut.DoesBoardContainAtPosition(0, 7, 23));
            Assert.True(sut.DoesBoardContainAtPosition(0, 8, 4));
            Assert.True(sut.DoesBoardContainAtPosition(0, 9, 24));
            Assert.True(sut.DoesBoardContainAtPosition(0, 10, 21));
            Assert.True(sut.DoesBoardContainAtPosition(0, 11, 9));
            Assert.True(sut.DoesBoardContainAtPosition(0, 12, 14));
            Assert.True(sut.DoesBoardContainAtPosition(0, 13, 16));
            Assert.True(sut.DoesBoardContainAtPosition(0, 14, 7));
            Assert.True(sut.DoesBoardContainAtPosition(0, 15, 6));
            Assert.True(sut.DoesBoardContainAtPosition(0, 16, 10));
            Assert.True(sut.DoesBoardContainAtPosition(0, 17, 3));
            Assert.True(sut.DoesBoardContainAtPosition(0, 18, 18));
            Assert.True(sut.DoesBoardContainAtPosition(0, 19, 5));
            Assert.True(sut.DoesBoardContainAtPosition(0, 20, 1));
            Assert.True(sut.DoesBoardContainAtPosition(0, 21, 12));
            Assert.True(sut.DoesBoardContainAtPosition(0, 22, 20));
            Assert.True(sut.DoesBoardContainAtPosition(0, 23, 15));
            Assert.True(sut.DoesBoardContainAtPosition(0, 24, 19));

            Assert.True(sut.DoesBoardContainAtPosition(1, 0, 3));
            Assert.True(sut.DoesBoardContainAtPosition(1, 1, 15));
            Assert.True(sut.DoesBoardContainAtPosition(1, 2, 0));
            Assert.True(sut.DoesBoardContainAtPosition(1, 3, 2));
            Assert.True(sut.DoesBoardContainAtPosition(1, 4, 22));
            Assert.True(sut.DoesBoardContainAtPosition(1, 5, 9));
            Assert.True(sut.DoesBoardContainAtPosition(1, 6, 18));
            Assert.True(sut.DoesBoardContainAtPosition(1, 7, 13));
            Assert.True(sut.DoesBoardContainAtPosition(1, 8, 17));
            Assert.True(sut.DoesBoardContainAtPosition(1, 9, 5));
            Assert.True(sut.DoesBoardContainAtPosition(1, 10, 19));
            Assert.True(sut.DoesBoardContainAtPosition(1, 11, 8));
            Assert.True(sut.DoesBoardContainAtPosition(1, 12, 7));
            Assert.True(sut.DoesBoardContainAtPosition(1, 13, 25));
            Assert.True(sut.DoesBoardContainAtPosition(1, 14, 23));
            Assert.True(sut.DoesBoardContainAtPosition(1, 15, 20));
            Assert.True(sut.DoesBoardContainAtPosition(1, 16, 11));
            Assert.True(sut.DoesBoardContainAtPosition(1, 17, 10));
            Assert.True(sut.DoesBoardContainAtPosition(1, 18, 24));
            Assert.True(sut.DoesBoardContainAtPosition(1, 19, 4));
            Assert.True(sut.DoesBoardContainAtPosition(1, 20, 14));
            Assert.True(sut.DoesBoardContainAtPosition(1, 21, 21));
            Assert.True(sut.DoesBoardContainAtPosition(1, 22, 16));
            Assert.True(sut.DoesBoardContainAtPosition(1, 23, 12));
            Assert.True(sut.DoesBoardContainAtPosition(1, 24, 6));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ThrowException_WhenTryingToPlayWithInvalidDrawnNumbers(string invalidDrawnNumbers)
        {
            var sut = Bingo.CreateForBestSolution(SAMPLE_BOARDS);
            var exception = Assert.Throws<ArgumentException>(() => sut.Play(invalidDrawnNumbers));
            Assert.Equal("Invalid drawn numbers", exception.Message);
        }

        [Fact]
        public void MarkDrawnNumberInBoardCorrectly()
        {
            const string BOARD = @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19";

            var sut = Bingo.CreateForBestSolution(BOARD);
            sut.Play("22");

            Assert.True(sut.DoesBoardContainAtPosition(0, 0, -1));
        }

        [Fact]
        public void NotMarkAnyNumberInBoard_WhenNumberDidNotExist()
        {
            const string BOARD = @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19";

            var sut = Bingo.CreateForBestSolution(BOARD);
            sut.Play("90");
            Assert.True(sut.DoesBoardContainAtPosition(0, 0, 22));
            Assert.True(sut.DoesBoardContainAtPosition(0, 1, 13));
            Assert.True(sut.DoesBoardContainAtPosition(0, 2, 17));
            Assert.True(sut.DoesBoardContainAtPosition(0, 3, 11));
            Assert.True(sut.DoesBoardContainAtPosition(0, 4, 0));
            Assert.True(sut.DoesBoardContainAtPosition(0, 5, 8));
            Assert.True(sut.DoesBoardContainAtPosition(0, 6, 2));
            Assert.True(sut.DoesBoardContainAtPosition(0, 7, 23));
            Assert.True(sut.DoesBoardContainAtPosition(0, 8, 4));
            Assert.True(sut.DoesBoardContainAtPosition(0, 9, 24));
            Assert.True(sut.DoesBoardContainAtPosition(0, 10, 21));
            Assert.True(sut.DoesBoardContainAtPosition(0, 11, 9));
            Assert.True(sut.DoesBoardContainAtPosition(0, 12, 14));
            Assert.True(sut.DoesBoardContainAtPosition(0, 13, 16));
            Assert.True(sut.DoesBoardContainAtPosition(0, 14, 7));
            Assert.True(sut.DoesBoardContainAtPosition(0, 15, 6));
            Assert.True(sut.DoesBoardContainAtPosition(0, 16, 10));
            Assert.True(sut.DoesBoardContainAtPosition(0, 17, 3));
            Assert.True(sut.DoesBoardContainAtPosition(0, 18, 18));
            Assert.True(sut.DoesBoardContainAtPosition(0, 19, 5));
            Assert.True(sut.DoesBoardContainAtPosition(0, 20, 1));
            Assert.True(sut.DoesBoardContainAtPosition(0, 21, 12));
            Assert.True(sut.DoesBoardContainAtPosition(0, 22, 20));
            Assert.True(sut.DoesBoardContainAtPosition(0, 23, 15));
            Assert.True(sut.DoesBoardContainAtPosition(0, 24, 19));
        }

        [Fact]
        public void RecognizeWinningBoard_WhenLiningHorizontally()
        {
            const string BOARD = @"14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

            var sut = Bingo.CreateForBestSolution(BOARD);
            sut.Play("7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1");

            Assert.Equal(4512, sut.FinalScore);
        }

        [Fact]
        public void RecognizeWinningBoard_WhenLiningVertically()
        {
            const string BOARD = @"14 10 18 22  2
21 16  8 11  0
17 15 23 13 12
24  9 26  6  3
 4 19 20  5  7";

            var sut = Bingo.CreateForBestSolution(BOARD);
            sut.Play("7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1");

            Assert.Equal(4512, sut.FinalScore);
        }

        [Fact]
        public void RecognizeWinningBoard_WhenZeroBelongsToSeries()
        {
            const string BOARD = @"14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

            var sut = Bingo.CreateForBestSolution(BOARD);
            sut.Play("2,0,12,3,7");

            Assert.Equal((14+21+17+24+4+10+16+15+9+19+18+8+23+26+20+22+11+13+6+5) * 7, sut.FinalScore);
        }

        [Fact]
        public void SolveFirstSample()
        {
            var sut = Bingo.CreateForBestSolution(SAMPLE_BOARDS);
            sut.Play(SAMPLE_DRAWN_NUMBERS);

            Assert.Equal(4512, sut.FinalScore);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = Bingo.CreateForBestSolution(REAL_BOARDS);
            sut.Play(REAL_DRAWN_NUMBERS);

            Assert.Equal(11774, sut.FinalScore);
        }

        [Fact]
        public void SolveSecondSample()
        {
            var sut = Bingo.CreateForWorstSolution(SAMPLE_BOARDS);
            sut.Play(SAMPLE_DRAWN_NUMBERS);

            Assert.Equal(1924, sut.FinalScore);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = Bingo.CreateForWorstSolution(REAL_BOARDS);
            sut.Play(REAL_DRAWN_NUMBERS);

            Assert.Equal(4495, sut.FinalScore);
        }
    }
}