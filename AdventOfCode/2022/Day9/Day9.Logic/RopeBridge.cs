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
                        MoveHeadRight();
                        AdjustMovementForOtherKnots();
                    }
                    break;

                case "L":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveHeadLeft();
                        AdjustMovementForOtherKnots();
                    }
                    break;

                case "U":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveHeadUp();
                        AdjustMovementForOtherKnots();
                    }
                    break;

                case "D":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveHeadDown();
                        AdjustMovementForOtherKnots();
                    }
                    break;
            }
        }
    }

    private void MoveHeadRight() => _knots[0].MoveRight();

    private void MoveHeadLeft() => _knots[0].MoveLeft();

    private void MoveHeadUp() => _knots[0].MoveUp();

    private void MoveHeadDown() => _knots[0].MoveDown();

    private void AdjustMovementForOtherKnots()
    {
        for (var index = 1; index < _knots.Count; index++)
        {
            if (_knots[index].TooFarHorizontallyFrom(_knots[index - 1]))
            {
                if (_knots[index].IsAtMyRight(_knots[index - 1]))
                {
                    _knots[index].MoveRight();
     
                    if (_knots[index].IsAboveMe(_knots[index - 1]))
                    {
                        _knots[index].MoveUp();
                    }
                    else if (_knots[index].IsBelowMe(_knots[index - 1]))
                    {
                        _knots[index].MoveDown();
                    }
                }
                else if (_knots[index].IsAtMyLeft(_knots[index - 1]))
                {
                    _knots[index].MoveLeft();
     
                    if (_knots[index].IsAboveMe(_knots[index - 1]))
                    {
                        _knots[index].MoveUp();
                    }
                    else if (_knots[index].IsBelowMe(_knots[index - 1]))
                    {
                        _knots[index].MoveDown();
                    }
                }
            }
            else
            {
                if (_knots[index].TooFarVerticallyFrom(_knots[index - 1]))
                {
                    if (_knots[index].IsAboveMe(_knots[index - 1]))
                    {
                        _knots[index].MoveUp();
                        if (_knots[index].IsAtMyLeft(_knots[index - 1]))
                        {
                            _knots[index].MoveLeft();
                        }
                        else if (_knots[index].IsAtMyRight(_knots[index - 1]))
                        {
                            _knots[index].MoveRight();
                        }
                    }
                    else if (_knots[index].IsBelowMe(_knots[index - 1]))
                    {
                        _knots[index].MoveDown();
                        if (_knots[index].IsAtMyLeft(_knots[index - 1]))
                        {
                            _knots[index].MoveLeft();
                        }
                        else if (_knots[index].IsAtMyRight(_knots[index - 1]))
                        {
                            _knots[index].MoveRight();
                        }
                    }
                }
            }
        }

        _uniquePositions.TryAdd(_knots.Last().Position, 0);
        _uniquePositions[_knots.Last().Position]++;
    }
}