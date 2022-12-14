namespace Day14.Logic;

public class SandFallingSimulator
{
    private string _input;
    private char[][] _map;
    private readonly int _minimumX;
    private readonly int _maximumX;
    private readonly int _minimumY;
    private readonly int _maximumY;

    public bool MapFilled { get; private set; }
    public int UnitsOfSand { get; private set; }

    public SandFallingSimulator(string input, bool infiniteFloor = false)
    {
        _input = input;

        var lines = input.Split("\n");
        var points = new List<(int X, int Y)>();

        foreach (var line in lines)
        {
            var segments = line.Split(" -> ");

            for (var index = 0; index < segments.Length - 1; index++)
            {
                var coordinates = segments[index].Split(",");
                var startingPoint = (int.Parse(coordinates[0]), int.Parse(coordinates[1]));

                coordinates = segments[index + 1].Split(",");
                var endingPoint = (int.Parse(coordinates[0]), int.Parse(coordinates[1]));

                if (startingPoint.Item1 < endingPoint.Item1) // left to right
                {
                    for (var subIndex = startingPoint.Item1; subIndex <= endingPoint.Item1; subIndex++)
                    {
                        points.Add((subIndex, startingPoint.Item2));
                    }
                }
                else if (startingPoint.Item1 > endingPoint.Item1) // right to let
                {
                    for (var subIndex = endingPoint.Item1; subIndex <= startingPoint.Item1; subIndex++)
                    {
                        points.Add((subIndex, startingPoint.Item2));
                    }
                }

                if (startingPoint.Item2 < endingPoint.Item2) // top to bottom
                {
                    for (var subIndex = startingPoint.Item2; subIndex <= endingPoint.Item2; subIndex++)
                    {
                        points.Add((startingPoint.Item1, subIndex));
                    }
                }
                else if (startingPoint.Item2 > endingPoint.Item2) // bottom to top
                {
                    for (var subIndex = endingPoint.Item2; subIndex <= startingPoint.Item2; subIndex++)
                    {
                        points.Add((startingPoint.Item1, subIndex));
                    }
                }
            }
        }

        _minimumX = points.Min(p => p.X);
        _maximumX = points.Max(p => p.X);
        _minimumY = 0;
        _maximumY = points.Max(p => p.Y);

        if (infiniteFloor)
        {
            var diff = _maximumX - _minimumX + 1;
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
        var map = string.Empty;

        for (var y = _minimumY; y <= _maximumY; y++)
        {
            for (var x = 0; x <= _maximumX - _minimumX; x++)
            {
                map += _map[y][x];
            }

            map += "\n";
        }

        return map.Trim();
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

    public void DropUnitOfSandsUntilFilled()
    {
        while (! MapFilled)
        {
            DropUnitOfSand();
        }
    }
}
