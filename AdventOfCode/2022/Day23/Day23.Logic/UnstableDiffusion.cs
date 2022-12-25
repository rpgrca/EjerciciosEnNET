namespace Day23.Logic;

public class UnstableDiffusion
{
    private enum Direction
    {
        North,
        South,
        West,
        East
    }

    private Direction _currentDirection;
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[][] _map;
    private int _lastRoundMovements;

    public int Height { get; set; }
    public int Width { get; set; }
    public List<(int X, int Y)> Elves { get; private set; }

    public UnstableDiffusion(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _map = _input.Split("\n").Select(p => p.ToArray()).ToArray();
        _currentDirection = Direction.North;

        Height = _map.Length;
        Width = _map[0].Length;
        Elves = new List<(int X, int Y)>();

        ExtractElvesFromMap();
    }

    public UnstableDiffusion(string input, int overflow)
    {
        _input = input;
        _lines = _input.Split("\n");

        var emptyLine = string.Concat(Enumerable.Repeat('.', _lines[0].Length + overflow * 2));
        var newInput = string.Join("\n", Enumerable.Range(0, overflow).Select(p => emptyLine)) + "\n" +
                string.Join("\n", _input.Split("\n")
                .Select(p => $"{new string('.', overflow)}{p}{new string('.', overflow)}")) + "\n" +
                string.Join("\n", Enumerable.Range(0, overflow).Select(p => emptyLine));

        _map = newInput.Split("\n").Select(p => p.ToArray()).ToArray();

        _currentDirection = Direction.North;
        Height = _map.Length;
        Width = _map[0].Length;
        Elves = new List<(int X, int Y)>();

        ExtractElvesFromMap();
    }

    private void ExtractElvesFromMap()
    {
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

    public int CalculateEmptyGroundBetweenElves()
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

    public void Round(int amount)
    {
        while (amount-- > 0)
        {
            DoOneRound();
        }
    }

    private void DoOneRound()
    {
        var proposedMoves = new Dictionary<(int X, int Y), (int X, int Y)>();
        Func<(int X, int Y), Dictionary<(int X, int Y), (int X, int Y)>, bool>[] proposed =
        {
            ProposeNorth,
            ProposeSouth,
            ProposeWest,
            ProposeEast
        };

        foreach (var elf in Elves.Where(e => !IsAlone(e)))
        {
            _ = proposed[(int)_currentDirection](elf, proposedMoves) ||
                proposed[(int)(_currentDirection + 1) % 4](elf, proposedMoves) ||
                proposed[(int)(_currentDirection + 2) % 4](elf, proposedMoves) ||
                proposed[(int)(_currentDirection + 3) % 4](elf, proposedMoves);
        }

        _currentDirection = GetNextDirection();
        _lastRoundMovements = 0;
        foreach (var proposedMove in proposedMoves.GroupBy(p => p.Value).Where(p => p.Count() == 1))
        {
            var proposal = proposedMove.Single();
            _map[proposal.Key.Y][proposal.Key.X] = '.';
            _map[proposal.Value.Y][proposal.Value.X] = '#';

            Elves.Remove((proposal.Key.X, proposal.Key.Y));
            Elves.Add((proposal.Value.X, proposal.Value.Y));

            _lastRoundMovements++;
        }
    }

    private Direction GetNextDirection() =>
        (Direction)(((int)_currentDirection + 1) % 4);

    private bool ProposeNorth((int X, int Y) elf, Dictionary<(int X, int Y), (int X, int Y)> proposedMoves) =>
        ProposeVertical(proposedMoves, elf, -1);

    private bool ProposeSouth((int X, int Y) elf, Dictionary<(int X, int Y), (int X, int Y)> proposedMoves) =>
        ProposeVertical(proposedMoves, elf, 1);

    private bool ProposeWest((int X, int Y) elf, Dictionary<(int X, int Y), (int X, int Y)> proposedMoves) =>
        ProposeHorizontal(proposedMoves, elf, -1);

    private bool ProposeEast((int X, int Y) elf, Dictionary<(int X, int Y), (int X, int Y)> proposedMoves) =>
        ProposeHorizontal(proposedMoves, elf, 1);

    private bool ProposeVertical(Dictionary<(int X, int Y), (int X, int Y)> proposedMoves, (int X, int Y) elf, int offset)
    {
        int proposedY = elf.Y + offset;

        if (GetMapAt(elf.X - 1, proposedY) == '.' && GetMapAt(elf.X, proposedY) == '.' && GetMapAt(elf.X + 1, proposedY) == '.')
        {
            proposedMoves.Add(elf, (elf.X, proposedY));
            return true;
        }

        return false;
    }

    private bool ProposeHorizontal(Dictionary<(int X, int Y), (int X, int Y)> proposedMoves, (int X, int Y) elf, int offset)
    {
        var proposedX = elf.X + offset;
        if (GetMapAt(proposedX, elf.Y - 1) == '.' && GetMapAt(proposedX, elf.Y) == '.' && GetMapAt(proposedX, elf.Y + 1) == '.')
        {
            proposedMoves.Add(elf, (proposedX, elf.Y));
            return true;
        }

        return false;
    }

    private bool IsAlone((int X, int Y) elf) =>
        GetMapAt(elf.X - 1, elf.Y - 1) == '.' && GetMapAt(elf.X, elf.Y - 1) == '.' && GetMapAt(elf.X + 1, elf.Y - 1) == '.' &&
        GetMapAt(elf.X - 1, elf.Y) == '.' && GetMapAt(elf.X + 1, elf.Y) == '.' &&
        GetMapAt(elf.X - 1, elf.Y + 1) == '.' && GetMapAt(elf.X, elf.Y + 1) == '.' && GetMapAt(elf.X + 1, elf.Y + 1) == '.';

    private char GetMapAt(int x, int y) =>
        x >= 0 && x < Width && y >= 0 && y < Height ? _map[y][x] : '.';

    public string GetImage() =>
        string.Join('\n', _map.Select(p => string.Join("", p)));

    public int RoundUntilQuiet()
    {
        var rounds = 0;
        do
        {
            Round(1);
            rounds++;
        } while (_lastRoundMovements > 0);

        return rounds;
    }
}
