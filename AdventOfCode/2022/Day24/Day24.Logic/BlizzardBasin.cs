namespace Day24.Logic;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class BlizzardBasin
{
    private readonly string _input;
    private readonly string[] _lines;
    private char[][] _map;

    public int Height { get; }
    public int Width { get; }
    public (int X, int Y) Entrance { get; }
    public (int X, int Y) Exit { get; }
    public List<(int X, int Y, Direction Facing)> Blizzards { get; }

    public BlizzardBasin(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        Blizzards = new List<(int X, int Y, Direction Facing)>();
        Height = _lines.Length;
        Width = _lines[0].Length;

        // TODO: Calculate based on input
        Entrance = (1, 0);
        Exit = (Width - 2, Height - 1);

        _map = new char[Height][];
        for (var y = 0; y < Height; y++)
        {
            _map[y] = new char[Width];

            for (var x = 0; x < Width; x++)
            {
                _map[y][x] = _lines[y][x];
                switch (_map[y][x])
                {
                    case '>': Blizzards.Add((x, y, Direction.Right)); break;
                    case '<': Blizzards.Add((x, y, Direction.Left)); break;
                    case '^': Blizzards.Add((x, y, Direction.Up)); break;
                    case 'v': Blizzards.Add((x, y, Direction.Down)); break;
                }
            }
        }
    }

}
