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
    }
}