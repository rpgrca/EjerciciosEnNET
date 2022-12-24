namespace Day24.Logic;

public class BlizzardBasin
{
    private string _input;

    public int Height { get; } = 7;
    public int Width { get; } = 7;
    public (int X, int Y) Entrance { get; } = (1, 0);
    public (int X, int Y) Exit { get; } = (5, 6);

    public BlizzardBasin(string input)
    {
        _input = input;
    }

}
