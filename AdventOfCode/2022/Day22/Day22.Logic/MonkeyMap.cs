namespace Day22.Logic;

public class MonkeyMap
{
    private string _input;
    private string[] _lines;
    private char[,] _map;

    public int Height { get; set; }
    public int Width { get; set; }
    public List<(char Command, int Amount)> Steps { get; set; }

    public MonkeyMap(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        foreach (var line in _lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            if (line.Length > Width)
            {
                Width = line.Length;
            }

            Height++;
        }

        _map = new char[Height,Width];
        int x, y;
        for (y = 0; y < Height; y++)
        {
            for (x = 0; x < Width; x++)
            {
                _map[y,x] = ' ';
            }
        }

        y = 0;
        foreach (var line in _lines)
        {
            x = 0;
            foreach (var character in line)
            {
                _map[y,x++] = character;
            }
        }

        Steps = new List<(char Command, int Amount)>();

        var accumulatedNumber = string.Empty;
        foreach (var character in _lines[Height + 1])
        {
            if (character == 'R' || character == 'L')
            {
                if (! string.IsNullOrEmpty(accumulatedNumber))
                {
                    Steps.Add(('F', int.Parse(accumulatedNumber)));
                    accumulatedNumber = string.Empty;
                }

                Steps.Add((character, 90));
            }
            else
            {
                accumulatedNumber += character;
            }
        }

        if (! string.IsNullOrEmpty(accumulatedNumber))
        {
            Steps.Add(('F', int.Parse(accumulatedNumber)));
        }
    }
}
