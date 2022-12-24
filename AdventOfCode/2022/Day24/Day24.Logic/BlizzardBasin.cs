namespace Day24.Logic;

public class BlizzardBasin
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[][] _map;
    private List<char[][]> _movements;

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

        _movements = new List<char[][]>
        {
            _map.Select(v => v.ToArray()).ToArray()
        };
    }

    public string GetImage() =>
        GetImage(_map);

    private string GetImage(char[][] map) =>
        string.Join('\n', map.Select(l => string.Concat(l)));

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

    public int FindShortestPath() => FindShortestPath(Entrance, Exit, 0, (x, y) => (Height - y) * 1000 + (Width - x));

    private int FindShortestPath((int X, int Y) entrance, (int X, int Y) egress, int round, Func<int, int, int> priorityCallback)
    {
        var minimum = 1000;
        var visited = new HashSet<(int X, int Y, int Round)>();

        var queue = new PriorityQueue<(int X, int Y, int Round), int>();
        queue.Enqueue((entrance.X, entrance.Y, round), 1);

        while (queue.Count > 0)
        {
            var stage = queue.Dequeue();
            if (stage.X == egress.X && stage.Y == egress.Y)
            {
                if (minimum > stage.Round) // TODO: +1?
                {
                    minimum = stage.Round;
                    continue;
                }
            }

            if (stage.Round > minimum)
            {
                continue;
            }

            if (visited.Contains(stage))
            {
                continue;
            }

            visited.Add(stage);

            for (var counter = _movements.Count; counter <= stage.Round + 1; counter++)
            {
                MoveBlizzards();
                _movements.Add(_map.Select(v => v.ToArray()).ToArray());
            }

            var map = _movements[stage.Round + 1];
            (int X, int Y)[] neightbours =
            {
                (stage.X, stage.Y + 1),
                (stage.X + 1, stage.Y),
                (stage.X, stage.Y),
                (stage.X - 1, stage.Y),
                (stage.X, stage.Y - 1)
            };

            foreach (var (x, y) in neightbours)
            {
                if (x >= 0 && x <= Width - 1 && y >= 0 && y <= Height - 1)
                {
                    if (map[y][x] == '.')
                    {
                        if (x == 23 && y == 19 || x == 24 && y == 19) continue;

                        queue.Enqueue((x, y, stage.Round + 1), (Height - y) * 1000 + (Width - x));
                    }
                }
            }
        }

        return minimum;
    }

    public int FindShortestPathAndBack()
    {
        var minutes = 0;
        minutes += FindShortestPath();
        minutes += FindShortestPath(Exit, Entrance, minutes, (x, y) => y * 1000 + x) - minutes;
        minutes += FindShortestPath(Entrance, Exit, minutes, (x, y) => (Height - y) * 1000 + (Width - x)) - minutes;

        return minutes;
    }
}
