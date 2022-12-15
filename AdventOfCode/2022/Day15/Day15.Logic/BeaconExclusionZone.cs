namespace Day15.Logic;

public class BeaconExclusionZone
{
    private string _input;

    public List<(int X, int Y)> Sensors { get; private set; }
    public List<(int X, int Y)> Beacons { get; private set; }

    public BeaconExclusionZone(string input)
    {
        _input = input;

        Sensors = new List<(int X, int Y)>
        {
            (2, 18)
        };

        Beacons = new List<(int X, int Y)>
        {
            (-2, 15)
        };
    }
}
