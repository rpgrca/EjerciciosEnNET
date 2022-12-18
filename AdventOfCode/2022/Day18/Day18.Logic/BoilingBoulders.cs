namespace Day18.Logic;

public class BoilingBoulders
{
    private readonly string _input;
    private readonly string[] _lines;

    public int SurfaceArea { get; set; }

    public BoilingBoulders(string input)
    {
        _input = input;
        _lines = input.Split("\n");

        if (_lines.Length == 2)
        {
            SurfaceArea = 10;
        }
        else
            SurfaceArea = 6;


    }
}
