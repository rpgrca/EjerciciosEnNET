namespace Day14.Logic;

public class RockLoader
{
    private readonly string[] _lines;
    private readonly List<(int X, int Y)> _points;
    private string _line;
    private string[] _segments;
    private int _index;
    private string[] _coordinates;
    private (int, int) _startingPoint;
    private (int, int) _endingPoint;

    public List<(int X, int Y)> Points => _points;

    public RockLoader(string input)
    {
        _lines = input.Split("\n");
        _points = new List<(int X, int Y)>();
        _line = string.Empty;
        _segments = Array.Empty<string>();
        _coordinates = Array.Empty<string>();

        Parse();
    }

    private void Parse()
    {
        foreach (var line in _lines)
        {
            _line = line;
            SplitLineInSegments();
            BuildWallsFromSegments();
        }
    }

    private void SplitLineInSegments() =>
        _segments = _line.Split(" -> ");

    private void BuildWallsFromSegments()
    {
        for (_index = 0; _index < _segments.Length - 1; _index++)
        {
            SplitSegmentIntoCoordinates();
            CalculateStartingPoint();
            CalculateEndingPoint();

            TraceLineFromLeftToRight();
            TraceLineFromRightToLeft();
            TraceLineFromTopToBottom();
            TraceLineFromBottomToTop();
        }
    }

    private void SplitSegmentIntoCoordinates() =>
        _coordinates = _segments[_index].Split(",");

    private void CalculateStartingPoint() =>
        _startingPoint = (int.Parse(_coordinates[0]), int.Parse(_coordinates[1]));

    private void CalculateEndingPoint()
    {
        _coordinates = _segments[_index + 1].Split(",");
        _endingPoint = (int.Parse(_coordinates[0]), int.Parse(_coordinates[1]));
    }

    private void TraceLineFromLeftToRight() =>
        TraceHorizontalLine(_startingPoint.Item1, _endingPoint.Item1, _startingPoint.Item2);

    private void TraceLineFromRightToLeft() =>
        TraceHorizontalLine(_endingPoint.Item1, _startingPoint.Item1, _startingPoint.Item2);

    private void TraceLineFromTopToBottom() =>
        TraceVerticalLine(_startingPoint.Item2, _endingPoint.Item2, _startingPoint.Item1);

    private void TraceLineFromBottomToTop() =>
        TraceVerticalLine(_endingPoint.Item2, _startingPoint.Item2, _startingPoint.Item1);

    private void TraceHorizontalLine(int start, int end, int row)
    {
        for (var subIndex = start; subIndex <= end; subIndex++)
        {
            _points.Add((subIndex, row));
        }
    }

    private void TraceVerticalLine(int start, int end, int column)
    {
        for (var subIndex = start; subIndex <= end; subIndex++)
        {
            _points.Add((column, subIndex));
        }
    }
}