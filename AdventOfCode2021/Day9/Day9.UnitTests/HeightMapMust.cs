using System;
using Xunit;
using Day9.Logic;
using static Day9.UnitTests.Constant;

namespace Day9.UnitTests
{
    public class HeightMapMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => new HeightMap(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData("3335\n3335\n3335", 4, 3)]
        [InlineData(SAMPLE_HEIGHTMAP, 10, 5)]
        public void LoadMapCorrectly(string map, int expectedWidth, int expectedHeight)
        {
            var sut = new HeightMap(map);
            Assert.Equal(expectedWidth, sut.Width);
            Assert.Equal(expectedHeight, sut.Height);
        }

        [Theory]
        [InlineData("333\n323\n333", 3)]
        [InlineData("21999\n39878\n98567\n87678", 8)]
        [InlineData(SAMPLE_HEIGHTMAP, 15)]
        public void CalculateRiskLevelCorrectly(string map, int expectedRiskLevel)
        {
            var sut = new HeightMap(map);
            Assert.Equal(expectedRiskLevel, sut.RiskLevel);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new HeightMap(REAL_HEIGHTMAP);
            Assert.Equal(480, sut.RiskLevel);
        }

        [Fact]
        public void CalculateBasinSizeCorrectly_WhenThereIsOnlyOne()
        {
            var sut = new HeightMap("99999\n93339\n93239\n93339\n99999");
            Assert.Equal(9, sut.GetBasinSizeFor(0));
        }

        [Fact]
        public void CalculateBasinSizesCorrectly_WhenUsingSampleMap()
        {
            var sut = new HeightMap(SAMPLE_HEIGHTMAP);
            Assert.Equal(3, sut.GetBasinSizeFor(0));
            Assert.Equal(14, sut.GetBasinSizeFor(1));
            Assert.Equal(9, sut.GetBasinSizeFor(2));
            Assert.Equal(9, sut.GetBasinSizeFor(3));
        }

        [Fact]
        public void CalculateBasinMultiplicationCorrectly_WhenUsingSampleMap()
        {
            var sut = new HeightMap(SAMPLE_HEIGHTMAP);
            Assert.Equal(1134, sut.GetBasinMultiplication());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new HeightMap(REAL_HEIGHTMAP);
            Assert.Equal(1045660, sut.GetBasinMultiplication());
        }
    }
}