using System;
using Xunit;
using Day3.Logic;

namespace Day3.UnitTests
{
    public class DiagnosticReportMust
    {
        private const string SAMPLE_INPUT = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

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
        [InlineData("0\n1\n1", 1, 0)]
        [InlineData("1\n0\n0", 0, 1)]
        [InlineData("10\n01\n00", 0, 3)]
        [InlineData("100\n100", 4, 3)]
        public void Test1(string reportInput, int expectedGamma, int expectedEpsilon)
        {
            var sut = new DiagnosticReport(reportInput);
            Assert.Equal(expectedGamma, sut.GammaRate);
            Assert.Equal(expectedEpsilon, sut.EpsilonRate);
        }
    }
}