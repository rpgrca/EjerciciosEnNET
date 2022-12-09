namespace Day9.Logic.Directions;

internal class Right : Direction
{
    public Right(List<Knot> knots, Dictionary<(int X, int Y), int> uniquePositions)
        : base(knots, uniquePositions)
    {
    }

    public override void Move()
    {
        Knots[0].MoveRight();
        AdjustMovementForOtherKnots();
    }
}
