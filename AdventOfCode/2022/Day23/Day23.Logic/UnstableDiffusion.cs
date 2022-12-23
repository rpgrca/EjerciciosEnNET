namespace Day23.Logic;
public class UnstableDifusion
{
    private string _input;
    private char[][] _map;

    public int Height { get; set; }
    public int Width { get; set; }
    public List<(int X, int Y)> Elves { get; private set; }

    public UnstableDifusion(string input)
    {
        _input = input;
        _map = _input.Split("\n").Select(p => p.ToArray()).ToArray();
        Height = _map.Length;
        Width = _map[0].Length;

        Elves = new List<(int X, int Y)>();

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (_map[y][x] == '#')
                {
                    Elves.Add((x, y));
                }
            }
        }
    }


    public int CalculateEmptyGround()
    {
        var topMost = Elves.Min(p => p.Y);
        var bottomMost = Elves.Max(p => p.Y);
        var leftMost = Elves.Min(p => p.X);
        var rightMost = Elves.Max(p => p.X);
        var counter = 0;

        for (var y = topMost; y <= bottomMost; y++)
        {
            for (var x = leftMost; x <= rightMost; x++)
            {
                if (_map[y][x] == '.')
                {
                    counter++;
                }
            }
        }

        return counter;
    }
}
