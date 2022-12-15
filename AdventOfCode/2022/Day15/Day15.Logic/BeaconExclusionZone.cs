namespace Day15.Logic;

public class BeaconExclusionZone
{
    private readonly string _input;
    private readonly string[] _lines;
    public (int X, int Y) TopLeft { get; private set; }
    public (int X, int Y) BottomRight { get; private set; }

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
            var sections = line.Split(":");
            var coordinates = sections[0][10..];
            var splitCoordinates = coordinates.Split(",");
            var sensorX = int.Parse(splitCoordinates[0].Split("=")[1]);
            var sensorY = int.Parse(splitCoordinates[1].Split("=")[1]);
            Sensors.Add((sensorX, sensorY));

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
