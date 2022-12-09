namespace Day9.Logic.Directions;

internal class Left : Direction
{
    public Left(List<Knot> knots, Dictionary<(int X, int Y), int> uniquePositions)
        : base(knots, uniquePositions)
    {
    }

    public override void Move()
    {
        Knots[0].MoveLeft();
        AdjustMovementForOtherKnots();
    }
}
