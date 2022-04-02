using Xunit;
using AdventOfCode2020.Day17.Logic;

namespace AdventOfCode2020.Day17.UnitTests
{
    public class CubeMust
    {
        [Theory]
        [InlineData("x=2,y=2,z=2")]
        [InlineData("x=0,y=2,z=3")]
        public void ReturnTrue_WhenComparingWithANeighbour(string neighbourAddress)
        {
            var neighbour = new Cube(neighbourAddress, true);

            var sut = new Cube("x=1,y=2,z=3", true);
            Assert.True(sut.IsNeighbourOf(neighbour));
        }

        [Fact]
        public void ReturnFalse_WhenComparingWithANonNeighbour()
        {
            var notNeighbour = new Cube("x=10,y=10,z=10", true);

            var sut = new Cube("x=1,y=2,z=3", true);
            Assert.False(sut.IsNeighbourOf(notNeighbour));
        }

        [Fact]
        public void ReturnTrue_WhenCubeIsActive()
        {
            var sut = new Cube("x=1,y=2,z=3", true);
            Assert.True(sut.IsActive);
        }

        [Fact]
        public void ReturnFalse_WhenCubeIsInactive()
        {
            var sut = new Cube("x=1,y=2,z=3", false);
            Assert.False(sut.IsActive);
        }

        [Fact]
        public void ReturnTrue_WhenCubesAreEqual()
        {
            var otherCube = new Cube("x=2,y=2,z=2", true);
            var sut = new Cube("x=2,y=2,z=2", true);

            Assert.True(sut.Equals(otherCube));
        }

        [Theory]
        [InlineData("x=1,y=2,z=2")]
        [InlineData("x=2,y=1,z=2")]
        [InlineData("x=2,y=2,z=1")]
        public void ReturnFalse_WhenCubesAreNotEqual(string otherCubeCoordenates)
        {
            var otherCube = new Cube(otherCubeCoordenates, true);
            var sut = new Cube("x=2,y=2,z=2", true);

            Assert.False(sut.Equals(otherCube));
        }
    }
}