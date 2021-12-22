using Xunit;
using Day22.Logic;

namespace Day22.UnitTests
{
    public class CubeMust
    {
        [Fact]
        public void BeInitializedCorrectly()
        {
            var sut = new Cube("x=10..12,y=10..12,z=10..12");
            Assert.Equal(8, sut.Vertexes.Count);
            Assert.Equal(3, sut.Depth);
            Assert.Equal(3, sut.Height);
            Assert.Equal(3, sut.Width);
            Assert.Contains((10, 10, 10), sut.Vertexes);
            Assert.Contains((10, 10, 12), sut.Vertexes);
            Assert.Contains((10, 12, 10), sut.Vertexes);
            Assert.Contains((10, 12, 12), sut.Vertexes);
            Assert.Contains((12, 10, 10), sut.Vertexes);
            Assert.Contains((12, 10, 12), sut.Vertexes);
            Assert.Contains((12, 12, 10), sut.Vertexes);
            Assert.Contains((12, 12, 12), sut.Vertexes);
        }

        [Fact]
        public void CalculateAreaCorrectly()
        {
            var sut = new Cube("x=10..12,y=10..12,z=10..12");
            Assert.Equal(27, sut.GetArea());
        }

        [Fact]
        public void ReturnTrue_WhenIntersectingWithAnother()
        {
            var other = new Cube("x=11..13,y=11..13,z=11..13");
            var sut = new Cube("x=10..12,y=10..12,z=10..12");

            Assert.True(sut.Intersects(other));
            Assert.True(other.Intersects(sut));
        }

        [Fact]
        public void ReturnFalse_WhenCubeDoesNotIntersectWithAnother()
        {
            var other = new Cube("x=10..10,y=10..10,z=10..10");
            var sut = new Cube("x=11..13,y=11..13,z=11..13");

            Assert.False(sut.Intersects(other));
            Assert.False(other.Intersects(sut));
        }
    }
}