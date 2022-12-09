namespace Day9.Logic.Directions;

internal class Down : Direction
{
    public Down(List<Knot> knots, Dictionary<(int X, int Y), int> uniquePositions)
        : base(knots, uniquePositions)
    {
    }

    public override void Move()
    {
        Knots[0].MoveDown();
        AdjustMovementForOtherKnots();
    }
}
