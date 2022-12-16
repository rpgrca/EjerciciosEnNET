namespace Day15.Logic;

public record Sensor
{
    private readonly int _minimum;
    private readonly int _maximum;

    public int X { get; }
    public int Y { get; }
    public int Range { get; }

    internal Sensor(int x, int y, Beacon beacon)
    {
        X = x;
        Y = y;
        Range = Math.Abs(X - beacon.X) + Math.Abs(Y - beacon.Y);
        _minimum = Y - Range;
        _maximum = Y + Range;
    }

    public bool GetCoveredPositionsFor(int y, out (int Start, int End) coveredPositions)
    {
        if (y >= _minimum && y <= _maximum)
        {
            var offset = Range - Math.Abs(Y - y);
            coveredPositions = (X - offset, X + offset);
            return true;
        }

        coveredPositions = default;
        return false;
    }
}