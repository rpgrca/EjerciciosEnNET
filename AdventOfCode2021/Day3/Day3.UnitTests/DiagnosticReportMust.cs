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

        [Fact]
        public void Test1()
        {
            var sut = new DiagnosticReport("1");
            Assert.Equal(1, sut.GammaRate);
            Assert.Equal(0, sut.EpsilonRate);
        }
    }
}