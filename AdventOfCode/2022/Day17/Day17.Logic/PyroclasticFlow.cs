using System.Text;

namespace Day17.Logic;

public class PyroclasticFlow
{
    private readonly string _hotGasStream;
    private int _hotGasStreamIndex;
    private readonly int _amountOfRocks;
    private readonly int _width;

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

    public PyroclasticFlow(string input, int amountOfRocks)
    {
        _hotGasStream = input;
        _hotGasStreamIndex = 0;
        _width = 7;
        _chamber = Array.Empty<char[]>();
        _amountOfRocks = amountOfRocks;
        _currentRock = 0;
        _currentRockPosition = new List<(int X, int Y)>();

        var rockNumber = 0;
        while (rockNumber < _amountOfRocks)
        {
            SetupCurrentRock();

            do
            {
                ExecuteJetGas();
            } while (MoveDown());

            RestRockOnChamber();

            _currentRock += 1;
            rockNumber += 1;
        }
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

    private static char[][] Clone(char[][] rock) => rock.Select(p => p.ToArray()).ToArray();

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

    private void RestRockOnChamber()
    {
        foreach (var (x, y) in _currentRockPosition)
        {
            _chamber[y][x] = '#';
        }

        _currentRockPosition.Clear();
    }

    public string GetChamber()
    {
        var stringBuilder = new StringBuilder();

        foreach (var line in _chamber)
        {
            if (line.Contains('#'))
            {
                stringBuilder.Append('|');
                stringBuilder.Append(line);
                stringBuilder.Append("|\n");
            }
        }

        stringBuilder.Append("+-------+");
        return stringBuilder.ToString();
    }
}
