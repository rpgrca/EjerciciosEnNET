using Xunit;
using AdventOfCode2020.Day20.Logic;

namespace AdventOfCode2020.Day20.UnitTests
{
    public class TileMust
    {
        private const string TILE_2311 = @"Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###";

        private const string TILE_1951 = @"Tile 1951:
#.##...##.
#.####...#
.....#..##
#...######
.##.#....#
.###.#####
###.##.##.
.###....#.
..#.#..#.#
#...##.#..";

        private const string TILE_3079 = @"Tile 3079:
#.#.#####.
.#..######
..#.......
######....
####.#..#.
.#...#.##.
#.#####.##
..#.###...
..#.......
..#.###...";

        [Fact]
        public void LoadDataCorrectly()
        {
            var sut = new Tile(TILE_2311);

            Assert.Equal(2311, sut.Id);
            Assert.Equal("..##.#..#.", sut.Top);
            Assert.Equal("...#.##..#", sut.Right);
            Assert.Equal("..###..###", sut.Bottom);
            Assert.Equal(".#####..#.", sut.Left);
        }

        [Fact]
        public void RotateRight90DegreesCorrectly()
        {
            var sut = new Tile(TILE_2311);

            sut.RotateRight(90);
            Assert.Equal(".#..#####.", sut.Top);
            Assert.Equal("..###..###", sut.Left);
            Assert.Equal("..##.#..#.", sut.Right);
            Assert.Equal("#..##.#...", sut.Bottom);
        }

        [Fact]
        public void FlipHorizontallyCorrectly()
        {
            var sut = new Tile(TILE_2311);

            sut.FlipHorizontally();
            Assert.Equal("..###..###", sut.Top);
            Assert.Equal("..##.#..#.", sut.Bottom);
            Assert.Equal(".#..#####.", sut.Left);
            Assert.Equal("#..##.#...", sut.Right);
        }

        [Fact]
        public void FlipVerticallyCorrectly()
         {
            var sut = new Tile(TILE_2311);

            sut.FlipVertically();
            Assert.Equal(".#..#.##..", sut.Top);
            Assert.Equal("###..###..", sut.Bottom);
            Assert.Equal(".#####..#.", sut.Right);
            Assert.Equal("...#.##..#", sut.Left);
         }

        [Theory]
        [InlineData(TILE_2311, TILE_1951)]
        [InlineData(TILE_2311, TILE_3079)]
        [InlineData(TILE_1951, TILE_2311)]
        [InlineData(TILE_3079, TILE_2311)]
        public void ReturnTrue_WhenCheckingIfAdjacentTilesAreAdjacent(string tileData, string adjacentTileData)
        {
            var adjacentTile = new Tile(adjacentTileData);
            var sut = new Tile(tileData);

            Assert.True(sut.CouldBeAdjacentOf(adjacentTile));
        }

        [Fact]
        public void ReturnFalse_WhenCheckingIfNonAdjacentTilesAreAdjacent()
        {
            var nonAdjacentTile = new Tile(TILE_3079);
            var sut = new Tile(TILE_1951);

            Assert.False(sut.IsAdjacentOf(nonAdjacentTile));
        }

        [Fact]
        public void ReturnTrue_WhenFlippedAdjacentTileIsFirstFlipped()
        {
           var flippedAdjacentTile = new Tile(TILE_2311);
           var sut = new Tile(TILE_3079);
           sut.FlipHorizontally();

           Assert.True(sut.IsAdjacentOf(flippedAdjacentTile));
        }

        [Fact]
        public void ReturnTrue_WhenCheckingIfFlippedAdjacentTileCouldBeAdjacent()
        {
            var flippedAdjacentTile = new Tile(TILE_2311);
            var sut = new Tile(TILE_3079);

           Assert.True(sut.CouldBeAdjacentOf(flippedAdjacentTile));
        }

        [Fact]
        public void ReturnFalse_WhenCheckingIfNonAdjacentTileCouldBeAdjacent()
        {
            var nonAdjacentTile = new Tile(TILE_3079);
            var sut = new Tile(TILE_1951);

            Assert.False(sut.CouldBeAdjacentOf(nonAdjacentTile));
        }
    }
}