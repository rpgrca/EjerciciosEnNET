namespace Day9.Logic;

public class RopeBridge
{
    private readonly string _input;
    private readonly List<Knot> _knots;
    private readonly Dictionary<(int X, int Y), int> _uniquePositions;

    public int VisitedPositions => _uniquePositions.Count;

    public RopeBridge(string input, int knots = 2)
    {
        _input = input;
        _knots = new List<Knot>();
        for (var index = 0; index < knots; index++)
        {
            _knots.Add(new Knot());
        }

        _uniquePositions = new Dictionary<(int X, int Y), int> { { (0, 0), 1 } };

        var lines = _input.Split("\n");
        foreach (var line in lines)
        {
            var splittedLine = line.Split(" ");
            (string direction, int steps) = (splittedLine[0], int.Parse(splittedLine[1]));
            switch (direction)
            {
                case "R":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveRight();
                        AdjustMovementForTail();
                    }
                    break;

                case "L":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveLeft();
                        AdjustMovementForTail();
                    }
                    break;

                case "U":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveUp();
                        AdjustMovementForTail();
                    }
                    break;

                case "D":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveDown();
                        AdjustMovementForTail();
                    }
                    break;
            }
        }
    }

    private void MoveRight() => _knots[0].MoveRight();

    private void MoveLeft() => _knots[0].MoveLeft();

    private void MoveUp() => _knots[0].MoveUp();

    private void MoveDown() => _knots[0].MoveDown();

    private void AdjustMovementForTail()
    {
        if (_knots[1].TooFarHorizontallyFrom(_knots[0]))
        {
            if (_knots[1].IsAtMyRight(_knots[0]))
            {
                _knots[1].MoveRight();

                if (_knots[1].IsAboveMe(_knots[0]))
                {
                    _knots[1].MoveUp();
                }
                else if (_knots[1].IsBelowMe(_knots[0]))
                {
                    _knots[1].MoveDown();
                }
            }
            else if (_knots[1].IsAtMyLeft(_knots[0]))
            {
                _knots[1].MoveLeft();

                if (_knots[1].IsAboveMe(_knots[0]))
                {
                    _knots[1].MoveUp();
                }
                else if (_knots[1].IsBelowMe(_knots[0]))
                {
                    _knots[1].MoveDown();
                }
            }
        }
        else
        {
            if (_knots[1].TooFarVerticallyFrom(_knots[0]))
            {
                if (_knots[1].IsAboveMe(_knots[0]))
                {
                    _knots[1].MoveUp();
                    if (_knots[1].IsAtMyLeft(_knots[0]))
                    {
                        _knots[1].MoveLeft();
                    }
                    else if (_knots[1].IsAtMyRight(_knots[0]))
                    {
                        _knots[1].MoveRight();
                    }
                }
                else if (_knots[1].IsBelowMe(_knots[0]))
                {
                    _knots[1].MoveDown();
                    if (_knots[1].IsAtMyLeft(_knots[0]))
                    {
                        _knots[1].MoveLeft();
                    }
                    else if (_knots[1].IsAtMyRight(_knots[0]))
                    {
                        _knots[1].MoveRight();
                    }
                }
            }
        }

        _uniquePositions.TryAdd(_knots[1].Position, 0);
        _uniquePositions[_knots[1].Position]++;
    }
}