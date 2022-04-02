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
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(0));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(1));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(2));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(3));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(4));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(5));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(6));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(7));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(8));
        }

        [Fact]
        public void ReturnAllAges_WhenInitializedWithMoreThanOneValue()
        {
            var sut = new AgeModel(SAMPLE_AGES);
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(0));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(1));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(2));
            Assert.Equal(2, sut.CountFishesWithAnAgeOf(3));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(4));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(5));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(6));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(7));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(8));
        }

        [Fact]
        public void DecrementInternalTimerCorrectly_WhenThereIsOneFish()
        {
            var sut = new AgeModel("3");
            sut.Advance(1);
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(0));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(1));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(2));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(3));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(4));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(5));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(6));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(7));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(8));
        }

        [Fact]
        public void SpawnNewLanternfish_WhenFourDaysPassAfterInitialAgeOf3()
        {
            var sut = new AgeModel("3");
            sut.Advance(4);
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(0));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(1));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(2));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(3));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(4));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(5));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(6));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(7));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(8));
        }

        [Fact]
        public void DecrementInternalTimerCorrectly_WhenThereAreSeveralFishes()
        {
            var sut = new AgeModel(SAMPLE_AGES);
            sut.Advance(1);
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(0));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(1));
            Assert.Equal(2, sut.CountFishesWithAnAgeOf(2));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(3));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(4));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(5));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(6));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(7));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(8));
        }

        [Fact]
        public void SpawnFishCorrectly_WhenThereAreSeveralFishes()
        {
            var sut = new AgeModel(SAMPLE_AGES);
            sut.Advance(2);
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(0));
            Assert.Equal(2, sut.CountFishesWithAnAgeOf(1));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(2));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(3));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(4));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(5));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(6));
            Assert.Equal(0, sut.CountFishesWithAnAgeOf(7));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(8));
        }

        [Fact]
        public void SpawnFishCorrectly_When18DaysPass()
        {
            var sut = new AgeModel(SAMPLE_AGES);
            sut.Advance(18);
            Assert.Equal(3, sut.CountFishesWithAnAgeOf(0));
            Assert.Equal(5, sut.CountFishesWithAnAgeOf(1));
            Assert.Equal(3, sut.CountFishesWithAnAgeOf(2));
            Assert.Equal(2, sut.CountFishesWithAnAgeOf(3));
            Assert.Equal(2, sut.CountFishesWithAnAgeOf(4));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(5));
            Assert.Equal(5, sut.CountFishesWithAnAgeOf(6));
            Assert.Equal(1, sut.CountFishesWithAnAgeOf(7));
            Assert.Equal(4, sut.CountFishesWithAnAgeOf(8));
        }

        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        [InlineData(256, 26984457539)]
        public void CalculateSpawnRateCorrectly_WhenSampleDataIsUsed(int days, long expectedFishes)
        {
            var sut = new AgeModel(SAMPLE_AGES);
            sut.Advance(days);
            Assert.Equal(expectedFishes, sut.CountAllFishes());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new AgeModel(REAL_AGES);
            sut.Advance(80);
            Assert.Equal(379114, sut.CountAllFishes());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new AgeModel(REAL_AGES);
            sut.Advance(256);
            Assert.Equal(1702631502303, sut.CountAllFishes());
        }
    }
}