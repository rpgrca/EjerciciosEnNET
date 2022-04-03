#if false
using Xunit;
using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests
{
    public class EdgeMust
    {
        [Fact]
        public void ReturnTrue_WhenComparingTwoEqualEdges()
        {
            var other = new Edge(FRONT_BOTTOM_LEFT, FRONT_BOTTOM_RIGHT);
            var sut = new Edge(FRONT_BOTTOM_LEFT, FRONT_BOTTOM_RIGHT);

            Assert.Equal(other, sut);
            Assert.Equal(sut, other);
            Assert.True(other == sut);
            Assert.True(sut == other);
            Assert.False(other != sut);
            Assert.False(sut != other);

            //var sut = new Edge((10, 12, 10), (12, 12, 10), (10, 12, 12), (12, 12, 12));
        }

        [Fact]
        public void ReturnTrue_WhenComparingTwoEdgesInDifferentDirections()
        {
            var other = new Edge(FRONT_BOTTOM_LEFT, FRONT_BOTTOM_RIGHT);
            var sut = new Edge(FRONT_BOTTOM_RIGHT, FRONT_BOTTOM_LEFT);

            Assert.Equal(other, sut);
            Assert.Equal(sut, other);
            Assert.True(other == sut);
            Assert.True(sut == other);
            Assert.False(sut != other);
            Assert.False(other != sut);
        }
    }
}
#endif