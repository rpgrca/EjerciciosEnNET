using System.Linq;
using System.Collections.Generic;
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

        [Fact]
        public void Test1()
        {
            var adjacentTile = new Tile(TILE_2311);
            var sut = new Tile(TILE_1951);

            Assert.True(sut.IsAdjacentOf(adjacentTile));
        }

        [Fact]
        public void Test2()
        {
            var nonAdjacentTile = new Tile(TILE_3079);
            var sut = new Tile(TILE_1951);

            Assert.False(sut.IsAdjacentOf(nonAdjacentTile));
        }

        [Fact]
        public void Test3()
        {
            var flippedAdjacentTile = new Tile(TILE_2311);
            var sut = new Tile(TILE_3079);

            Assert.False(sut.IsAdjacentOf(flippedAdjacentTile));
        }

        [Fact]
        public void Test4()
        {
           var flippedAdjacentTile = new Tile(TILE_2311);
           var sut = new Tile(TILE_3079);
           sut.FlipHorizontally();

           Assert.True(sut.IsAdjacentOf(flippedAdjacentTile));
        }

        [Fact]
        public void Test5()
        {
            var flippedAdjacentTile = new Tile(TILE_2311);
            var sut = new Tile(TILE_3079);

           Assert.True(sut.CouldBeAdjacentOf(flippedAdjacentTile));
        }
    }

    public class MapMust
    {
        [Fact]
        public void Test1()
        {
            const string data = @"Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###

Tile 1951:
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

            var map = new Map(data, 1, 3);
            Assert.Equal(2, map.Count);
        }
    }

    public class Map
    {
        private readonly string _data;
        private List<Tile> _tiles;

        public int Width { get; }
        public int Height { get; }
        public int Count => _tiles.Count;

        public Map(string data, int width, int height)
        {
            _data = data;
            _tiles = new List<Tile>();
            Width = width;
            Height = height;

            ParseMap();
        }

        private void ParseMap() =>
            _tiles = _data.Split("\n\n").Select(t => new Tile(t)).ToList();
    }
}