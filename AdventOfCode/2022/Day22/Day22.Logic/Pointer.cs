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

    public Pointer(char[,] map)
    {
        _map = map;
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
                        break;
                    case Direction.Left:
                        break;
                    case Direction.Up:
                        break;
                }
                break;
        }
    }

    private int GetLocationRightOfMyself()
    {
        if (X + 1 >= _map.GetLength(0))
        {
            for (var x = 0; x < _map.GetLength(0); x++)
            {
                if (_map[Y, x] == '#')
                {
                    return X;
                }

                if (_map[Y, x] == '.')
                {
                    X = x;
                    return X;
                }
            }
        }

        if (_map[Y,X + 1] == '#')
        {
            return X;
        }

        return X + 1;
    }

    public int Decode() => 1000 * (Y + 1) + 4 * (X + 1) + (int)Facing;
}
