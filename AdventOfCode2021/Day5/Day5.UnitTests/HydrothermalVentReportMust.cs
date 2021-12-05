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
        public void Test1(string invalidReport)
        {
            var exception = Assert.Throws<ArgumentException>(() => new HydrothermalVentReport(invalidReport));
            Assert.Equal("Invalid input", exception.Message);
        }
    }
}
