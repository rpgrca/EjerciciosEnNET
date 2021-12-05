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
    }
}
