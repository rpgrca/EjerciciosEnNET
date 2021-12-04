using System;
using Xunit;
using Day4.Logic;
using static Day4.UnitTests.Constants;
using System.Collections.Generic;

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
            var exception = Assert.Throws<ArgumentException>(() => new Bingo(invalidBoards));
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

            var sut = new Bingo(BOARD);
            Assert.Equal(22, sut.Boards[0][0,0]);
            Assert.Equal(13, sut.Boards[0][0,1]);
            Assert.Equal(17, sut.Boards[0][0,2]);
            Assert.Equal(11, sut.Boards[0][0,3]);
            Assert.Equal(0, sut.Boards[0][0,4]);
            Assert.Equal(8, sut.Boards[0][1,0]);
            Assert.Equal(2, sut.Boards[0][1,1]);
            Assert.Equal(23, sut.Boards[0][1,2]);
            Assert.Equal(4, sut.Boards[0][1,3]);
            Assert.Equal(24, sut.Boards[0][1,4]);
            Assert.Equal(21, sut.Boards[0][2,0]);
            Assert.Equal(9, sut.Boards[0][2,1]);
            Assert.Equal(14, sut.Boards[0][2,2]);
            Assert.Equal(16, sut.Boards[0][2,3]);
            Assert.Equal(7, sut.Boards[0][2,4]);
            Assert.Equal(6, sut.Boards[0][3,0]);
            Assert.Equal(10, sut.Boards[0][3,1]);
            Assert.Equal(3, sut.Boards[0][3,2]);
            Assert.Equal(18, sut.Boards[0][3,3]);
            Assert.Equal(5, sut.Boards[0][3,4]);
            Assert.Equal(1, sut.Boards[0][4,0]);
            Assert.Equal(12, sut.Boards[0][4,1]);
            Assert.Equal(20, sut.Boards[0][4,2]);
            Assert.Equal(15, sut.Boards[0][4,3]);
            Assert.Equal(19, sut.Boards[0][4,4]);
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

            var sut = new Bingo(BOARD);
            Assert.Equal(22, sut.Boards[0][0,0]);
            Assert.Equal(13, sut.Boards[0][0,1]);
            Assert.Equal(17, sut.Boards[0][0,2]);
            Assert.Equal(11, sut.Boards[0][0,3]);
            Assert.Equal(0, sut.Boards[0][0,4]);
            Assert.Equal(8, sut.Boards[0][1,0]);
            Assert.Equal(2, sut.Boards[0][1,1]);
            Assert.Equal(23, sut.Boards[0][1,2]);
            Assert.Equal(4, sut.Boards[0][1,3]);
            Assert.Equal(24, sut.Boards[0][1,4]);
            Assert.Equal(21, sut.Boards[0][2,0]);
            Assert.Equal(9, sut.Boards[0][2,1]);
            Assert.Equal(14, sut.Boards[0][2,2]);
            Assert.Equal(16, sut.Boards[0][2,3]);
            Assert.Equal(7, sut.Boards[0][2,4]);
            Assert.Equal(6, sut.Boards[0][3,0]);
            Assert.Equal(10, sut.Boards[0][3,1]);
            Assert.Equal(3, sut.Boards[0][3,2]);
            Assert.Equal(18, sut.Boards[0][3,3]);
            Assert.Equal(5, sut.Boards[0][3,4]);
            Assert.Equal(1, sut.Boards[0][4,0]);
            Assert.Equal(12, sut.Boards[0][4,1]);
            Assert.Equal(20, sut.Boards[0][4,2]);
            Assert.Equal(15, sut.Boards[0][4,3]);
            Assert.Equal(19, sut.Boards[0][4,4]);

            Assert.Equal(3,sut.Boards[1][0,0]);
            Assert.Equal(15,sut.Boards[1][0,1]);
            Assert.Equal(0,sut.Boards[1][0,2]);
            Assert.Equal(2,sut.Boards[1][0,3]);
            Assert.Equal(22,sut.Boards[1][0,4]);
            Assert.Equal(9,sut.Boards[1][1,0]);
            Assert.Equal(18,sut.Boards[1][1,1]);
            Assert.Equal(13,sut.Boards[1][1,2]);
            Assert.Equal(17,sut.Boards[1][1,3]);
            Assert.Equal(5,sut.Boards[1][1,4]);
            Assert.Equal(19,sut.Boards[1][2,0]);
            Assert.Equal(8,sut.Boards[1][2,1]);
            Assert.Equal(7,sut.Boards[1][2,2]);
            Assert.Equal(25,sut.Boards[1][2,3]);
            Assert.Equal(23,sut.Boards[1][2,4]);
            Assert.Equal(20,sut.Boards[1][3,0]);
            Assert.Equal(11,sut.Boards[1][3,1]);
            Assert.Equal(10,sut.Boards[1][3,2]);
            Assert.Equal(24,sut.Boards[1][3,3]);
            Assert.Equal(4,sut.Boards[1][3,4]);
            Assert.Equal(14,sut.Boards[1][4,0]);
            Assert.Equal(21,sut.Boards[1][4,1]);
            Assert.Equal(16,sut.Boards[1][4,2]);
            Assert.Equal(12,sut.Boards[1][4,3]);
            Assert.Equal(6,sut.Boards[1][4,4]);
        }

        [Fact]
        public void MarkDrawnNumberInBoardCorrectly()
        {
            const string BOARD = @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19";

            var sut = new Bingo(BOARD);
            sut.Play("22");

            Assert.Equal(-1, sut.Boards[0][0,0]);
        }

        [Fact]
        public void NotMarkAnyNumberInBoard_WhenNumberDidNotExist()
        {
            const string BOARD = @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19";

            var sut = new Bingo(BOARD);
            sut.Play("90");
            Assert.Equal(22, sut.Boards[0][0,0]);
            Assert.Equal(13, sut.Boards[0][0,1]);
            Assert.Equal(17, sut.Boards[0][0,2]);
            Assert.Equal(11, sut.Boards[0][0,3]);
            Assert.Equal(0, sut.Boards[0][0,4]);
            Assert.Equal(8, sut.Boards[0][1,0]);
            Assert.Equal(2, sut.Boards[0][1,1]);
            Assert.Equal(23, sut.Boards[0][1,2]);
            Assert.Equal(4, sut.Boards[0][1,3]);
            Assert.Equal(24, sut.Boards[0][1,4]);
            Assert.Equal(21, sut.Boards[0][2,0]);
            Assert.Equal(9, sut.Boards[0][2,1]);
            Assert.Equal(14, sut.Boards[0][2,2]);
            Assert.Equal(16, sut.Boards[0][2,3]);
            Assert.Equal(7, sut.Boards[0][2,4]);
            Assert.Equal(6, sut.Boards[0][3,0]);
            Assert.Equal(10, sut.Boards[0][3,1]);
            Assert.Equal(3, sut.Boards[0][3,2]);
            Assert.Equal(18, sut.Boards[0][3,3]);
            Assert.Equal(5, sut.Boards[0][3,4]);
            Assert.Equal(1, sut.Boards[0][4,0]);
            Assert.Equal(12, sut.Boards[0][4,1]);
            Assert.Equal(20, sut.Boards[0][4,2]);
            Assert.Equal(15, sut.Boards[0][4,3]);
            Assert.Equal(19, sut.Boards[0][4,4]);
        }

        [Fact]
        public void RecognizeWinningBoard_WhenLiningHorizontally()
        {
            const string BOARD = @"14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

            var sut = new Bingo(BOARD);
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

            var sut = new Bingo(BOARD);
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

            var sut = new Bingo(BOARD);
            sut.Play("2,0,12,3,7");

            Assert.Equal((14+21+17+24+4+10+16+15+9+19+18+8+23+26+20+22+11+13+6+5) * 7, sut.FinalScore);
        }

        [Fact]
        public void SolveFirstSample()
        {
            var sut = new Bingo(SAMPLE_BOARDS);
            sut.Play(SAMPLE_DRAWN_NUMBERS);

            Assert.Equal(4512, sut.FinalScore);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Bingo(REAL_BOARDS);
            sut.Play(REAL_DRAWN_NUMBERS);

            Assert.Equal(11774, sut.FinalScore);
        }

        [Fact]
        public void SolveSecondSample()
        {
            var sut = new Bingo(SAMPLE_BOARDS);
            sut.PlayForLosing(SAMPLE_DRAWN_NUMBERS);

            Assert.Equal(1924, sut.FinalScore);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Bingo(REAL_BOARDS);
            sut.PlayForLosing(REAL_DRAWN_NUMBERS);

            Assert.Equal(4495, sut.FinalScore);
        }
    }
}
