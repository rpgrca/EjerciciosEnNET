namespace Day15.Logic;

public record Sensor
{
    public int X { get; }
    public int Y { get; }
    public int Range { get; }

    private readonly Dictionary<int, (int Start, int End)> _coverage;

    public Sensor(int x, int y, (int X, int Y) beacon)
    {
        X = x;
        Y = y;
        Range = Math.Abs(X - beacon.X) + Math.Abs(Y - beacon.Y);
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

            if (ascending)
            {
                currentRange++;
            }
            else
            {
                currentRange--;
            }
        }
    }

    public int CalculateCoveredPositionsFor(int y)
    {
        if (_coverage.TryGetValue(y, out var value))
        {
            return value.End - value.Start;
        }
        
        return 0;
    }

    public bool GetCoveredPositionsFor(int y, out (int Start, int End) coveredPositions)
    {
        return _coverage.TryGetValue(y, out coveredPositions);
    }
}
