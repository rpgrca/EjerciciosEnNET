using System.Text;

namespace Day17.Logic;

public class InfinitePyroclasticFlow
{
    private readonly string _hotGasStream;
    private int _hotGasStreamIndex;
    private readonly ulong _amountOfRocks;

    private readonly (int X, int Y)[][] _rockCoordinates = new (int X, int Y)[][]
    {
        new[] { (2, 0), (3, 0), (4, 0), (5, 0) },
        new[] { (3, 0), (2, 1), (3, 1), (4, 1), (3, 2) },
        new[] { (4, 0), (4, 1), (2, 2), (3, 2), (4, 2) },
        new[] { (2, 0), (2, 1), (2, 2), (2, 3) },
        new[] { (2, 0), (3, 0), (2, 1), (3, 1) }
    };

    private readonly char[][][] _setupRock = new char[][][]
    {
        new char[][]
        {
            new char[] { '.', '.', '.', '.', '.', '.', '.' }
        },
        new char[][]
        {
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
        },
        new char[][]
        {
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' }
        },
        new char[][]
        {
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' }
        },
        new char[][]
        {
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' }
        }
    };

    private readonly char[][][] _neededEmptySpace = new char[][][]
    {
        new char[][]
        {
            new char[] { '.', '.', '.', '.', '.', '.', '.' }
        },
        new char[][]
        {
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' }
        },
        new char[][]
        {
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '.', '.' }
        }
    };

    private char[][] _chamber;
    private readonly int _currentRock;
    private List<(int X, int Y)> _currentRockPosition;

    public ulong ExpectedLength { get; private set; }

    public InfinitePyroclasticFlow(string input, ulong amountOfRocks)
    {
        _hotGasStream = input;
        _hotGasStreamIndex = 0;
        _chamber = Array.Empty<char[]>();
        _amountOfRocks = amountOfRocks;
        _currentRock = 0;
        _currentRockPosition = new List<(int X, int Y)>();

        var rockNumber = 0UL;
        while (rockNumber < _amountOfRocks)
        {
            SetupCurrentRock();

            do
            {
                ExecuteJetGas();
            } while (MoveDown());

            var blocked = RestRockOnChamber();

            if (blocked)
            {
                var height = GetHeight();
                var newChamber = new char[10][];
                Array.Copy(_chamber, 0, newChamber, 0, 10);
                _chamber = newChamber;
                ExpectedLength += (ulong)(height - GetHeight());
            }

            _currentRock += 1;
            rockNumber += 1;
        }

        ExpectedLength += (ulong)GetHeight();
    }

    private void SetupCurrentRock()
    {
        var rock = Clone(_setupRock[_currentRock % _setupRock.Length]);
        var fallenRockHeight = GetHeight();
        var newChamberHeight = fallenRockHeight + 3 + rock.Length;
        var newChamber = new char[newChamberHeight][];

        Array.Copy(rock, newChamber, rock.Length);

        var emptySpaceToAdd = newChamberHeight - _chamber.Length - rock.Length;
        if (emptySpaceToAdd > 0)
        {
            Array.Copy(_neededEmptySpace[emptySpaceToAdd - 1], 0, newChamber, rock.Length, emptySpaceToAdd);
            Array.Copy(_chamber, 0, newChamber, rock.Length + 3, _chamber.Length);
        }
        else
        {
            Array.Copy(_chamber, -emptySpaceToAdd, newChamber, rock.Length, _chamber.Length + emptySpaceToAdd);
        }

        _chamber = newChamber;
        _currentRockPosition.Clear();
        _currentRockPosition.AddRange(_rockCoordinates[_currentRock % _rockCoordinates.Length]);
    }

    private static char[][] Clone(char[][] rock) =>
        rock.Select(p => p.ToArray()).ToArray();

    private void ExecuteJetGas()
    {
        List<(int X, int Y)> newCoordinates;
        switch (_hotGasStream[_hotGasStreamIndex++ % _hotGasStream.Length])
        {
            case '<':
                newCoordinates = _currentRockPosition.Select(p => (X: p.X - 1, p.Y)).ToList();
                foreach (var (x, y) in newCoordinates)
                {
                    if (x < 0 || _chamber[y][x] == '#')
                    {
                        return;
                    }
                }
                break;

            default:
                newCoordinates = _currentRockPosition.Select(p => (X: p.X + 1, p.Y)).ToList();
                foreach (var (x, y) in newCoordinates)
                {
                    if (x >= _chamber[0].Length || _chamber[y][x] == '#')
                    {
                        return;
                    }
                }
                break;
        }

        _currentRockPosition = newCoordinates;
    }

    private bool MoveDown()
    {
        var canMoveDown = true;

        var newCoordinates = _currentRockPosition.Select(p => (p.X, Y: p.Y + 1)).ToList();
        foreach (var (x, y) in newCoordinates)
        {
            if (y >= _chamber.Length || _chamber[y][x] == '#')
            {
                canMoveDown = false;
                break;
            }
        }

        if (canMoveDown)
        {
            _currentRockPosition = newCoordinates;
        }

        return canMoveDown;
    }

    public int GetHeight()
    {
        var height = 0;

        foreach (var line in _chamber)
        {
            if (line.Contains('#'))
            {
                height++;
            }
        }

        return height;
    }

    private bool RestRockOnChamber()
    {
        foreach (var (x, y) in _currentRockPosition)
        {
            _chamber[y][x] = '#';
        }

        var blocked = PathBlocked();
        _currentRockPosition.Clear();

        return blocked;
    }

    private bool PathBlocked()
    {
        return false;
        var blocked = false;
        foreach (var y in _currentRockPosition.Select(p => p.Y).Distinct())
        {
            blocked = _chamber[y][0] == '#' && _chamber[y][1] == '#' &&
                _chamber[y][2] == '#' && _chamber[y][3] == '#' &&
                _chamber[y][4] == '#' && _chamber[y][5] == '#' &&
                _chamber[y][6] == '#';

            if (blocked)
            {
                break;
            }
        }

        return blocked;
    }
}
