namespace Day12.Logic;

public class PriorityQueue : List<(int X, int Y, char Weight)>
{
}

public class HillClimbingAlgorithm
{
    private string _input;
    private string[] _lines;
    private readonly int _columns;
    private readonly int _rows;
    private readonly char[][] _map;
    private readonly int[][] _paths;
    private PriorityQueue _queue;
    private (int X, int Y) _startingPoint;
    private (int X, int Y) _endingPoint;

    public int FewestStepsToTarget => _paths[_endingPoint.Y][_endingPoint.X];

    public HillClimbingAlgorithm(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _columns = _lines[0].Length;
        _rows = _lines.Length;
        _map = new char[_rows][];
        _paths = new int[_rows][];
        _queue = new PriorityQueue();

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
        MoveFrom(_startingPoint.X, _startingPoint.Y, 'a', 0);
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
