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
/*
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

    public class EdgeMust
    {
        [Fact]
        public void Test1()
        {
            //var sut = new Edge((10, 12, 10), (12, 12, 10), (10, 12, 12), (12, 12, 12));
        }
    }
}