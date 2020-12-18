using Xunit;
using AdventOfCode2020.Day17.Logic;

namespace AdventOfCode2020.Day17.UnitTests
{
    public class PocketDimensionMust
    {
        [Fact]
        public void InitializeDimensionCorrectly()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketThreeDimension(initialState);
            Assert.Equal(5, sut.ActiveCubes);
        }

        [Fact]
        public void Return11Cubes_AfterExecuting1Cycle()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketThreeDimension(initialState);

            sut.DoCycle();
            Assert.Equal(11, sut.ActiveCubes);
        }

        [Fact]
        public void Return21Cubes_AfterExecuting2Cycles()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketThreeDimension(initialState);
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(21, sut.ActiveCubes);
        }

        [Fact]
        public void Return38Cubes_AfterExecuting3Cycles()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketThreeDimension(initialState);
            sut.DoCycle();
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(38, sut.ActiveCubes);
        }

        [Fact]
        public void Return112Cubes_AfterExecuting6Cycles()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketThreeDimension(initialState);
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(112, sut.ActiveCubes);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            const string initialState = @".#######
#######.
###.###.
#....###
.#..##..
#.#.###.
###..###
.#.#.##.";

            var sut = new PocketThreeDimension(initialState);
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(395, sut.ActiveCubes);
        }
    }
}