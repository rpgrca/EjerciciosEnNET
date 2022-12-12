namespace Day12.Logic;

public class HillClimbingAlgorithm
{
    private string _input;
    private string[] _lines;
    private readonly int _columns;
    private readonly int _rows;

    public int FewestStepsToTarget { get; private set; }

    public HillClimbingAlgorithm(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _columns = _lines[0].Length;
        _rows = _lines.Length;
        FewestStepsToTarget = int.MaxValue;

        StartAlgorithm();
    }

    private void StartAlgorithm()
    {
        MoveFrom(0, 0, 0);
    }

    private void MoveFrom(int x, int y, int steps)
    {
        if (x >= _columns || y >= _rows)
        {
            return;
        }

        if (_lines[y][x] == 'E')
        {
            FewestStepsToTarget = steps;
            return;
        }
        else
        {
            MoveFrom(x + 1, y, steps + 1);
            MoveFrom(x, y + 1, steps + 1);
        }
    }

}
