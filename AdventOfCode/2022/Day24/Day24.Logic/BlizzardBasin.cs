namespace Day24.Logic;

public class BlizzardBasin
{
    private readonly string _input;
    private readonly string[] _lines;
    private char[][] _map;

    public int Height { get; }
    public int Width { get; }
    public (int X, int Y) Entrance { get; }
    public (int X, int Y) Exit { get; }
    public List<Blizzard> Blizzards { get; }

    public BlizzardBasin(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        Blizzards = new List<Blizzard>();
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
                if (_map[y][x] is '>' or '<' or '^' or 'v')
                {
                    Blizzards.Add(new(x, y, _map[y][x], Width - 2, Height - 2));
                }
            }
        }
    }

    public string GetImage() =>
        string.Join('\n', _map.Select(l => string.Concat(l)));

    private void ClearMap()
    {
        foreach (var blizzard in Blizzards)
        {
            _map[blizzard.Y][blizzard.X] = '.';
        }
    }

    public void MoveBlizzards()
    {
        ClearMap();

        foreach (var blizzard in Blizzards)
        {
            blizzard.Move();
        }

        DrawBlizzards();
    }

    private void DrawBlizzards()
    {
        foreach (var (x, y, direction) in Blizzards)
        {
            if (_map[y][x] == '.')
            {
                _map[y][x] = direction;
            }
            else
            {
                if (_map[y][x] > '0' && _map[y][x] <= '9')
                {
                    _map[y][x] = (char)(_map[y][x] + 1);
                }
                else
                {
                    _map[y][x] = '2';
                }
            }
        }
    }
}
