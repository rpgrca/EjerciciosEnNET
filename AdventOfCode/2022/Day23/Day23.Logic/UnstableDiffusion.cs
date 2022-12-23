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
    private string _input;
    private string[] _lines;
    private char[][] _map;

    public int Height { get; set; }
    public int Width { get; set; }
    public List<(int X, int Y)> Elves { get; private set; }

    public UnstableDiffusion(string input, int overflow = 0)
    {
        _input = input;
        _lines = _input.Split("\n");

        if (overflow == 0)
        {
            _map = _input.Split("\n").Select(p => p.ToArray()).ToArray();
        }
        else
        {
            var emptyLine = string.Concat(Enumerable.Repeat('.', _lines[0].Length + overflow * 2));
            var newInput = string.Join("\n", Enumerable.Range(0, overflow).Select(p => emptyLine)) + "\n" +
                   string.Join("\n", _input.Split("\n")
                    .Select(p => $"{new string('.', overflow)}{p}{new string('.', overflow)}")) + "\n" +
                   string.Join("\n", Enumerable.Range(0, overflow).Select(p => emptyLine));

            _map = newInput.Split("\n").Select(p => p.ToArray()).ToArray();
        }

        _currentDirection = Direction.North;
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
        foreach (var elf in Elves)
        {
            if (Alone(elf))
            {
                continue;
            }

            switch (_currentDirection)
            {
                case Direction.North:
                    _ = ProposeNorth(elf, proposedMoves) || ProposeSouth(elf, proposedMoves) || ProposeWest(elf, proposedMoves) || ProposeEast(elf, proposedMoves);
                    break;

                case Direction.South:
                    _ = ProposeSouth(elf, proposedMoves) || ProposeWest(elf, proposedMoves) || ProposeEast(elf, proposedMoves) || ProposeNorth(elf, proposedMoves);
                    break;

                case Direction.West:
                    _ = ProposeWest(elf, proposedMoves) || ProposeEast(elf, proposedMoves) || ProposeNorth(elf, proposedMoves) || ProposeSouth(elf, proposedMoves);
                    break;

                case Direction.East:
                    _ = ProposeEast(elf, proposedMoves) || ProposeNorth(elf, proposedMoves) || ProposeSouth(elf, proposedMoves) || ProposeWest(elf, proposedMoves);
                    break;
            }
        }

        _currentDirection = (Direction)(((int)_currentDirection + 1) % 4);
        foreach (var proposedMove in proposedMoves.GroupBy(p => p.Value).Where(p => p.Count() == 1))
        {
            var proposal = proposedMove.Single();
            _map[proposal.Key.Y][proposal.Key.X] = '.';
            _map[proposal.Value.Y][proposal.Value.X] = '#';

            Elves.Remove((proposal.Key.X, proposal.Key.Y));
            Elves.Add((proposal.Value.X, proposal.Value.Y));
        }

    }

    private bool ProposeNorth((int X, int Y) elf, Dictionary<(int X, int Y), (int X, int Y)> proposedMoves)
    {
        int proposedY = elf.Y - 1;

        if (proposedY < 0)
        {
            return false;
        }

        if (GetMapAt(elf.X - 1, proposedY) == '.' && GetMapAt(elf.X, proposedY) == '.' && GetMapAt(elf.X + 1, proposedY) == '.')
        {
            proposedMoves.Add(elf, (elf.X, proposedY));
            return true;
        }

        return false;
    }

    private bool ProposeSouth((int X, int Y) elf, Dictionary<(int X, int Y), (int X, int Y)> proposedMoves)
    {
        int proposedY = elf.Y + 1;

        if (proposedY >= Height)
        {
            return false;
        }

        if (GetMapAt(elf.X - 1, proposedY) == '.' && GetMapAt(elf.X, proposedY) == '.' && GetMapAt(elf.X + 1, proposedY) == '.')
        {
            proposedMoves.Add(elf, (elf.X, proposedY));
            return true;
        }

        return false;
    }

    private bool ProposeWest((int X, int Y) elf, Dictionary<(int X, int Y), (int X, int Y)> proposedMoves)
    {
        int proposedX = elf.X - 1;

        if (proposedX < 0)
        {
            return false;
        }

        if (GetMapAt(proposedX, elf.Y - 1) == '.' && GetMapAt(proposedX, elf.Y) == '.' && GetMapAt(proposedX, elf.Y + 1) == '.')
        {
            proposedMoves.Add(elf, (proposedX, elf.Y));
            return true;
        }

        return false;
    }

    private bool ProposeEast((int X, int Y) elf, Dictionary<(int X, int Y), (int X, int Y)> proposedMoves)
    {
        int proposedX = elf.X + 1;

        if (proposedX >= Width)
        {
            return false;
        }

        if (GetMapAt(proposedX, elf.Y - 1) == '.' && GetMapAt(proposedX, elf.Y) == '.' && GetMapAt(proposedX, elf.Y + 1) == '.')
        {
            proposedMoves.Add(elf, (proposedX, elf.Y));
            return true;
        }

        return false;
    }


    private bool Alone((int X, int Y) elf) =>
        GetMapAt(elf.X - 1, elf.Y - 1) == '.' && GetMapAt(elf.X, elf.Y - 1) == '.' && GetMapAt(elf.X + 1, elf.Y - 1) == '.' &&
        GetMapAt(elf.X - 1, elf.Y) == '.' && GetMapAt(elf.X + 1, elf.Y) == '.' &&
        GetMapAt(elf.X - 1, elf.Y + 1) == '.' && GetMapAt(elf.X, elf.Y + 1) == '.' && GetMapAt(elf.X + 1, elf.Y + 1) == '.';

    private char GetMapAt(int x, int y) => x >= 0 && x < Width && y >= 0 && y < Height ? _map[y][x] : '.';

    public string GetImage()
    {
        var stringBuilder = new System.Text.StringBuilder();
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                stringBuilder.Append(_map[y][x]);
            }

            stringBuilder.Append('\n');
        }

        return stringBuilder.ToString().Trim();
    }
}
