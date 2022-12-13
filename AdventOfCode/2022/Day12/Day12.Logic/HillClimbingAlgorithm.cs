namespace Day12.Logic;

public class HillClimbingAlgorithm
{
    private readonly string[] _lines;
    private readonly int _columns;
    private readonly int _rows;
    private readonly int[][] _map;
    private readonly int[][] _paths;
    private (int X, int Y) _startingPoint;
    private (int X, int Y) _endingPoint;

    public int FewestStepsToTarget { get; private set; }

    public static HillClimbingAlgorithm CreateMultipleStartingPoints(string input) =>
        new(input, (m, s) => new StartingPoints(m, s));

    public static HillClimbingAlgorithm CreateSingleStartingPoint(string input) =>
        new(input, (m, s) => new StartingPoint(m, s));

    private HillClimbingAlgorithm(string input, Func<int[][], (int, int), System.Collections.IEnumerable> startingPointCreator)
    {
        _lines = input.Split("\n");
        _columns = _lines[0].Length;
        _rows = _lines.Length;
        _map = new int[_rows][];
        _paths = new int[_rows][];
        FewestStepsToTarget = int.MaxValue;

        LoadMap();
        Run(startingPointCreator(_map, _startingPoint));
    }

    private void LoadMap()
    {
        var index = 0;
        foreach (var line in _lines)
        {
            var subIndex = 0;

            _map[index] = new int[_columns];
            _paths[index] = new int[_columns];
            foreach (var character in line)
            {
                switch (character)
                {
                    case 'S':
                        _startingPoint.X = subIndex;
                        _startingPoint.Y = index;
                        _map[index][subIndex] = 'a';
                        break;
                
                    case 'E':
                        _endingPoint.X = subIndex;
                        _endingPoint.Y = index;
                        _map[index][subIndex] = 'z';
                        break;

                    default:
                        _map[index][subIndex] = character;
                        break;
                }

                _paths[index][subIndex] = int.MaxValue;
                subIndex++;
            }

            index++;
        }
    }

    private void Run(System.Collections.IEnumerable startingPoints)
    {
        var minimum = int.MaxValue;

        foreach (int point in startingPoints)
        {
            MoveFrom(point & 0xff, point >> 8, 0);

            var value = _paths[_endingPoint.Y][_endingPoint.X];
            if (value < minimum)
            {
                minimum = value;
            }
        }

        FewestStepsToTarget = minimum;
    }

    private void MoveFrom(int x, int y, int steps)
    {
        if (steps >= _paths[y][x])
        {
            return;
        }
        _paths[y][x] = steps;

        if (x == _endingPoint.X && y == _endingPoint.Y)
        {
            return;
        }

        var current = _map[y][x];
        if (x > 0 && _map[y][x - 1] - current < 2)
        {
            MoveFrom(x - 1, y, steps + 1);
        }

        if (x < _columns - 1 && _map[y][x + 1] - current < 2)
        {
            MoveFrom(x + 1, y, steps + 1);
        }

        if (y > 0 && _map[y - 1][x] - current < 2)
        {
            MoveFrom(x, y - 1, steps + 1);
        }

        if (y < _rows - 1 && _map[y + 1][x] - current < 2)
        {
            MoveFrom(x, y + 1, steps + 1);
        }
    }
}