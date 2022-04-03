using Xunit;
using AdventOfCode2020.Day17.Logic;

namespace AdventOfCode2020.Day17.UnitTests
{
    public class PocketFourDimensionMust
    {
        [Fact]
        public void Return29Cubes_AfterExecuting1Cycle()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketFourDimension(initialState);
            sut.DoCycle();
            Assert.Equal(29, sut.ActiveCubes);
        }

        [Fact]
        public void Return60Cubes_AfterExecuting2Cycles()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketFourDimension(initialState);
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(60, sut.ActiveCubes);
        }

        [Fact]
        public void Return848Cubes_AfterExecuting6Cycles()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketFourDimension(initialState);
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(848, sut.ActiveCubes);
        }

        [Fact(Skip = "slow test, 11s in total at Github")]
        public void SolveSecondPuzzle()
        {
            const string initialState = @".#######
#######.
###.###.
#....###
.#..##..
#.#.###.
###..###
.#.#.##.";

            var sut = new PocketFourDimension(initialState);
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(2296, sut.ActiveCubes);
        }
    }
}