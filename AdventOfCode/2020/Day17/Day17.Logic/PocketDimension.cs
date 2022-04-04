using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day17.Logic
{
    public class PocketThreeDimension
    {
        private readonly string _initialState;
        protected Dictionary<string, Cube> Dimension { get; }
        protected Dictionary<string, Cube> NeighboursToAdd { get;}
        protected int NeighboursPerCube { init; get; }

        protected int[] _currentCoordinates;

        public int ActiveCubes =>
            Dimension.Values.Count(c => c.IsActive);

        public PocketThreeDimension(string initialState)
        {
            _initialState = initialState;
            NeighboursToAdd = new Dictionary<string, Cube>();
            Dimension = new Dictionary<string, Cube>();
            NeighboursPerCube = 26;
            _currentCoordinates = Array.Empty<int>();

            ParseState();
        }

        private void ParseState()
        {
            var y = 0;
            foreach (var states in _initialState.Split("\n"))
            {
                var x = 0;
                foreach (var state in states)
                {
                    var cube = BuildCubeFromCoordenates(x, y, state);
                    x++;

                    Dimension.Add(cube.Coordinates, cube);
                }

                y++;
            }
        }

        protected virtual Cube BuildCubeFromCoordenates(int x, int y, char state) =>
            new($"x={x},y={y},z=0", state == '#');

        public void DoCycle()
        {
            var changes = new List<Action>();

            ExpandDimension();
            foreach (var cube in Dimension.Values)
            {
                if (MustToggle(cube, cube.IsActive, cube.IsActive? x => x < 2 : x => x == 3))
                {
                    changes.Add(() => cube.Toggle());
                }
            }

            changes.ForEach(c => c());
        }

        private void ExpandDimension()
        {
            Dimension.Values.ToList().ForEach(c => CreateSurroundingCubes(c));
            AddCreatedCubesToDimension();
        }

        private static bool MustToggle(Cube cube, bool moreThanThree, Func<int, bool> finalTest)
        {
            var activeItems = 0;
            foreach (var neighbour in cube.Neighbours.Values)
            {
                if (neighbour.IsActive)
                {
                    activeItems++;
                    if (activeItems > 3)
                    {
                        return moreThanThree;
                    }
                }
            }

            return finalTest(activeItems);
        }

        protected virtual void CreateSurroundingCubes(Cube cube)
        {
            if (cube.Neighbours.Count < NeighboursPerCube)
            {
                for (var xOffset = -1; xOffset <= 1; xOffset++)
                {
                    for (var yOffset = -1; yOffset <= 1; yOffset++)
                    {
                        for (var zOffset = -1; zOffset <= 1; zOffset++)
                        {
                            CreateSurroundingCube(cube, new int[] { xOffset, yOffset, zOffset });
                        }
                    }
                }
            }
        }

        private void AddCreatedCubesToDimension()
        {
            NeighboursToAdd.Values
                .ToList()
                .ForEach(c => Dimension.Add(c.Coordinates, c));

            NeighboursToAdd.Clear();
        }

        protected virtual void CreateSurroundingCube(Cube cube, int[] offsets)
        {
            _currentCoordinates = UpdateCoordinates(cube, offsets);

            if (! cube.LocatedAt(_currentCoordinates))
            {
                var coordinates = CalculateCurrentCoordinates();
                Cube neighbour;
                if (!Dimension.ContainsKey(coordinates))
                {
                    if (!NeighboursToAdd.ContainsKey(coordinates))
                    {
                        neighbour = BuildCube(coordinates, false);
                        NeighboursToAdd.Add(neighbour.Coordinates, neighbour);
                    }
                    else
                    {
                        neighbour = NeighboursToAdd[coordinates];
                    }
                }
                else
                {
                    neighbour = Dimension[coordinates];
                }

                UpdateCubeAndNeighbour(cube, neighbour);
            }
        }

        protected virtual int[] UpdateCoordinates(Cube cube, int[] offset) =>
            new int[] {cube.AddOffsetToX(offset[0]), cube.AddOffsetToY(offset[1]), cube.AddOffsetToZ(offset[2])};

        protected virtual string CalculateCurrentCoordinates() =>
            $"x={_currentCoordinates[0]},y={_currentCoordinates[1]},z={_currentCoordinates[2]}";

        protected virtual Cube BuildCube(string coordinates, bool active) =>
            new(coordinates, false);

        private static void UpdateCubeAndNeighbour(Cube cube, Cube neighbour)
        {
            cube.Neighbours[neighbour.Coordinates] = neighbour;
            neighbour.Neighbours[cube.Coordinates] = cube;
        }


    }
}