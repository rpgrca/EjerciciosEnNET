namespace Day15.Logic;

public record Sensor
{
    public int X { get; }
    public int Y { get; }
    public int Range { get; }

    private readonly Dictionary<int, List<int>> _coverage;

    public Sensor(int x, int y, (int X, int Y) beacon)
    {
        X = x;
        Y = y;
        Range = Math.Abs(X - beacon.X) + Math.Abs(Y - beacon.Y);
        _coverage = new Dictionary<int, List<int>>();

        CalculateCoverage();
    }

    private void CalculateCoverage()
    {
        var currentRange = 0;
        var ascending = true;

        for (var y = Y - Range; y <= Y + Range; y++)
        {
            _coverage.Add(y, new List<int> { X });

            var index = 0;
            while (index < currentRange)
            {
                _coverage[y].Add(X - (index + 1));
                _coverage[y].Add(X + (index + 1));
                index++;
            }

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
        if (_coverage.TryGetValue(y, out var values))
        {
            return values.Count;
        }
        
        return 0;
    }

    public List<int> GetCoveredPositionsFor(int y)
    {
        if (_coverage.TryGetValue(y, out var values))
        {
            return values;
        }

        return new List<int>();
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
        var hashSet = new HashSet<int>();
        foreach (var sensor in Sensors)
        {
            foreach (var item in sensor.GetCoveredPositionsFor(y))
            {
                hashSet.Add(item);
            }
        }

        foreach (var beacon in Beacons.Where(b => b.Y == y))
        {
            hashSet.Remove(beacon.X);
        }

        return hashSet.Count;
    }
}
