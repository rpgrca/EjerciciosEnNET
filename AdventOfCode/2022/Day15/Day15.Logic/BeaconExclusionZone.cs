namespace Day15.Logic;

public class BeaconExclusionZone
{
    private readonly string _input;
    private readonly string[] _lines;

    public List<Sensor> Sensors { get; private set; }
    public List<Beacon> Beacons { get; private set; }

    public BeaconExclusionZone(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        Sensors = new List<Sensor>();
        Beacons = new List<Beacon>();

        Parse();
    }

    private void Parse()
    {
        foreach (var line in _lines)
        {
            var sections = line.Split(":");
            var coordinates = sections[0][10..];

            var splitCoordinates = coordinates.Split(",");
            coordinates = sections[1][23..];

            var beacon = new Beacon(coordinates);
            AddBeaconIfUnique(beacon);
            AddSensor(splitCoordinates, beacon);
        }
    }

    private void AddBeaconIfUnique(Beacon beacon)
    {
        if (! Beacons.Contains(beacon))
        {
            Beacons.Add(beacon);
        }
    }

    private void AddSensor(string[] splitCoordinates, Beacon beacon)
    {
        var sensorX = int.Parse(splitCoordinates[0].Split("=")[1]);
        var sensorY = int.Parse(splitCoordinates[1].Split("=")[1]);
        Sensors.Add(new(sensorX, sensorY, beacon));
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

    public ulong GetDistressBeaconTuningFrequency(int maximum)
    {
        var map = new List<Range>[maximum];
        for (var y = 0; y < maximum; y++)
        {
            map[y] = new List<Range>();
            for (var index = 0; index < Sensors.Count; index++)
            {
                var sensor = Sensors[index];

                if (sensor.GetCoveredPositionsFor(y, out var coveredPositions))
                {
                    var newMinimum = coveredPositions.Start;
                    var newMaximum = coveredPositions.End;

                    var add = MapConsolidation.Consolidate(map[y], newMinimum, newMaximum);
                    if (add)
                    {
                        map[y].Add(new Range(newMinimum, newMaximum));
                    }
                }
            }
        }

        var tuningFrequency = 0UL;
        for (var y = 0; y < maximum; y++)
        {
            var result = MapConsolidation.Consolidate(map[y]);
            if (! result)
            {
                var enumerable = Enumerable.Range(0, maximum + 1);
                foreach (var range in map[y])
                {
                    var start = range.Minimum < 0? 0 : range.Minimum;
                    var end = range.Maximum > maximum? maximum : range.Maximum;
                    var linear = Enumerable.Range(start, end - start + 1);
                    enumerable = enumerable.Except(linear);
                }

                var missing = (ulong)enumerable.Single();
                tuningFrequency = missing * 4000000UL + (ulong)y;
                break;
            }
        }

        return tuningFrequency;
    }
}