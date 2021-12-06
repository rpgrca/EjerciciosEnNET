using System;
using Xunit;
using Day6.Logic;
using static Day6.UnitTests.Constants;

namespace Day6.UnitTests
{
    public class AgeModelMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void BeInitializedCorrectly(string invalidAges)
        {
            var exception = Assert.Throws<ArgumentException>(() => new AgeModel(invalidAges));
            Assert.Equal("Invalid age list", exception.Message);
        }

        [Fact]
        public void ReturnOneAge_WhenInitializedWithAsingleValue()
        {
            var sut = new AgeModel("3");
            Assert.Single(sut.Ages, 3);
        }

        [Fact]
        public void ReturnAllAges_WhenInitializedWithMoreThanOneValue()
        {
            var sut = new AgeModel(SAMPLE_AGES);
            Assert.Collection(sut.Ages,
                p1 => Assert.Equal(3, p1),
                p2 => Assert.Equal(4, p2),
                p3 => Assert.Equal(3, p3),
                p4 => Assert.Equal(1, p4),
                p5 => Assert.Equal(2, p5));
        }

        [Fact]
        public void Test1()
        {
            var sut = new AgeModel("3");
            sut.NextDay();
            Assert.Single(sut.Ages, 2);
        }

        [Fact]
        public void SpawnNewLanternfish_WhenTimerPassesZero()
        {
            var sut = new AgeModel("3");
            sut.NextDay();
            sut.NextDay();
            sut.NextDay();
            sut.NextDay();
            Assert.Collection(sut.Ages,
                p1 => Assert.Equal(6, p1),
                p2 => Assert.Equal(8, p2));
        }
    }
}
