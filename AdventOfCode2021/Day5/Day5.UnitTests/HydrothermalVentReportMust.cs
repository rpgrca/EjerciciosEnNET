using System;
using Xunit;
using Day5.Logic;

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
        public void Test1(string singleHorizontalLine, int expectedPoints)
        {
            var sut = new HydrothermalVentReport(singleHorizontalLine);
            Assert.Equal(expectedPoints, sut.TotalPoints);
        }
    }
}
