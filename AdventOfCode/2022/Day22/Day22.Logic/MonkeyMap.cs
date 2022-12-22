namespace Day22.Logic;

public class MonkeyMap
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[,] _map;
    private Pointer _pointer;

    public int StartingPointX { get; private set; }
    public int StartingPointY { get; private set; }

    public int Height { get; private set; }
    public int Width { get; private set; }
    public List<(char Command, int Amount)> Steps { get; set; }
    public int FinalPassword => _pointer.Decode();

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

        var originSet = false;
        y = 0;
        for (y = 0; y < Height; y++)
        {
            x = 0;
            foreach (var character in _lines[y])
            {
                _map[y,x] = character;
                if (! originSet && character == '.')
                {
                    originSet = true;
                    StartingPointX = x;
                    StartingPointY = y;
                }

                x++;
            }

            y++;
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

    public void Run()
    {
        _pointer = new Pointer(_map, StartingPointX, StartingPointY);
        foreach (var command in Steps)
        {
            _pointer.Move(command);
        }
    }
}
