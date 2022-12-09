namespace Day9.Logic.Directions;

internal class Up : Direction
{
    public Up(List<Knot> knots, Dictionary<(int X, int Y), int> uniquePositions)
        : base(knots, uniquePositions)
    {
    }

    public override void Move()
    {
        Knots[0].MoveUp();
        AdjustMovementForOtherKnots();
    }
}
