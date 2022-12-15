namespace Day15.Logic;

public record Sensor
{
    public int X { get; }
    public int Y { get; }
    public int Range { get; }

    public Sensor(int x, int y, (int X, int Y) beacon)
    {
        X = x;
        Y = y;
        Range = Math.Abs(X - beacon.X) + Math.Abs(Y - beacon.Y);
    }
}

public class BeaconExclusionZone
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly Dictionary<int, HashSet<int>> _coveredPositionsPerRow;

    public (int X, int Y) TopLeft { get; private set; }
    public (int X, int Y) BottomRight { get; private set; }
    public List<Sensor> Sensors { get; private set; }
    public List<(int X, int Y)> Beacons { get; private set; }


    public BeaconExclusionZone(string input)
    {
        _input = input;

        Sensors = new List<Sensor>();
        Beacons = new List<(int X, int Y)>();

        _coveredPositionsPerRow = new Dictionary<int, HashSet<int>>();
        _lines = _input.Split("\n");
        foreach (var line in _lines)
        {
            var sections = line.Split(":");
            var coordinates = sections[0][10..];
            var splitCoordinates = coordinates.Split(",");
            var sensorX = int.Parse(splitCoordinates[0].Split("=")[1]);
            var sensorY = int.Parse(splitCoordinates[1].Split("=")[1]);

            AdjustRange(sensorX, sensorY);

            coordinates = sections[1][23..];
            splitCoordinates = coordinates.Split(",");
            var beaconX = int.Parse(splitCoordinates[0].Split("=")[1]);
            var beaconY = int.Parse(splitCoordinates[1].Split("=")[1]);

            if (! Beacons.Contains((beaconX, beaconY)))
            {
                Beacons.Add((beaconX, beaconY));
                AdjustRange(beaconX, beaconY);
            }

            Sensors.Add(new(sensorX, sensorY, (beaconX, beaconY)));
        }
    }

    private void AdjustRange(int x, int y)
    {
        if (TopLeft.X > x)
        {
            TopLeft = (x, TopLeft.Y);
        }
        if (TopLeft.Y > y)
        {
            TopLeft = (TopLeft.X, y);
        }

        if (BottomRight.X < x)
        {
            BottomRight = (x, BottomRight.Y);
        }
        if (BottomRight.Y < y)
        {
            BottomRight = (BottomRight.X, y);
        }
    }

    public int CalculateCoveredPositionsFor(int y)
    {
        return 0;
    }
}
