namespace Day15.Logic;

public struct Beacon
{
    public int X { get; }
    public int Y { get; }

    public Beacon(string coordinates)
    {
        var splitCoordinates = coordinates.Split(",");

        X = int.Parse(splitCoordinates[0].Split("=")[1]);
        Y = int.Parse(splitCoordinates[1].Split("=")[1]);
    }

    public Beacon(int x, int y)
    {
        X = x;
        Y = y;
    }
}