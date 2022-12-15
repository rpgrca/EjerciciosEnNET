namespace Day15.Logic;

public class BeaconExclusionZone
{
    private readonly string _input;
    private readonly string[] _lines;

    public (int X, int Y) TopLeft { get; private set; }
    public (int X, int Y) BottomRight { get; private set; }
    public List<Sensor> Sensors { get; private set; }
    public List<(int X, int Y)> Beacons { get; private set; }

    public BeaconExclusionZone(string input)
    {
        _input = input;

        Sensors = new List<Sensor>();
        Beacons = new List<(int X, int Y)>();

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
            if (sensor.GetCoveredPositionsFor(y, out var coveredPositions))
            {
                for (var index = coveredPositions.Start; index <= coveredPositions.End; index++)
                {
                    hashSet.Add(index);
                }
            }
        }

        foreach (var beacon in Beacons.Where(b => b.Y == y))
        {
            hashSet.Remove(beacon.X);
        }

        return hashSet.Count;
    }

    public long GetDistressBeaconTuningFrequency(int maximum)
    {
        var map = new Dictionary<int, List<Range>>();
        var newMinimum = 0;
        var newMaximum = 0;

        for (var y = 0; y < maximum; y++)
        {
            map[y] = new List<Range>();

            for (var index = 0; index < Sensors.Count; index++)
            {
                var sensor = Sensors[index];

                if (sensor.GetCoveredPositionsFor(y, out var coveredPositions))
                {
                    newMinimum = coveredPositions.Start;
                    newMaximum = coveredPositions.End;

                    var add = Consolidate(map[y], newMinimum, newMaximum);
                    if (add)
                    {
                        map[y].Add(new Range(newMinimum, newMaximum));
                    }
                }
            }
        }

        var tuningFrequencyCounter = 0;
        var tuningFrequency = 0;
        for (var y = 0; y < maximum; y++)
        {
            var enumerable = Enumerable.Range(0, maximum + 1);
            foreach (var range in map[y])
            {
                try
                {
                    var start = range.Minimum < 0? 0 : range.Minimum;
                    var end = range.Maximum > maximum? maximum : range.Maximum;
                    var linear = Enumerable.Range(start, end - start + 1);
                    enumerable = enumerable.Except(linear);
                }
                catch
                {
                }
            }

            if (enumerable.Count() > 0)
            {
                tuningFrequencyCounter += 1;
                var missing = enumerable.First();
                tuningFrequency = missing * 4000000 + y;
            }
        }

        return tuningFrequency;
    }

    private static bool Consolidate(List<Range> map, int newMinimum, int newMaximum)
    {
        bool add = true;
        foreach (var range in map)
        {
            if (newMinimum < range.Minimum)
            {
                if (newMaximum < range.Minimum) // (1)
                {
                    continue;
                }
                else
                {
                    if (newMaximum <= range.Maximum) // (2)
                    {
                        range.UpdateMinimumTo(newMinimum);
                        add = false;
                        break;
                    }
                    else // (3)
                    {
                        range.UpdateMinimumTo(newMinimum);
                        range.UpdateMaximumTo(newMaximum);
                        add = false;
                        break;
                    }
                }
            }
            else
            {
                if (newMinimum <= range.Maximum)
                {
                    if (newMaximum <= range.Maximum) // (4)
                    {
                        // already included
                        add = false;
                        break;
                    }
                    else // (5)
                    {
                        range.UpdateMaximumTo(newMaximum);
                        add = false;
                        break;
                    }
                }
                else // (6)
                {
                    continue;
                }
            }
        }

        return add;
    }
}