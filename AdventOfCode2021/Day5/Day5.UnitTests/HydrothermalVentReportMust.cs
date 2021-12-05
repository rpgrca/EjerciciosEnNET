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

        [Fact]
        public void Test1()
        {
            const string SINGLE_LINE = "0,9 -> 5,9";
            var sut = new HydrothermalVentReport(SINGLE_LINE);
            Assert.Equal(6, sut.TotalPoints);
        }
    }
}
