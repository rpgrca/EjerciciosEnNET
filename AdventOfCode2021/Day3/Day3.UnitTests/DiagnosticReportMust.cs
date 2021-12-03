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

        [Theory]
        [InlineData("1", 1, 0)]
        [InlineData("0", 0, 1)]
        public void Test1(string reportInput, int expectedGamma, int expectedEpsilon)
        {
            var sut = new DiagnosticReport(reportInput);
            Assert.Equal(expectedGamma, sut.GammaRate);
            Assert.Equal(expectedEpsilon, sut.EpsilonRate);
        }
    }
}