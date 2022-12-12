namespace Day12.Logic;

public class PriorityQueue : List<(int X, int Y, char Weight)>
{
}

public class HillClimbingAlgorithm
{
    private string _input;
    private readonly bool _fromAnyLocation;
    private string[] _lines;
    private readonly int _columns;
    private readonly int _rows;
    private readonly char[][] _map;
    private readonly int[][] _paths;
    private PriorityQueue _queue;
    private (int X, int Y) _startingPoint;
    private (int X, int Y) _endingPoint;

    public int FewestStepsToTarget { get; private set; }

    public HillClimbingAlgorithm(string input, bool fromAnyLocation = false)
    {
        _input = input;
        _fromAnyLocation = fromAnyLocation;
        _lines = _input.Split("\n");
        _columns = _lines[0].Length;
        _rows = _lines.Length;
        _map = new char[_rows][];
        _paths = new int[_rows][];
        _queue = new PriorityQueue();
        FewestStepsToTarget = int.MaxValue;

        var index = 0;

        foreach (var line in _lines)
        {
            var subIndex = 0;

            _map[index] = new char[_columns];
            _paths[index] = new int[_columns];
            foreach (var character in line)
            {
                if (character == 'S')
                {
                    _startingPoint.X = subIndex;
                    _startingPoint.Y = index;
                    _map[index][subIndex] = 'a';
                }
                else if (character == 'E')
                {
                    _endingPoint.X = subIndex;
                    _endingPoint.Y = index;
                    _map[index][subIndex] = 'z';
                }
                else
                {
                    _map[index][subIndex] = character;
                }

                _paths[index][subIndex] = int.MaxValue;
                _queue.Add((subIndex, index, character));
                subIndex++;
            }

            index++;
        }

        StartAlgorithm();
    }

    private void StartAlgorithm()
    {
        if (_fromAnyLocation)
        {
            var minimum = int.MaxValue;

            for (var y = 0; y < _rows; y++)
            {
                for (var x = 0; x < _columns; x++)
                {
                    if (_map[y][x] == 'a')
                    {
                        FewestStepsToTarget = int.MaxValue;
                        ClearPaths();
                        MoveFrom(x, y, 'a', 0);

                        var value = _paths[_endingPoint.Y][_endingPoint.X];
                        if (value < minimum)
                        {
                            minimum = value;
                        }
                    }
                }
            }

            FewestStepsToTarget = minimum;
        }
        else
        {
            MoveFrom(_startingPoint.X, _startingPoint.Y, 'a', 0);
            FewestStepsToTarget = _paths[_endingPoint.Y][_endingPoint.X];
        }
    }

    private void ClearPaths()
    {
        for (var y = 0; y < _rows; y++)
        {
            for (var x = 0; x < _columns; x++)
            {
                _paths[y][x] = int.MaxValue;
            }
        }
    }

    private void MoveFrom(int x, int y, char fromSquare, int steps)
    {
        if (x < 0 || y < 0 || x >= _columns || y >= _rows)
        {
            return;
        }

        var current = _map[y][x];
        var diff = current - fromSquare;
        if (diff > 1)
        {
            return;
        }

        if (steps >= _paths[y][x])
        {
            return;
        }
        _paths[y][x] = steps;

        if (x == _endingPoint.X && y == _endingPoint.Y)
        {
            return;
        }

        MoveFrom(x - 1, y, current, steps + 1);
        MoveFrom(x + 1, y, current, steps + 1);
        MoveFrom(x, y - 1, current, steps + 1);
        MoveFrom(x, y + 1, current, steps + 1);
    }
}
