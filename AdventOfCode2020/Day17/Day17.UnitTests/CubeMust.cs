using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Day17.UnitTests
{
    public class CubeMust
    {
        [Theory]
        [InlineData("x=2,y=2,z=2")]
        [InlineData("x=0,y=2,z=3")]
        public void Test1(string neighbourAddress)
        {
            var neighbour = new Cube(neighbourAddress, true);

            var sut = new Cube("x=1,y=2,z=3", true);
            Assert.True(sut.IsNeighbourOf(neighbour));
        }

        [Fact]
        public void Test2()
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
    }

    [DebuggerDisplay("Coord: ({_coordinates}}), Active? {IsActive}")]
    public class Cube : IEquatable<Cube>
    {
        private readonly string _coordinates;

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int W { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsNew { get; private set; }

        public Cube(string coordinates, bool active)
        {
            IsActive = active;
            IsNew = true;
            _coordinates = coordinates;

            ParseCoordinates();
        }

        private void ParseCoordinates()
        {
            var values = _coordinates
                .Split(",")
                .Select(c => c.Split("="));

            foreach (var value in values)
            {
                if (value[0] == "x") X = int.Parse(value[1]);
                if (value[0] == "y") Y = int.Parse(value[1]);
                if (value[0] == "z") Z = int.Parse(value[1]);
                if (value[0] == "w") W = int.Parse(value[1]);
            }
        }

        public bool IsNeighbourOf(Cube neighbour)
        {
            return Math.Abs(X - neighbour.X) <= 1 &&
                   Math.Abs(Y - neighbour.Y) <= 1 &&
                   Math.Abs(Z - neighbour.Z) <= 1 &&
                   Math.Abs(W - neighbour.W) <= 1;
        }

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }

        public void Fix() =>
            IsNew = false;

        public bool LocatedAt(int x, int y, int z, int w)
        {
            return X == x && Y == y && Z == z && W == w;
        }

        public bool Equals(Cube other)
        {
            return other.X == X && other.Y == Y && other.Z == Z && other.W == W;
        }
    }

    public class PocketDimensionMust
    {
        [Fact]
        public void Test1()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketDimension(initialState);
            Assert.Equal(5, sut.ActiveCubes);
        }

        [Fact]
        public void Test2()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketDimension(initialState);
            sut.DoCycle();
            Assert.Equal(11, sut.ActiveCubes);
        }

        [Fact]
        public void Test3()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketDimension(initialState);
            sut.DoCycle();
            sut.DoCycle();
            Assert.Equal(21, sut.ActiveCubes);
        }

        [Fact]
        public void Test4()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketDimension(initialState);
            sut.DoCycle();
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(38, sut.ActiveCubes);
        }

        [Fact]
        public void Test5()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketDimension(initialState);
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

            var sut = new PocketDimension(initialState);
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();

            sut.DoCycle();
            Assert.Equal(395, sut.ActiveCubes);
        }

/*        [Fact]
        public void Test6()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketDimension(initialState);
            sut.DoCycleIn4D();
            Assert.Equal(11, sut.ActiveCubes);
        }*/

        /*[Fact]
        public void Test7()
        {
            const string initialState = @".#.
..#
###";

            var sut = new PocketDimension(initialState);
            sut.DoCycleIn4D();
            sut.DoCycleIn4D();
            sut.DoCycleIn4D();
            sut.DoCycleIn4D();
            sut.DoCycleIn4D();

            sut.DoCycleIn4D();
            Assert.Equal(848, sut.ActiveCubes);
        }*/
    }

    public class PocketDimension
    {
        private readonly string _initialState;
        private List<Cube> _dimension;

        public int MinimumX { get; private set; }
        public int MaximumX { get; private set; }
        public int MinimumY { get; private set; }
        public int MaximumY { get; private set; }
        public int MinimumZ { get; private set; }
        public int MaximumZ { get; private set; }
        public int MinimumW { get; private set; }
        public int MaximumW { get; private set; }

        public int ActiveCubes => _dimension.Count(c => c.IsActive);

        public PocketDimension(string initialState)
        {
            _dimension = new List<Cube>();
            _initialState = initialState;

            ParseState();
        }

        private void ParseState()
        {
            var y = 0;
            var x = 0;

            foreach (var states in _initialState.Split("\n"))
            {
                x = 0;
                foreach (var state in states)
                {
                    var cube = new Cube($"x={x},y={y},z=0,w=0", state == '#');
                    x++;

                    _dimension.Add(cube);
                }

                y++;
            }

            MaximumX = x;
            MaximumY = y;
            MaximumZ = 1;
            MaximumW = 1;
        }

        public void DoCycle()
        {
            var changes = new List<Action>();

            ExpandDimension();

            foreach (var cube in _dimension)
            {
                var activeNeighbours = GetActiveNeighbours(cube);
                if (cube.IsActive)
                {
                    if (activeNeighbours.Count != 2 && activeNeighbours.Count != 3)
                    {
                        changes.Add(() => cube.Disable());
                    }
                }
                else
                {
                    if (activeNeighbours.Count == 3)
                    {
                        changes.Add(() => cube.Enable());
                    }
                }
            }

            changes.ForEach(c => c());
        }

        private void ExpandDimension()
        {
            var neighboursToCreate = new List<Cube>();

            foreach (var cube in _dimension)
            {
                CreateSurroundingCubes(cube, neighboursToCreate);
            }

            _dimension.AddRange(neighboursToCreate);
            _dimension = _dimension.OrderBy(p => p.X).ThenBy(p => p.Y).ThenBy(p => p.Z).ThenBy(p => p.W).ToList();
        }

        private void CreateSurroundingCubes(Cube cube, List<Cube> neighboursToCreate)
        {
            for (var xOffset = -1; xOffset <= 1; xOffset++)
            {
                for (var yOffset = -1; yOffset <= 1; yOffset++)
                {
                    for (var zOffset = -1; zOffset <= 1; zOffset++)
                    {
                        var x = cube.X + xOffset;
                        var y = cube.Y + yOffset;
                        var z = cube.Z + zOffset;
                        var w = 0;

                        var neighbour = _dimension.Find(c => c.LocatedAt(x, y, z, w));
                        if (neighbour is null)
                        {
                            if (neighboursToCreate.Find(c => c.LocatedAt(x, y, z, w)) is null)
                            {
                                neighbour = new Cube($"x={x},y={y},z={z},w={w}", false);
                                neighboursToCreate.Add(neighbour);

                                if (neighbour.X > MaximumX) MaximumX = neighbour.X;
                                else if (neighbour.X < MinimumX) MinimumX = neighbour.X;

                                if (neighbour.Y > MaximumY) MaximumY = neighbour.Y;
                                else if (neighbour.Y < MinimumY) MinimumY = neighbour.Y;

                                if (neighbour.Z > MaximumZ) MaximumZ = neighbour.Z;
                                else if (neighbour.Z < MinimumZ) MinimumZ = neighbour.Z;

                                if (neighbour.W > MaximumW) MaximumW = neighbour.W;
                                else if (neighbour.W < MinimumW) MinimumW = neighbour.W;
                            }
                        }
                    }
                }
            }
        }

        private List<Cube> GetActiveNeighbours(Cube cube)
        {
            return _dimension
                .Where(p => cube.IsNeighbourOf(p) && p.IsActive && !p.Equals(cube))
                .ToList();
        }

        public void DoCycleIn4D()
        {
            var changes = new List<Action>();

            ExpandDimensionIn4D();

            foreach (var cube in _dimension)
            {
                var activeNeighbours = GetActiveNeighbours(cube);
                if (cube.IsActive)
                {
                    if (activeNeighbours.Count != 2 && activeNeighbours.Count != 3)
                    {
                        changes.Add(() => cube.Disable());
                    }
                }
                else
                {
                    if (activeNeighbours.Count == 3)
                    {
                        changes.Add(() => cube.Enable());
                    }
                }
            }

            changes.ForEach(c => c());
        }

        private void ExpandDimensionIn4D()
        {
            var neighboursToCreate = new List<Cube>();

            foreach (var cube in _dimension)
            {
                CreateSurroundingCubesIn4D(cube, neighboursToCreate);
            }

            _dimension.AddRange(neighboursToCreate);
            _dimension = _dimension.OrderBy(p => p.X).ThenBy(p => p.Y).ThenBy(p => p.Z).ThenBy(p => p.W).ToList();
        }

        private void CreateSurroundingCubesIn4D(Cube cube, List<Cube> neighboursToCreate)
        {
            for (var xOffset = -1; xOffset <= 1; xOffset++)
            {
                for (var yOffset = -1; yOffset <= 1; yOffset++)
                {
                    for (var zOffset = -1; zOffset <= 1; zOffset++)
                    {
                        for (var wOffset = -1; wOffset <= 1; wOffset++)
                        {
                            var x = cube.X + xOffset;
                            var y = cube.Y + yOffset;
                            var z = cube.Z + zOffset;
                            var w = cube.W + wOffset;

                            var neighbour = _dimension.Find(c => c.LocatedAt(x, y, z, w));
                            if (neighbour is null)
                            {
                                if (neighboursToCreate.Find(c => c.LocatedAt(x, y, z, w)) is null)
                                {
                                    neighbour = new Cube($"x={x},y={y},z={z},w={w}", false);
                                    neighboursToCreate.Add(neighbour);

                                    if (neighbour.X > MaximumX) MaximumX = neighbour.X;
                                    else if (neighbour.X < MinimumX) MinimumX = neighbour.X;

                                    if (neighbour.Y > MaximumY) MaximumY = neighbour.Y;
                                    else if (neighbour.Y < MinimumY) MinimumY = neighbour.Y;

                                    if (neighbour.Z > MaximumZ) MaximumZ = neighbour.Z;
                                    else if (neighbour.Z < MinimumZ) MinimumZ = neighbour.Z;

                                    if (neighbour.W > MaximumW) MaximumW = neighbour.W;
                                    else if (neighbour.W < MinimumW) MinimumW = neighbour.W;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}