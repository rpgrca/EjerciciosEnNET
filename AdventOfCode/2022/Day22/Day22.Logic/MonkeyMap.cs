namespace Day22.Logic;

public class MonkeyMap
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly int _heightWithWrap;
    private readonly int _widthWithWrap;
    private readonly char[,] _map;
    private Pointer _pointer;

    public int StartingPointX { get; private set; }
    public int StartingPointY { get; private set; }

    public int Height { get; private set; }
    public int Width { get; private set; }
    public List<(char Command, int Amount)> Steps { get; set; }
    public long FinalPassword => _pointer.Decode();

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

        _heightWithWrap = Height + 2;
        _widthWithWrap = Width + 2;
        _map = new char[_heightWithWrap, _widthWithWrap];

        int x, y;
        for (y = 0; y < _heightWithWrap; y++)
        {
            for (x = 0; x < _widthWithWrap; x++)
            {
                _map[y,x] = ' ';
            }
        }

        var originSet = false;
        for (y = 1; y <= Height; y++)
        {
            x = 1;
            foreach (var character in _lines[y - 1])
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

        _pointer = new Pointer(_map, StartingPointX, StartingPointY);
    }

    public void Run()
    {
        foreach (var command in Steps)
        {
            _pointer.Move(command);
        }
    }
}


public class MonkeyMap3d
{
    private readonly string _input;
    private readonly int _maximumSize;
    private readonly string[] _lines;
    private readonly int _heightWithWrap;
    private readonly int _widthWithWrap;
    private readonly char[,] _map;
    private Pointer _pointer;

    public int StartingPointX { get; private set; }
    public int StartingPointY { get; private set; }

    public int Height { get; private set; }
    public int Width { get; private set; }
    public List<(char Command, int Amount)> Steps { get; set; }
    public long FinalPassword => _pointer.Decode();

    public MonkeyMap3d(string input, string[][] planes, (int, Direction, Func<int, int, int, int, (int, int)>)[][] transitions, (int TopX, int TopY)[] origins, int maximumSize, int startingPlane)
    {
        _input = input;
        _maximumSize = maximumSize;
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

        _heightWithWrap = Height + 2;
        _widthWithWrap = Width + 2;
        _map = new char[_heightWithWrap, _widthWithWrap];

        int x, y;
        for (y = 0; y < _heightWithWrap; y++)
        {
            for (x = 0; x < _widthWithWrap; x++)
            {
                _map[y,x] = ' ';
            }
        }

        var originSet = false;
        for (y = 1; y <= Height; y++)
        {
            x = 1;
            foreach (var character in _lines[y - 1])
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

        _pointer = new Pointer3d(_map, planes, transitions, origins, StartingPointX, StartingPointY, startingPlane, maximumSize, maximumSize);
    }

    public void Run()
    {
        foreach (var command in Steps)
        {
            _pointer.Move(command);
        }
    }
}
