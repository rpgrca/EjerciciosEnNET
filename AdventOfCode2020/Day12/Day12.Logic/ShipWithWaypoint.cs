namespace AdventOfCode.Day12.Logic
{
    public class ShipWithWaypoint : Ship
    {
        public ShipWithWaypoint(string instructions, (int, int, int, int) startingWaypoint)
            : base(instructions, startingWaypoint)
        {
        }

        protected override void MoveNorth() => _waypoint.North += CurrentInstruction.Offset;
        protected override void MoveSouth() => _waypoint.South += CurrentInstruction.Offset;
        protected override void MoveEast() => _waypoint.East += CurrentInstruction.Offset;
        protected override void MoveWest() => _waypoint.West += CurrentInstruction.Offset;
    }
}