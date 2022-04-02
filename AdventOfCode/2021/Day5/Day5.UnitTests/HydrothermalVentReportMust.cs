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
            var exception = Assert.Throws<ArgumentException>(() => HydrothermalVentReport.CreateReportNotSupportingDiagonals(invalidReport));
            Assert.Equal("Invalid input", exception.Message);
        }

        [Theory]
        [InlineData("0,9 -> 5,9\n1,9 -> 5,9", 5)]
        [InlineData("9,4 -> 3,4\n1,4 -> 9,4", 7)]
        [InlineData("7,0 -> 7,4", 0)]
        [InlineData("0,9 -> 5,9\n7,0 -> 7,4\n7,2 -> 7,9", 3)]
        [InlineData("8,0 -> 0,8", 0)]
        public void GenerateLinesCorrectly(string singleHorizontalLine, int expectedPoints)
        {
            var sut = HydrothermalVentReport.CreateReportNotSupportingDiagonals(singleHorizontalLine);
            Assert.Equal(expectedPoints, sut.CalculateAmountOfOverlappingPoints());
        }

        [Theory]
        [InlineData("0,9 -> 5,9\n0,9 -> 2,9", 3)]
        [InlineData(SAMPLE_INPUT, 5)]
        public void CalculateOverlappingPoitnsCorrectly_WhenNotIncludingDiagonals(string input, int expectedCount)
        {
            var sut = HydrothermalVentReport.CreateReportNotSupportingDiagonals(input);
            Assert.Equal(expectedCount, sut.CalculateAmountOfOverlappingPoints());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = HydrothermalVentReport.CreateReportNotSupportingDiagonals(REAL_INPUT);
            Assert.Equal(7269, sut.CalculateAmountOfOverlappingPoints());
        }

        [Theory]
        [InlineData("1,1 -> 3,3", 0)]
        [InlineData("9,7 -> 7,9\n8,8 -> 6,6", 1)]
        [InlineData("1,1 -> 5,5\n5,5 -> 1,1", 5)]
        [InlineData("1,4 -> 5,4\n5,3 -> 3,5", 1)]
        public void SupportDiagonalLines(string input, int expectedCount)
        {
            var sut = HydrothermalVentReport.CreateReportSupportingDiagonals(input);
            Assert.Equal(expectedCount, sut.CalculateAmountOfOverlappingPoints());
        }

        [Fact]
        public void CalculateOverlappingPointsCorrectly_WhenIncludingDiagonals()
        {
            var sut = HydrothermalVentReport.CreateReportSupportingDiagonals(SAMPLE_INPUT);
            Assert.Equal(12, sut.CalculateAmountOfOverlappingPoints());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = HydrothermalVentReport.CreateReportSupportingDiagonals(REAL_INPUT);
            Assert.Equal(21140, sut.CalculateAmountOfOverlappingPoints());
        }
    }
}