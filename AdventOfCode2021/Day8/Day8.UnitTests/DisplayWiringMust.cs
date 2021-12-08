using System;
using Xunit;
using Day8.Logic;
using static Day8.UnitTests.Constants;

namespace Day8.UnitTests
{
    public class DisplayWiringMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInvalidWiringIsUsed(string invalidWiring)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DisplayWiring(invalidWiring));
            Assert.Equal("Invalid wiring", exception.Message);
        }

        [Theory]
        [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf", 1)]
        [InlineData(@"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", 2)]
        public void ParseInformationCorrectly(string wiring, int expectedSets)
        {
            var sut = new DisplayWiring(wiring);
            Assert.Equal(expectedSets, sut.TotalScannings);
        }

        [Fact]
        public void CountDigitsWithUniqueNumberOfSegments()
        {
            var sut = new DisplayWiring(SAMPLE_SCANNINGS);
            Assert.Equal(26, sut.DigitsWithUniqueNumberOfSegments);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new DisplayWiring(REAL_SCANNINGS);
            Assert.Equal(504, sut.DigitsWithUniqueNumberOfSegments);
        }

        [Fact]
        public void OrderWiring()
        {
            var sut = new DisplayWiring("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");
            Assert.Collection(sut.GetDisplayFor(0),
                p1 => Assert.Equal("bcdef", p1),
                p2 => Assert.Equal("abcdf", p2),
                p3 => Assert.Equal("bcdef", p3),
                p4 => Assert.Equal("abcdf", p4));
        }

        [Fact]
        public void Test1()
        {
            var sut = new DisplayWiring("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");
            Assert.Collection(sut.GetWiringForDisplay(0),
                p1 => Assert.Equal('d', p1),
                p2 => Assert.Equal('e', p2),
                p3 => Assert.Equal('a', p3),
                p4 => Assert.Equal('f', p4),
                p5 => Assert.Equal('g', p5),
                p6 => Assert.Equal('b', p6),
                p7 => Assert.Equal('c', p7));
        }

        [Fact]
        public void Test2()
        {
            var sut = new DisplayWiring("be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe");
            Assert.Collection(sut.GetWiringForDisplay(0),
                p1 => Assert.Equal('d', p1),
                p2 => Assert.Equal('g', p2),
                p3 => Assert.Equal('b', p3),
                p4 => Assert.Equal('c', p4),
                p5 => Assert.Equal('a', p5),
                p6 => Assert.Equal('e', p6),
                p7 => Assert.Equal('f', p7));
        }

        [Fact]
        public void Test3()
        {
            var sut = new DisplayWiring("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");
            sut.GetWiringForDisplay(0);
            Assert.Equal(5353, sut.GetFixedDisplayFor(0));
        }

        [Fact]
        public void Test4()
        {
            var sut = new DisplayWiring(SAMPLE_SCANNINGS);
            Assert.Equal(61229, sut.GetSumOfDisplays());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new DisplayWiring(REAL_SCANNINGS);
            Assert.Equal(1073431, sut.GetSumOfDisplays());
        }
    }
}
