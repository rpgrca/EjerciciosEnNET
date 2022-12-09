namespace Day9.Logic.Directions;

internal abstract class Direction : IDirection
{
    protected readonly List<Knot> Knots;
    private readonly Dictionary<(int X, int Y), int> UniquePositions;

    protected Direction(List<Knot> knots, Dictionary<(int X, int Y), int> uniquePositions)
    {
        Knots = knots;
        UniquePositions = uniquePositions;
    }

    public abstract void Move();

    protected void AdjustMovementForOtherKnots()
    {
        for (var index = 1; index < Knots.Count; index++)
        {
            if (Knots[index].TooFarHorizontallyFrom(Knots[index - 1]))
            {
                if (Knots[index].IsAtMyRight(Knots[index - 1]))
                {
                    Knots[index].MoveRight();
                }
                else
                {
                    Knots[index].MoveLeft();
                }
                CheckVerticalAxis(index);
            }
            else
            {
                if (Knots[index].TooFarVerticallyFrom(Knots[index - 1]))
                {
                    if (Knots[index].IsAboveMe(Knots[index - 1]))
                    {
                        Knots[index].MoveUp();
                    }
                    else
                    {
                        Knots[index].MoveDown();
                    }
                    CheckHorizontalAxis(index);
                }
            }
        }

        UniquePositions.TryAdd(Knots.Last().Position, 0);
        UniquePositions[Knots.Last().Position]++;
    }

    private void CheckHorizontalAxis(int index)
    {
        if (Knots[index].IsAtMyLeft(Knots[index - 1]))
        {
            Knots[index].MoveLeft();
        }
        else if (Knots[index].IsAtMyRight(Knots[index - 1]))
        {
            Knots[index].MoveRight();
        }
    }

    private void CheckVerticalAxis(int index)
    {
        if (Knots[index].IsAboveMe(Knots[index - 1]))
        {
            Knots[index].MoveUp();
        }
        else if (Knots[index].IsBelowMe(Knots[index - 1]))
        {
            Knots[index].MoveDown();
        }
    }
}