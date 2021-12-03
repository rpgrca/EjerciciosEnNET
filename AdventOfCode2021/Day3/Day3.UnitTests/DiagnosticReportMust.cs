using System;
using Xunit;
using Day3.Logic;

namespace Day3.UnitTests
{
    public class DiagnosticReportMust
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void ThrowException_WhenInvalidDataIsSupplied(string invalidReport)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DiagnosticReport(invalidReport));
            Assert.Equal("Invalid report", exception.Message);
        }
    }

}
