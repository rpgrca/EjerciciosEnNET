namespace Day24.Logic;

public record Blizzard
{
    private readonly int _valleyWidth;
    private readonly int _valleyHeight;

    public int X { get; private set; }
    public int Y { get; private set; }
    public char Direction { get; }

    public Blizzard(int x, int y, char direction, int valleyWidth, int valleyHeight)
    {
        X = x;
        Y = y;
        Direction = direction;
        _valleyWidth = valleyWidth;
        _valleyHeight = valleyHeight;
    }

    public void Deconstruct(out int x, out int y, out char direction)
    {
        x = X;
        y = Y;
        direction = Direction;
    }

    public void Move()
    {
        switch (Direction)
        {
            case '^':
                Y = Y - 1 >= 1 ? Y - 1 : _valleyHeight;
                break;
            case 'v':
                Y = Y + 1 <= _valleyHeight ? Y + 1 : 1;
                break;
            case '<':
                X = X - 1 >= 1 ? X - 1 : _valleyWidth;
                break;
            case '>':
                X = X + 1 <= _valleyWidth ? X + 1 : 1;
                break;
        }
    }
}
