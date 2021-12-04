using System;
using Xunit;
using Day4.Logic;

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
            Assert.Collection(sut.Boards[0],
                p1 => Assert.Collection(p1,
                    p11 => Assert.Equal(22, p11),
                    p12 => Assert.Equal(13, p12),
                    p13 => Assert.Equal(17, p13),
                    p14 => Assert.Equal(11, p14),
                    p15 => Assert.Equal(0, p15)),
                 p2 => Assert.Collection(p2,
                    p11 => Assert.Equal(8, p11),
                    p12 => Assert.Equal(2, p12),
                    p13 => Assert.Equal(23, p13),
                    p14 => Assert.Equal(4, p14),
                    p15 => Assert.Equal(24, p15)),
                 p3 => Assert.Collection(p3,
                    p11 => Assert.Equal(21, p11),
                    p12 => Assert.Equal(9, p12),
                    p13 => Assert.Equal(14, p13),
                    p14 => Assert.Equal(16, p14),
                    p15 => Assert.Equal(7, p15)),
                 p4 => Assert.Collection(p4,
                    p11 => Assert.Equal(6, p11),
                    p12 => Assert.Equal(10, p12),
                    p13 => Assert.Equal(3, p13),
                    p14 => Assert.Equal(18, p14),
                    p15 => Assert.Equal(5, p15)),
                 p5 => Assert.Collection(p5,
                    p11 => Assert.Equal(1, p11),
                    p12 => Assert.Equal(12, p12),
                    p13 => Assert.Equal(20, p13),
                    p14 => Assert.Equal(15, p14),
                    p15 => Assert.Equal(19, p15)));
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
            Assert.Collection(sut.Boards[0],
                p1 => Assert.Collection(p1,
                    p11 => Assert.Equal(22, p11),
                    p12 => Assert.Equal(13, p12),
                    p13 => Assert.Equal(17, p13),
                    p14 => Assert.Equal(11, p14),
                    p15 => Assert.Equal(0, p15)),
                p2 => Assert.Collection(p2,
                    p11 => Assert.Equal(8, p11),
                    p12 => Assert.Equal(2, p12),
                    p13 => Assert.Equal(23, p13),
                    p14 => Assert.Equal(4, p14),
                    p15 => Assert.Equal(24, p15)),
                p3 => Assert.Collection(p3,
                    p11 => Assert.Equal(21, p11),
                    p12 => Assert.Equal(9, p12),
                    p13 => Assert.Equal(14, p13),
                    p14 => Assert.Equal(16, p14),
                    p15 => Assert.Equal(7, p15)),
                p4 => Assert.Collection(p4,
                    p11 => Assert.Equal(6, p11),
                    p12 => Assert.Equal(10, p12),
                    p13 => Assert.Equal(3, p13),
                    p14 => Assert.Equal(18, p14),
                    p15 => Assert.Equal(5, p15)),
                p5 => Assert.Collection(p5,
                    p11 => Assert.Equal(1, p11),
                    p12 => Assert.Equal(12, p12),
                    p13 => Assert.Equal(20, p13),
                    p14 => Assert.Equal(15, p14),
                    p15 => Assert.Equal(19, p15)));

            Assert.Collection(sut.Boards[1],
                p6 => Assert.Collection(p6,
                    p11 => Assert.Equal(3, p11),
                    p12 => Assert.Equal(15, p12),
                    p13 => Assert.Equal(0, p13),
                    p14 => Assert.Equal(2, p14),
                    p15 => Assert.Equal(22, p15)),
                p7 => Assert.Collection(p7,
                    p11 => Assert.Equal(9, p11),
                    p12 => Assert.Equal(18, p12),
                    p13 => Assert.Equal(13, p13),
                    p14 => Assert.Equal(17, p14),
                    p15 => Assert.Equal(5, p15)),
                p8 => Assert.Collection(p8,
                    p11 => Assert.Equal(19, p11),
                    p12 => Assert.Equal(8, p12),
                    p13 => Assert.Equal(7, p13),
                    p14 => Assert.Equal(25, p14),
                    p15 => Assert.Equal(23, p15)),
                p9 => Assert.Collection(p9,
                    p11 => Assert.Equal(20, p11),
                    p12 => Assert.Equal(11, p12),
                    p13 => Assert.Equal(10, p13),
                    p14 => Assert.Equal(24, p14),
                    p15 => Assert.Equal(4, p15)),
                p10 => Assert.Collection(p10,
                    p11 => Assert.Equal(14, p11),
                    p12 => Assert.Equal(21, p12),
                    p13 => Assert.Equal(16, p13),
                    p14 => Assert.Equal(12, p14),
                    p15 => Assert.Equal(6, p15)));
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

            Assert.Equal(-22, sut.Boards[0][0][0]);
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

            Assert.Collection(sut.Boards[0],
                p1 => Assert.Collection(p1,
                    p11 => Assert.Equal(22, p11),
                    p12 => Assert.Equal(13, p12),
                    p13 => Assert.Equal(17, p13),
                    p14 => Assert.Equal(11, p14),
                    p15 => Assert.Equal(0, p15)),
                 p2 => Assert.Collection(p2,
                    p11 => Assert.Equal(8, p11),
                    p12 => Assert.Equal(2, p12),
                    p13 => Assert.Equal(23, p13),
                    p14 => Assert.Equal(4, p14),
                    p15 => Assert.Equal(24, p15)),
                 p3 => Assert.Collection(p3,
                    p11 => Assert.Equal(21, p11),
                    p12 => Assert.Equal(9, p12),
                    p13 => Assert.Equal(14, p13),
                    p14 => Assert.Equal(16, p14),
                    p15 => Assert.Equal(7, p15)),
                 p4 => Assert.Collection(p4,
                    p11 => Assert.Equal(6, p11),
                    p12 => Assert.Equal(10, p12),
                    p13 => Assert.Equal(3, p13),
                    p14 => Assert.Equal(18, p14),
                    p15 => Assert.Equal(5, p15)),
                 p5 => Assert.Collection(p5,
                    p11 => Assert.Equal(1, p11),
                    p12 => Assert.Equal(12, p12),
                    p13 => Assert.Equal(20, p13),
                    p14 => Assert.Equal(15, p14),
                    p15 => Assert.Equal(19, p15)));
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
    }
}
