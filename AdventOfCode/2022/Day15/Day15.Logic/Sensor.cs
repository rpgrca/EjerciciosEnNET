namespace Day15.Logic;

public record Sensor
{
    private readonly int _minimum;
    private readonly int _maximum;

    public int X { get; }
    public int Y { get; }
    public int Range { get; }

    private readonly Dictionary<int, (int Start, int End)> _coverage;

    internal Sensor(int x, int y, Beacon beacon)
    {
        X = x;
        Y = y;
        Range = Math.Abs(X - beacon.X) + Math.Abs(Y - beacon.Y);
        _minimum = Y - Range;
        _maximum = Y + Range;
        _coverage = new Dictionary<int, (int Start, int End)>();

        CalculateCoverage();
    }

    private void CalculateCoverage()
    {
        var currentRange = 0;
        var ascending = true;

        for (var y = Y - Range; y <= Y + Range; y++)
        {
            _coverage.Add(y, (X - currentRange, X + currentRange));
            if (currentRange == Range)
            {
                ascending = false;
            }

            currentRange = ascending
                ? currentRange + 1
                : currentRange - 1;
        }
    }

    public bool GetCoveredPositionsFor(int y, out (int Start, int End) coveredPositions)
    {
        if (y >= _minimum && y <= _maximum)
        {
            coveredPositions = _coverage[y];
            return true;
        }

        coveredPositions = default;
        return false;
    }
}