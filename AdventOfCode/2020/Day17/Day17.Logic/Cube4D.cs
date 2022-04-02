using System;

namespace AdventOfCode2020.Day17.Logic
{
    public class Cube4D : Cube
    {
        public Cube4D(string coordinates, bool active)
            : base(coordinates, active)
        {
        }

        protected override void AssignValue(string[] value)
        {
            base.AssignValue(value);
            if (value[0] == "w") W = int.Parse(value[1]);
        }

        public override bool IsNeighbourOf(Cube neighbour) =>
            Math.Abs(W - neighbour.W) <= 1 && base.IsNeighbourOf(neighbour);

        protected override bool SameWCoordinates(int[] coordinates) =>
            W == coordinates[3];
    }
}