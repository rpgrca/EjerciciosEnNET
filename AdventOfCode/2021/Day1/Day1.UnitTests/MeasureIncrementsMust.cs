using Xunit;
using Day1.Logic;
using static Day1.UnitTests.Constants;

namespace Day1.UnitTests
{
    public class MeasureIncrementsMust
    {
        [Fact]
        public void ObtainSevenIncrements_WhenSuppliedSampleData()
        {
            var sut = new MeasureIncrements(SAMPLE_DEPTHS, 1);
            Assert.Equal(7, sut.Total);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new MeasureIncrements(REAL_DEPTHS, 1);
            Assert.Equal(1665, sut.Total);
        }

        [Fact]
        public void ObtainZeroSlidingWindowIncrements_WhenSuppliedSampleIsNotEnough()
        {
            const string DEPTHS = @"199
200
208";

            var sut = new MeasureIncrements(DEPTHS, 3);
            Assert.Equal(0, sut.Total);
        }

        [Fact]
        public void ObtainFiveSlidingWindowIncrements_WhenSampleDataIsSupplied()
        {
            var sut = new MeasureIncrements(SAMPLE_DEPTHS, 3);
            Assert.Equal(5, sut.Total);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new MeasureIncrements(REAL_DEPTHS, 3);
            Assert.Equal(1702, sut.Total);
        }
    }
}