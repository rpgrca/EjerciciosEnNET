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
    private readonly char[,] _map;

    public int X { get; private set; }
    public int Y { get; private set; }
    public Direction Facing { get; private set; }

    public Pointer(char[,] map, int startingX, int startingY)
    {
        _map = map;
        Facing = Direction.Right;
        X = startingX;
        Y = startingY;
    }

    public void Move((char Command, int Amount) command)
    {
        switch (command.Command)
        {
            case 'F':
                switch (Facing)
                {
                    case Direction.Right:
                        for (var step = 0; step < command.Amount; step++)
                        {
                            X = GetLocationRightOfMyself();
                        }
                        break;
                    case Direction.Down:
                        for (var step = 0; step < command.Amount; step++)
                        {
                            Y = GetLocationDownOfMyself();
                        }
                        break;
                    case Direction.Left:
                        for (var step = 0; step < command.Amount; step++)
                        {
                            X = GetLocationLeftOfMyself();
                        }
                        break;
                    case Direction.Up:
                        break;
                }
                break;

            case 'R':
                Facing = (Direction)(((int)Facing + 1) % 4);
                break;

            case 'L':
                Facing = (Direction)(((int)Facing + 3) % 4);
                break;
        }
    }

    private int GetLocationRightOfMyself()
    {
        if (X + 1 >= _map.GetLength(1))
        {
            return WrapRight();
        }
        else
        {
            if (_map[Y,X + 1] == '#')
            {
                return X;
            }

            if (_map[Y,X + 1] == ' ')
            {
                return WrapRight();
            }
        }

        return X + 1;
    }

    private int GetLocationLeftOfMyself()
    {
        var newX = X - 1;
        if (newX < 0)
        {
            return WrapLeft();
        }
        else
        {
            if (_map[Y,newX] == '#')
            {
                return X;
            }

            if (_map[Y,newX] == ' ')
            {
                return WrapLeft();
            }
        }

        return newX;
    }

    private int GetLocationDownOfMyself()
    {
        var newY = Y + 1;
        if (newY >= _map.GetLength(0))
        {
            return WrapDown();
        }
        else
        {
            if (_map[newY,X] == '#')
            {
                return Y;
            }

            if (_map[newY,X] == ' ')
            {
                return WrapDown();
            }
        }

        return newY;
    }

    private int WrapRight()
    {
        var x = 0;
        while (_map[Y, x] == ' ')
        {
            x++;
        }

        if (_map[Y, x] == '#')
        {
            return X;
        }

        return x;
    }

    private int WrapLeft()
    {
        var x = _map.GetLength(1) - 1;
        while (_map[Y, x] == ' ')
        {
            x--;
        }

        if (_map[Y, x] == '#')
        {
            return X;
        }

        return x;
    }

    private int WrapDown()
    {
        var y = 0;
        while (_map[y, X] == ' ')
        {
            y++;
        }

        if (_map[y, X] == '#')
        {
            return Y;
        }

        return y;
    }

    public int Decode() => 1000 * (Y + 1) + 4 * (X + 1) + (int)Facing;
}
