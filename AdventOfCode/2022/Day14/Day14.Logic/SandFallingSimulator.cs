using System.Text;

namespace Day14.Logic;

public class SandFallingSimulator
{
    private readonly char[][] _map;
    private readonly int _minimumX;
    private readonly int _maximumX;
    private readonly int _minimumY;
    private readonly int _maximumY;

    public bool MapFilled { get; private set; }
    public int UnitsOfSand { get; private set; }

    public SandFallingSimulator(string input, bool infiniteFloor = false)
    {
        var rockLoader = new RockLoader(input);
        var points = rockLoader.Points;

        _minimumX = points.Min(p => p.X);
        _maximumX = points.Max(p => p.X);
        _minimumY = 0;
        _maximumY = points.Max(p => p.Y);

        if (infiniteFloor)
        {
            var diff = _maximumY - _minimumY + 1;
            _minimumX -= diff;
            _maximumX += diff;
            _maximumY += 2;

            for (var index = _minimumX; index <= _maximumX; index++)
            {
                points.Add((index, _maximumY));
            }
        }

        _map = new char[_maximumY + 1][];
        for (var index = 0; index <= _maximumY - _minimumY; index++)
        {
            _map[index] = new char[_maximumX - _minimumX + 1];
        }

        for (var y = _minimumY; y <= _maximumY; y++)
        {
            for (var x = 0; x <= _maximumX - _minimumX; x++)
            {
                _map[y][x] = '.';
            }
        }

        foreach (var point in points)
        {
            _map[point.Y - _minimumY][point.X - _minimumX] = '#';
        }
    }

    public string GetVisualMap()
    {
        var stringBuilder = new StringBuilder();

        foreach (var line in _map)
        {
            stringBuilder.Append(line);
            stringBuilder.Append('\n');
        }

        return stringBuilder.ToString().Trim();
    }

    public void DropUnitOfSands(int unitsOfSand)
    {
        while (unitsOfSand > 0)
        {
            DropUnitOfSand();
            unitsOfSand--;
        }
    }

    private void DropUnitOfSand()
    {
        int positionX = 500 - _minimumX;
        int positionY = 0 - _minimumY;
        bool moved;

        do
        {
            moved = false;
            if (positionY + 1 <= _maximumY)
            {
                if (_map[positionY + 1][positionX] == '.')
                {
                    positionY += 1;
                    moved = true;
                }
            }
            else
            {
                MapFilled = true;
                break;
            }

            if (!moved)
            {
                if (positionX - 1 >= 0)
                {
                    if (_map[positionY + 1][positionX - 1] == '.')
                    {
                        positionY += 1;
                        positionX -= 1;
                        moved = true;
                    }
                }
                else
                {
                    MapFilled = true;
                    break;
                }
            }

            if (!moved)
            {
                if (positionX + 1 <= _maximumX - _minimumX)
                {
                    if (_map[positionY + 1][positionX + 1] == '.')
                    {
                        positionY += 1;
                        positionX += 1;
                        moved = true;
                    }
                }
                else
                {
                    MapFilled = true;
                    break;
                }
            }

            if (! moved)
            {
                _map[positionY][positionX] = 'o';
                UnitsOfSand++;
            }
        } while (moved);
    }

    public void DropSandUntilFilled()
    {
        while (! MapFilled)
        {
            DropUnitOfSand();
        }
    }

    public void DropSandUntilEntranceIsBlocked()
    {
        while (! IsEntranceBlocked())
        {
            DropUnitOfSand();
        }
    }

    private bool IsEntranceBlocked() =>
        _map[0][500 - _minimumX] == 'o';
}