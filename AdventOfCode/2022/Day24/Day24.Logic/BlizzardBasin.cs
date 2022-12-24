namespace Day24.Logic;

public class BlizzardBasin
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Height { get; }
    public int Width { get; }
    public (int X, int Y) Entrance { get; }
    public (int X, int Y) Exit { get; }

    public BlizzardBasin(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        Height = _lines.Length;
        Width = _lines[0].Length;

        // TODO: Calculate based on input
        Entrance = (1, 0);
        Exit = (Width - 2, Height - 1);


    }

}
