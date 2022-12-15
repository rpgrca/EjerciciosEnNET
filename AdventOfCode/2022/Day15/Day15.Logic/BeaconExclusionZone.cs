namespace Day15.Logic;

public class BeaconExclusionZone
{
    private readonly string _input;
    private readonly string[] _lines;

    public List<(int X, int Y)> Sensors { get; private set; }
    public List<(int X, int Y)> Beacons { get; private set; }


    public BeaconExclusionZone(string input)
    {
        _input = input;

        Sensors = new List<(int X, int Y)>();
        Beacons = new List<(int X, int Y)>();

        _lines = _input.Split("\n");
        foreach (var line in _lines)
        {
            // Sensor at x=2, y=18: closest beacon is at x=-2, y=15
            var sections = line.Split(":");
            var coordinates = sections[0][10..];
            var splitCoordinates = coordinates.Split(",");
            var sensorX = int.Parse(splitCoordinates[0].Split("=")[1]);
            var sensorY = int.Parse(splitCoordinates[1].Split("=")[1]);
            Sensors.Add((sensorX, sensorY));

            coordinates = sections[1][23..];
            splitCoordinates = coordinates.Split(",");
            var beaconX = int.Parse(splitCoordinates[0].Split("=")[1]);
            var beaconY = int.Parse(splitCoordinates[1].Split("=")[1]);
            Beacons.Add((beaconX, beaconY));
        }
    }
}
