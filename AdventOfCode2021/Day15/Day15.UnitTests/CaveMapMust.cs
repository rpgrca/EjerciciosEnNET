using System;
using Xunit;
using Day15.Logic;
using static Day15.UnitTests.Constants;

namespace Day15.UnitTests
{
    public class CaveMapMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidMap(string map)
        {
            var exception = Assert.Throws<ArgumentException>(() => new CaveMap(map));
            Assert.Equal("Invalid map", exception.Message);
        }

        [Theory]
        [InlineData(SAMPLE_MAP, 10)]
        [InlineData(REAL_MAP, 100)]
        public void ParseMapCorrectly(string map, int expectedWidth)
        {
            var sut = new CaveMap(map);
            Assert.Equal(expectedWidth, sut.Width);
        }

        [Fact]
        public void FindLowestRiskPath_WhenUsingAsmallMap()
        {
            const string map = "1163\n1381\n2136\n3694";
            var sut = new CaveMap(map);

            /*Assert.Collection(result,
                p0 => Assert.Equal(1, p0),
                p1 => Assert.Equal(1, p1),
                p2 => Assert.Equal(2, p2),
                p3 => Assert.Equal(1, p3),
                p4 => Assert.Equal(3, p4),
                p5 => Assert.Equal(6, p5),
                p6 => Assert.Equal(4, p6));*/
            sut.GetPath();
            Assert.Equal(17, sut.GetPathLevel());
        }

        [Fact]
        public void FindLowestRiskPath_WhenUsingSampleMap()
        {
            var sut = new CaveMap(SAMPLE_MAP);
            /*Assert.Collection(sut.GetPath(),
                p0 => Assert.Equal(1, p0),
                p1 => Assert.Equal(1, p1),
                p2 => Assert.Equal(2, p2),
                p3 => Assert.Equal(1, p3),
                p4 => Assert.Equal(3, p4),
                p5 => Assert.Equal(6, p5),
                p6 => Assert.Equal(5, p6),
                p7 => Assert.Equal(1, p7),
                p8 => Assert.Equal(1, p8),
                p9 => Assert.Equal(1, p9),
                p10 => Assert.Equal(5, p10),
                p11 => Assert.Equal(1, p11),
                p12 => Assert.Equal(1, p12),
                p13 => Assert.Equal(3, p13),
                p14 => Assert.Equal(2, p14),
                p15 => Assert.Equal(3, p15),
                p16 => Assert.Equal(2, p16),
                p17 => Assert.Equal(1, p17),
                p18 => Assert.Equal(1, p18));*/
            sut.GetPath();
            Assert.Equal(40, sut.GetPathLevel());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new CaveMap(REAL_MAP);
            sut.GetPath();
            Assert.True(sut.GetPathLevel() < 829);
            Assert.Equal(824, sut.GetPathLevel());
        }
    }
}