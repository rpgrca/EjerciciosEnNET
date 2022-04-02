using Xunit;
using AdventOfCode2020.Day24.Logic;

namespace AdventOfCode2020.Day24.UnitTests
{
    public class TileMust
    {
        [Fact]
        public void CalculatePositionCorrectly()
        {
            const string data = "esenee";

            var tile = new Tile(data);
            Assert.Equal((3, 0), tile.Position);
        }
    }
}