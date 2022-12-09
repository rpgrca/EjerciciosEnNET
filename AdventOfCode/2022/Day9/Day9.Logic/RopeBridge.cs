namespace Day9.Logic;

public class RopeBridge
{
    private readonly string _input;
    private readonly int _knots;
    private (int X, int Y) _head;
    private (int X, int Y) _tail;
    private readonly Dictionary<(int X, int Y), int> _uniquePositions;

    public int VisitedPositions => _uniquePositions.Count;

    public RopeBridge(string input, int knots = 2)
    {
        _input = input;
        _knots = knots;
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

    private void MoveRight() => _head.X++;

    private void MoveLeft() => _head.X--;

    private void AdjustMovementForTail()
    {
        if (Math.Abs(_head.X - _tail.X) > 1)
        {
            if (_head.X > _tail.X)
            {
                _tail.X++;

                if (_head.Y < _tail.Y)
                {
                    _tail.Y--;
                }
                else if (_head.Y > _tail.Y)
                {
                    _tail.Y++;
                }

                _uniquePositions.TryAdd(_tail, 0);
                _uniquePositions[_tail]++;
            }
            else if (_head.X < _tail.X)
            {
                _tail.X--;

                if (_head.Y < _tail.Y)
                {
                    _tail.Y--;
                }
                else if (_head.Y > _tail.Y)
                {
                    _tail.Y++;
                }

                _uniquePositions.TryAdd(_tail, 0);
                _uniquePositions[_tail]++;
            }
       }
       else
       {
           if (Math.Abs(_head.Y - _tail.Y) > 1)
           {
                if (_head.Y < _tail.Y)
                {
                    _tail.Y--;
                    if (_head.X < _tail.X)
                    {
                        _tail.X--;
                    }
                    else if (_head.X > _tail.X)
                    {
                        _tail.X++;
                    }
  
                    _uniquePositions.TryAdd(_tail, 0);
                    _uniquePositions[_tail]++;
                }
                else if (_head.Y > _tail.Y)
                {
                    _tail.Y++;
                    if (_head.X < _tail.X)
                    {
                        _tail.X--;
                    }
                    else if (_head.X > _tail.X)
                    {
                        _tail.X++;
                    }
        
                    _uniquePositions.TryAdd(_tail, 0);
                    _uniquePositions[_tail]++;
                }
           }
       }
    }

    private void MoveUp()
    {
        _head.Y--;
    }

    private void MoveDown()
    {
        _head.Y++;
    }
}