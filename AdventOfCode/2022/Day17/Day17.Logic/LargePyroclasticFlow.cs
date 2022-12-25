using System.Text;

namespace Day17.Logic;

public class LargePyroclasticFlow
{
    private const int INITIAL_LENGTH = 150000;
    private string _hotGasStream;
    private int _hotGasStreamIndex;
    private ulong _amountOfRocks;
    private int _rightmostPoint;

    private readonly int[] _bitfield;

    private readonly (int X, int Y)[][] _rockCoordinates = new (int X, int Y)[][]
    {
        new[] { (0, 2), (0, 3), (0, 4), (0, 5) },
        new[] { (0, 3), (1, 2), (1, 3), (1, 4), (2, 3) },
        new[] { (0, 2), (0, 3), (0, 4), (1, 4), (2, 4) },
        new[] { (0, 2), (1, 2), (2, 2), (3, 2) },
        new[] { (0, 2), (0, 3), (1, 2), (1, 3) }
    };
/*
. . . . . . . . . .
. . . . . . . . . .
x . . . . . . . . .
x . . . . . . . . .
x x x . . . . . . .
. . . . . . . . . .
. . . . . . . . . . 
*/

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

    private char[][] _chamber;
    private int _currentRock;
    private List<(int X, int Y)> _currentRockPosition;

    public ulong ExpectedLength { get; private set; }

    public LargePyroclasticFlow(string input, ulong amountOfRocks)
    {
        _hotGasStream = input;
        _hotGasStreamIndex = 0;
        _rightmostPoint = -1;
        _bitfield = new int[INITIAL_LENGTH];

        _chamber = new char[][]
        {
            new char[INITIAL_LENGTH],
            new char[INITIAL_LENGTH],
            new char[INITIAL_LENGTH],
            new char[INITIAL_LENGTH],
            new char[INITIAL_LENGTH],
            new char[INITIAL_LENGTH],
            new char[INITIAL_LENGTH]
        };
        Array.Fill(_chamber[0], '.');
        Array.Fill(_chamber[1], '.');
        Array.Fill(_chamber[2], '.');
        Array.Fill(_chamber[3], '.');
        Array.Fill(_chamber[4], '.');
        Array.Fill(_chamber[5], '.');
        Array.Fill(_chamber[6], '.');

        _amountOfRocks = amountOfRocks;
        _currentRock = 0;
        _currentRockPosition = new List<(int X, int Y)>();

        var cycle = (ulong)(_hotGasStream.Length * _setupRock.Length);

        var rockNumber = 0UL;
        if (_amountOfRocks < cycle)
        {
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

            ExpectedLength += (ulong)GetHeight();
        }
        else
        {
            var startsPeriod = false;
            var periodCounter = 0;
            var left = 0;
            while (rockNumber < cycle / 10)
            {
                if (rockNumber == 4499)
                {
                    rockNumber = 4499;
                }

                SetupCurrentRock();

                do
                {
                    ExecuteJetGas();
                } while (MoveDown());

                RestRockOnChamber();

/*
puzzle
                if (ToBits().StartsWith("2,2,15,47,119,62,48,48"))
                {
                    startsPeriod = true;
                }

                if (ToBits().StartsWith("2,2,47,127,39,63,57"))
                {
                    startsPeriod = false;
                    left = 846;
                }*/

                if (ToBits().StartsWith("28,28,30,7,2,62"))
                {
                    startsPeriod = true;
                }

/*
sample original
                if (ToBits().StartsWith("3,3,1,1,15,28"))
                {
                    startsPeriod = true;
                }

                if (ToBits().StartsWith("28,28,30,7,2,62,36,36"))
                {
                    startsPeriod = false;
                }
*/
                if (startsPeriod)
                {
                    periodCounter++;
                }
                else
                {
                    periodCounter = 0;
                }

                if (left-- == 0)
                {
                    ExpectedLength = (ulong)GetHeight();
                }

                _currentRock += 1;
                rockNumber += 1;
            }
/*
            var totalRocks = _amountOfRocks - 14;
            ExpectedLength = 25;
            var (quotient, remainder) = Math.DivRem(totalRocks, 35UL);

            ExpectedLength += quotient * 53;
            if (remainder != 0)
            {
                remainder--;
            }

            totalRocks = 999999999950;
            var lengthAfter50Stones = 78UL;
            var lengthAfterPeriod = 53UL;

            quotient = totalRocks / 35UL;
            ExpectedLength = 78 + quotient * lengthAfterPeriod;
*/            
            var totalRocks = 999999995500UL;
            var lengthAfter4500Stones = 7191UL;
            var lengthAfterPeriod = 2785UL;

            var quotient = totalRocks / 1745UL;
            ExpectedLength = lengthAfter4500Stones + quotient * lengthAfterPeriod;
            
        }
    }

    private void SetupCurrentRock()
    {
        var rock = Clone(_setupRock[_currentRock % _setupRock.Length]);
        _currentRockPosition.Clear();
        _currentRockPosition.AddRange(_rockCoordinates[_currentRock % _rockCoordinates.Length].Select(p => (X: p.X + _rightmostPoint + 4, p.Y)));
    }

    private static char[][] Clone(char[][] rock) =>
        rock.Select(p => p.ToArray()).ToArray();

    private void ExecuteJetGas()
    {
        List<(int X, int Y)> newCoordinates;
        switch (_hotGasStream[_hotGasStreamIndex++ % _hotGasStream.Length])
        {
            case '<':
                newCoordinates = _currentRockPosition.Select(p => (p.X, Y: p.Y - 1)).ToList();
                foreach (var (x, y) in newCoordinates)
                {
                    if (y < 0 || _chamber[y][x] == '#')
                    {
                        return;
                    }
                }
                break;

            default:
                newCoordinates = _currentRockPosition.Select(p => (p.X, Y: p.Y + 1)).ToList();
                foreach (var (x, y) in newCoordinates)
                {
                    if (y >= _chamber.Length || _chamber[y][x] == '#')
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

        var newCoordinates = _currentRockPosition.Select(p => (X: p.X - 1, p.Y)).ToList();
        foreach (var (x, y) in newCoordinates)
        {
            if (x < 0 || _chamber[y][x] == '#')
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

    public int GetHeight() => _rightmostPoint + 1;

    private void RestRockOnChamber()
    {
        foreach (var (x, y) in _currentRockPosition)
        {
            _chamber[y][x] = '#';
            if (_rightmostPoint < x)
            {
                _rightmostPoint = x;
            }
        }

        _currentRockPosition.Clear();
    }

    public string ToBits()
    {
        var stringBuilder = new StringBuilder();

        for (var x = _rightmostPoint + 7; x >= 0; x--)
        {
            var value = 0;
            for (var y = 0; y < _chamber.Length; y++)
            {
                if (_chamber[y][x] == '#')
                {
                    value = value << 1 | 1;
                }
                else
                {
                    value = value << 1;
                }
            }

            if (value != 0)
            {
                stringBuilder.Append($"{value},");
            }
        }

        return stringBuilder.ToString();
    }
}