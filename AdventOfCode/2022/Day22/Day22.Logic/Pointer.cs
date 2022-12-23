namespace Day22.Logic;

public enum Direction
{
    Right = 0,
    Down,
    Left,
    Up
}

internal class Pointer
{
    protected readonly char[,] _map;
    protected readonly int _startingX;
    protected readonly int _startingY;

    public int X { get; protected set; }
    public int Y { get; protected set; }
    public Direction Facing { get; protected set; }
    public Dictionary<(int X, int Y), char> VisitedTiles { get; }
    public List<(int X, int Y, char Direction)> Movements { get; }

    public Pointer(char[,] map, int startingX, int startingY)
    {
        _map = map;
        Facing = Direction.Right;
        X = _startingX = startingX;
        Y = _startingY = startingY;
        VisitedTiles = new Dictionary<(int X, int Y), char>();
        Movements = new List<(int X, int Y, char Direction)>();
    }

    public void Move((char Command, int Amount) command)
    {
        switch (command.Command)
        {
            case 'F':
                for (var step = 0; step < command.Amount; step++)
                {
                    Action getLocation = Facing switch
                    {
                        Direction.Right => () => (X, Y, Facing) = GetLocationRightOfMyself(),
                        Direction.Down => () => (X, Y, Facing) = GetLocationBelowMyself(),
                        Direction.Left => () => (X, Y, Facing) = GetLocationLeftOfMyself(),
                        _ => () => (X, Y, Facing) = GetLocationAboveMyself(),
                    };

                    getLocation();
                    RecordPosition();
                }
                break;

            case 'R':
                Facing = (Direction)(((int)Facing + 1) % 4);
                RecordPosition();
                break;

            case 'L':
                Facing = (Direction)(((int)Facing + 3) % 4);
                RecordPosition();
                break;
        }
    }

    protected virtual (int, int, Direction) GetLocationRightOfMyself()
    {
        var newX = X + 1;
        if (_map[Y, newX] == ' ')
        {
            return WrapRight();
        }

        return (_map[Y, newX] == '#' ? X : newX, Y, Facing);
    }

    protected virtual (int, int, Direction) GetLocationLeftOfMyself()
    {
        var newX = X - 1;
        if (_map[Y, newX] == ' ')
        {
            return WrapLeft();
        }

        return (_map[Y, newX] == '#' ? X : newX, Y, Facing);
    }

    protected virtual (int, int, Direction) GetLocationBelowMyself()
    {
        var newY = Y + 1;
        if (_map[newY, X] == ' ')
        {
            return WrapDown();
        }

        return (X, _map[newY,X] == '#' ? Y : newY, Facing);
    }

    protected virtual (int, int, Direction) GetLocationAboveMyself()
    {
        var newY = Y - 1;
        if (_map[newY, X] == ' ')
        {
            return WrapUp();
        }

        return (X, _map[newY,X] == '#' ? Y : newY, Facing);
    }

    private (int, int, Direction) WrapRight() =>
        WrapHorizontally(() => 1, x => x + 1);

    private (int, int, Direction) WrapLeft() =>
        WrapHorizontally(() => _map.GetLength(1) - 2, x => x - 1);

    private (int, int, Direction) WrapHorizontally(Func<int> initializer, Func<int, int> modifier)
    {
        var wrappedX = initializer();
        while (_map[Y, wrappedX] == ' ')
        {
            wrappedX = modifier(wrappedX);
        }

        return (_map[Y, wrappedX] == '#' ? X : wrappedX, Y, Facing);
    }

    private (int, int, Direction) WrapDown()
    {
        var y = 0;
        while (_map[y, X] == ' ')
        {
            y++;
        }

        return (X, _map[y, X] == '#' ? Y : y, Facing);
    }

    private (int, int, Direction) WrapUp()
    {
        var y = _map.GetLength(0) - 1;
        while (_map[y, X] == ' ')
        {
            y--;
        }

        return (X, _map[y, X] == '#' ? Y : y, Facing);
    }

    public long Decode() => 1000 * Y + 4 * X + (int)Facing;

    private void RecordPosition()
    {
        var direction = Facing switch {
            Direction.Down => 'v',
            Direction.Up => '^',
            Direction.Left => '<',
            _ => '>'
        };

        Movements.Add((X, Y, direction));
        if (VisitedTiles.ContainsKey((X, Y)))
        {
            VisitedTiles[(X, Y)] = direction;
        }
        else
        {
            VisitedTiles.Add((X, Y), direction);
        }
    }
}