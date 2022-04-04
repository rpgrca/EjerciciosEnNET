using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day17.Logic
{
    [DebuggerDisplay("Coord: ({Coordinates}}), Active? {IsActive}")]
    public class Cube : IEquatable<Cube>
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int W { get; protected set; }
        public bool IsActive { get; private set; }
        public Dictionary<string, Cube> Neighbours { get; }
        public string Coordinates { get; }

        public int AddOffsetToX(int offset) => X + offset;
        public int AddOffsetToY(int offset) => Y + offset;
        public int AddOffsetToZ(int offset) => Z + offset;
        public int AddOffsetToW(int offset) => W + offset;

        public Cube(string coordinates, bool active)
        {
            IsActive = active;
            Neighbours = new Dictionary<string, Cube>();
            Coordinates = coordinates;

            ParseCoordinates();
        }

        private void ParseCoordinates()
        {
            var values = Coordinates
                .Split(",")
                .Select(c => c.Split("="));

            foreach (var value in values)
            {
                AssignValue(value);
            }
        }

        protected virtual void AssignValue(string[] value)
        {
            if (value[0] == "x") X = int.Parse(value[1]);
            if (value[0] == "y") Y = int.Parse(value[1]);
            if (value[0] == "z") Z = int.Parse(value[1]);
        }

        public virtual bool IsNeighbourOf(Cube neighbour)
        {
            return ! Equals(neighbour) &&
                   Math.Abs(X - neighbour.X) <= 1 &&
                   Math.Abs(Y - neighbour.Y) <= 1 &&
                   Math.Abs(Z - neighbour.Z) <= 1;
        }

        public bool LocatedAt(int[] coordinates) =>
            X == coordinates[0] && Y == coordinates[1] && Z == coordinates[2] && SameWCoordinates(coordinates);

        protected virtual bool SameWCoordinates(int[] coordinates) =>
            true;

        public bool Equals(Cube? other)
        {
            if (other is null) return false;
            return other.X == X && other.Y == Y && other.Z == Z && other.W == W;
        }

        public void Toggle() => IsActive = !IsActive;
    }
}
