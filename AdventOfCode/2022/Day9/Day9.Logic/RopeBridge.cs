namespace Day9.Logic;

public class RopeBridge
{
    private readonly string _input;
    private (int X, int Y) _head;
    private (int X, int Y) _tail;

    public int VisitedPositions { get; private set; }

    public RopeBridge(string input)
    {
        _input = input;
        VisitedPositions = 1;

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
                    }
                    break;

                case "L":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveLeft();
                    }
                    break;

                case "U":
                    for (var step = 0; step < steps; step++)
                    {
                        MoveUp();
                    }
                    break;
            }
        }
    }

    private void MoveRight()
    {
        _head.X++;
        if (Math.Abs(_head.X - _tail.X) > 1)
        {
            _tail.X++;

            if (_head.Y < _tail.Y)
            {
                _tail.Y--;
            }

            VisitedPositions++;
        }
    }

    private void MoveLeft()
    {
        _head.X--;
        if (Math.Abs(_head.X - _tail.X) > 1)
        {
            _tail.X--;

            if (_head.Y < _tail.Y)
            {
                _tail.Y--;
            }

            VisitedPositions++;
        }
    }

    private void MoveUp()
    {
        _head.Y--;
        if (Math.Abs(_head.Y - _tail.Y) > 1)
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

            VisitedPositions++;
        }
    }

}
