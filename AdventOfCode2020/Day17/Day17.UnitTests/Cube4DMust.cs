using Xunit;
using AdventOfCode2020.Day17.Logic;

namespace AdventOfCode2020.Day17.UnitTests
{
    public class Cube4DMust
    {
        [Fact]
        public void ReturnTrue_WhenCubesAreEqual()
        {
            var otherCube = new Cube("x=2,y=2,z=2,w=2", true);
            var sut = new Cube("x=2,y=2,z=2,w=2", true);

            Assert.True(sut.Equals(otherCube));
        }

        [Theory]
        [InlineData("x=1,y=2,z=2,w=2")]
        [InlineData("x=2,y=1,z=2,w=2")]
        [InlineData("x=2,y=2,z=1,w=2")]
        [InlineData("x=2,y=2,z=2,w=1")]
        public void ReturnFalse_WhenCubesAreNotEqual(string otherCubeCoordenates)
        {
            var otherCube = new Cube4D(otherCubeCoordenates, true);
            var sut = new Cube4D("x=2,y=2,z=2", true);

            Assert.False(sut.Equals(otherCube));
        }
    }
}