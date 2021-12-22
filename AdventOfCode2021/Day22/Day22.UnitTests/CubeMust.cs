using Xunit;
using Day22.Logic;
using static Day22.UnitTests.Constants;

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
            Assert.Contains(BACK_BOTTOM_LEFT, sut.Vertexes);
            Assert.Contains((10, 10, 12), sut.Vertexes);
            Assert.Contains(FRONT_BOTTOM_LEFT, sut.Vertexes);
            Assert.Contains((10, 12, 12), sut.Vertexes);
            Assert.Contains((12, 10, 10), sut.Vertexes);
            Assert.Contains((12, 10, 12), sut.Vertexes);
            Assert.Contains(FRONT_BOTTOM_RIGHT, sut.Vertexes);
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

            Assert.True(sut.IntersectsWith(other));
            Assert.True(other.IntersectsWith(sut));
        }

        [Fact]
        public void ReturnFalse_WhenCubeDoesNotIntersectWithAnother()
        {
            var other = new Cube("x=10..10,y=10..10,z=10..10");
            var sut = new Cube("x=11..13,y=11..13,z=11..13");

            Assert.False(sut.IntersectsWith(other));
            Assert.False(other.IntersectsWith(sut));
        }

        [Fact]
        public void ReturnNoCubes_WhenSubstractingTheSameCube()
        {
            var other = new Cube("x=10..12,y=10..12,z=10..12");
            var sut = new Cube("x=10..12,y=10..12,z=10..12");

            var cubes = sut.Subtract(other);
            Assert.Empty(cubes);
        }

        [Fact]
        public void ReturnNoCubes_WhenSubstractingCubeThatContainsTheOther()
        {
            var other = new Cube("x=8..15,y=8..15,z=8..15");
            var sut = new Cube("x=10..12,y=10..12,z=10..12");

            var cubes = sut.Subtract(other);
            Assert.Empty(cubes);
        }

        [Fact]
        public void ReturnSameCube_WhenSubstractingAcubeThatDoesNotIntersect()
        {
            var other = new Cube("x=10..10,y=10..10,z=10..10");
            var sut = new Cube("x=11..13,y=11..13,z=11..13");

            var cubes = sut.Subtract(other);
            Assert.Single(cubes, sut);
        }

        [Fact]
        public void ReturnTrue_WhenCubeFullyContainsAnother()
        {
            var other = new Cube("x=10..12,y=10..12,z=10..12");
            var sut = new Cube("x=8..15,y=8..15,z=8..15");

            Assert.True(sut.FullyContains(other));
        }

        [Fact]
        public void ReturnFalse_WhenCubeDoesNotFullyContainsAnother()
        {
            var other = new Cube("x=8..15,y=8..15,z=8..15");
            var sut = new Cube("x=10..12,y=10..12,z=10..12");

            Assert.False(sut.FullyContains(other));
        }

        [Fact]
        public void ReturnFalse_WhenCheckingIfNonIntersectingCubesFullyContainEachOther()
        {
            var other = new Cube("x=10..10,y=10..10,z=10..10");
            var sut = new Cube("x=11..13,y=11..13,z=11..13");

            Assert.False(sut.FullyContains(other));
            Assert.False(other.FullyContains(sut));
        }

        [Fact]
        public void ReturnNoCube_WhenSubstractingAcubeFromContainingCube()
        {
            var sut = new Cube("x=10..12,y=10..12,z=10..12");
            var other = new Cube("x=8..15,y=8..15,z=8..15");

            Assert.Empty(sut.Subtract(other));
        }

        [Fact]
        public void ReturnSameEdge_WhenCubeDoesNotClipEdge()
        {
            var sut = new Cube("x=8..15,y=8..11,z=8..15");
            var edge = new Edge(FRONT_BOTTOM_LEFT, FRONT_BOTTOM_RIGHT);

            var edges = sut.Clip(edge);
            Assert.Collection(edges, p1 => Assert.Equal(p1, new Edge(FRONT_BOTTOM_LEFT, FRONT_BOTTOM_RIGHT)));
        }

/*
        [Fact]
        public void ReturnSmallerEdge_WhenCubeClipsEdge()
        {
            var sut = new Cube("x=8..15,y=8..11,z=8..15");
            var edge = new Edge(FRONT_BOTTOM_LEFT, BACK_BOTTOM_LEFT);

            var edges = sut.Clip(edge);
            Assert.Collection(edges, p1 => Assert.Equal(p1, new Edge(FRONT_BOTTOM_LEFT, (10, 11, 10))));
        }

        [Fact]
        public void ReturnCubes_WhenSubstractingCubeThatLeavesOneFace()
        {
            var other = new Cube("x=8..15,y=8..11,z=8..15");
            var sut = new Cube("x=10..12,y=10..12,z=10..12");

            var cubes = sut.Subtract(other);
            Assert.Collection(cubes,
                p1 => {
                    Assert.Equal(1, p1.Depth);
                    Assert.Equal(3, p1.Width);
                    Assert.Equal(3, p1.Height);
                });
        }*/
    }
}