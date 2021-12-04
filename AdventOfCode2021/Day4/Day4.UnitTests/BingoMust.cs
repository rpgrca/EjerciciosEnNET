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
        public void Test1()
        {
            const string BOARD = @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19";

            var sut = new Bingo(BOARD);
            Assert.Collection(sut.Boards,
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
    }
}
