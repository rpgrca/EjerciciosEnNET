using System.Linq;
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
        public void DecrementInternalTimerCorrectly_WhenThereIsOneFish()
        {
            var sut = new AgeModel("3");
            sut.Advance(1);
            Assert.Single(sut.Ages, 2);
        }

        [Fact]
        public void SpawnNewLanternfish_WhenFourDaysPassAfterInitialAgeOf3()
        {
            var sut = new AgeModel("3");
            sut.Advance(4);
            Assert.Collection(sut.Ages,
                p1 => Assert.Equal(6, p1),
                p2 => Assert.Equal(8, p2));
        }

        [Fact]
        public void Test1()
        {
            var sut = new AgeModel("3");
            sut.Advance(5);
            Assert.Collection(sut.Ages,
                p1 => Assert.Equal(5, p1),
                p2 => Assert.Equal(7, p2));
        }

        [Fact]
        public void DecrementInternalTimerCorrectly_WhenThereAreSeveralFishes()
        {
            var sut = new AgeModel(SAMPLE_AGES);
            sut.Advance(1);
            Assert.Collection(sut.Ages,
                p1 => Assert.Equal(2, p1),
                p2 => Assert.Equal(3, p2),
                p3 => Assert.Equal(2, p3),
                p4 => Assert.Equal(0, p4),
                p5 => Assert.Equal(1, p5));
        }

        [Fact]
        public void Test2()
        {
            var sut = new AgeModel(SAMPLE_AGES);
            sut.Advance(2);
            Assert.Collection(sut.Ages,
                p1 => Assert.Equal(1, p1),
                p2 => Assert.Equal(2, p2),
                p3 => Assert.Equal(1, p3),
                p4 => Assert.Equal(6, p4),
                p5 => Assert.Equal(0, p5),
                p6 => Assert.Equal(8, p6));
        }

        [Fact]
        public void Test3()
        {
            var sut = new AgeModel(SAMPLE_AGES);
            sut.Advance(18);
            Assert.Collection(sut.Ages,
                p1 => Assert.Equal(6, p1),
                p2 => Assert.Equal(0, p2),
                p3 => Assert.Equal(6, p3),
                p4 => Assert.Equal(4, p4),
                p5 => Assert.Equal(5, p5),
                p6 => Assert.Equal(6, p6),
                p7 => Assert.Equal(0, p7),
                p8 => Assert.Equal(1, p8),
                p9 => Assert.Equal(1, p9),
                p10 => Assert.Equal(2, p10),
                p11 => Assert.Equal(6, p11),
                p12 => Assert.Equal(0, p12),
                p13 => Assert.Equal(1, p13),
                p14 => Assert.Equal(1, p14),
                p15 => Assert.Equal(1, p15),
                p16 => Assert.Equal(2, p16),
                p17 => Assert.Equal(2, p17),
                p18 => Assert.Equal(3, p18),
                p19 => Assert.Equal(3, p19),
                p20 => Assert.Equal(4, p20),
                p21 => Assert.Equal(6, p21),
                p22 => Assert.Equal(7, p22),
                p23 => Assert.Equal(8, p23),
                p24 => Assert.Equal(8, p24),
                p25 => Assert.Equal(8, p25),
                p26 => Assert.Equal(8, p26));
        }

        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        public void Test4(int days, int expectedFishes)
        {
            var sut = new AgeModel(SAMPLE_AGES);
            sut.Advance(days);
            Assert.Equal(expectedFishes, sut.Ages.Count);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new AgeModel(REAL_AGES);
            sut.Advance(80);
            Assert.Equal(379114, sut.Ages.Count);
        }
    }
}
