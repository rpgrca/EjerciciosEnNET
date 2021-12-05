using System;
using Xunit;
using Day5.Logic;
using static Day5.UnitTests.Constants;

namespace Day5.UnitTests
{
    public class HydrothermalVentReportMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void BeInitializedCorrectly(string invalidReport)
        {
            var exception = Assert.Throws<ArgumentException>(() => new HydrothermalVentReport(invalidReport));
            Assert.Equal("Invalid input", exception.Message);
        }

        [Theory]
        [InlineData("0,9 -> 5,9", 6)]
        [InlineData("9,4 -> 3,4", 7)]
        [InlineData("7,0 -> 7,4", 5)]
        [InlineData("0,9 -> 5,9\n7,0 -> 7,4", 11)]
        [InlineData("8,0 -> 0,8", 0)]
        [InlineData(SAMPLE_INPUT, 26)]
        public void GenerateLinesCorrectly(string singleHorizontalLine, int expectedPoints)
        {
            var sut = new HydrothermalVentReport(singleHorizontalLine);
            Assert.Equal(expectedPoints, sut.TotalPoints);
        }

        [Theory]
        [InlineData("0,9 -> 5,9\n0,9 -> 2,9", 3)]
        [InlineData(SAMPLE_INPUT, 5)]
        public void Test1(string input, int expectedCount)
        {
            var sut = new HydrothermalVentReport(input);
            Assert.Equal(expectedCount, sut.CalculateOverlappingPoints());
        }

        [Fact]
        public void Test2()
        {
            var sut = new HydrothermalVentReport(REAL_INPUT);
            Assert.Equal(7269, sut.CalculateOverlappingPoints());
        }

        [Theory]
        [InlineData("1,1 -> 3,3", 3)]
        [InlineData("9,7 -> 7,9", 3)]
        [InlineData("1,1 -> 5,5", 5)]
        public void Test3(string input, int expectedCount)
        {
            var sut = new HydrothermalVentReport(input, true);
            Assert.Equal(expectedCount, sut.TotalPoints);
        }

        [Fact]
        public void Test4()
        {
            var sut = new HydrothermalVentReport(SAMPLE_INPUT, true);
            Assert.Equal(12, sut.CalculateOverlappingPoints());
        }
    }
}
