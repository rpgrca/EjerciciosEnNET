namespace Day18.Logic;

public class BoilingBoulders
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<(int X, int Y, int Z)> _cubes;

    public int SurfaceArea { get; set; }

    public BoilingBoulders(string input, bool withAirPockets = true)
    {
        _input = input;
        _lines = input.Split("\n");
        _cubes = new List<(int X, int Y, int Z)>();

        foreach (var line in _lines)
        {
            var coordinates = line.Split(",");
            _cubes.Add((int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2])));
        }

        _cubes.Sort();

        TraceAway();
        if (! withAirPockets)
        {
            RemoveAirPockets();
        }
    }

    private void TraceAway() =>
        SurfaceArea = CalculateSurfaceArea(_cubes);

    private int CalculateSurfaceArea(List<(int X, int Y, int Z)> cubes)
    {
        var surfaceArea = 0;
        foreach (var cube in cubes)
        {
            var cubeSurfaceArea = 6;

            if (cubes.Contains((cube.X - 1, cube.Y, cube.Z)))
            {
                cubeSurfaceArea -= 1;
            }
            if (cubes.Contains((cube.X + 1, cube.Y, cube.Z)))
            {
                cubeSurfaceArea -= 1;
            }
            if (cubes.Contains((cube.X, cube.Y - 1, cube.Z)))
            {
                cubeSurfaceArea -= 1;
            }
            if (cubes.Contains((cube.X, cube.Y + 1, cube.Z)))
            {
                cubeSurfaceArea -= 1;
            }
            if (cubes.Contains((cube.X, cube.Y, cube.Z - 1)))
            {
                cubeSurfaceArea -= 1;
            }
            if (cubes.Contains((cube.X, cube.Y, cube.Z + 1)))
            {
                cubeSurfaceArea -= 1;
            }

            surfaceArea += cubeSurfaceArea;
        }

        return surfaceArea;
    }

    private void RemoveAirPockets()
    {
        var possibleAirPockets = new List<(int X, int Y, int Z)>();

        for (var z = 0; z < 20; z++)
        {
            for (var y = 0; y < 20; y++)
            {
                for (var x = 0; x < 20; x++)
                {
                    if (! _cubes.Contains((x, y, z)))
                    {
                        var blockedAtLeft = false;
                        var blockedAtRight = false;
                        var blockedAtBottom = false;
                        var blockedAtTop = false;
                        var blockedAtFront = false;
                        var blockedAtBack = false;

                        if (_cubes.Any(c => c.X < x && c.Y == y && c.Z == z))
                        {
                            blockedAtLeft = true;
                        }

                        if (_cubes.Any(c => c.X > x && c.Y == y && c.Z == z))
                        {
                            blockedAtRight = true;
                        }

                        if (_cubes.Any(c => c.Y < y && c.X == x && c.Z == z))
                        {
                            blockedAtBottom = true;
                        }

                        if (_cubes.Any(c => c.Y > y && c.X == x && c.Z == z))
                        {
                            blockedAtTop = true;
                        }

                        if (_cubes.Any(c => c.Z < z && c.X == x && c.Y == y))
                        {
                            blockedAtBack = true;
                        }

                        if (_cubes.Any(c => c.Z > z && c.X == x && c.Y == y))
                        {
                            blockedAtFront = true;
                        }

                        if (blockedAtBack && blockedAtFront && blockedAtTop && blockedAtBottom && blockedAtLeft && blockedAtRight)
                        {
                            possibleAirPockets.Add((x, y, z));
                        }
                    }
                }
            }
        }

        possibleAirPockets.Sort();
        var confirmedAirPocket = new List<(int X, int Y, int Z)>();
        var airPocket = new List<(int X, int Y, int Z)>();

        foreach (var possibleAirPocket in possibleAirPockets)
        {
            if (! confirmedAirPocket.Contains(possibleAirPocket))
            {
                var currentAirPocket = new List<(int X, int Y, int Z)>();
                ExpandAirPocket(possibleAirPocket, possibleAirPockets, currentAirPocket);

                if (!currentAirPocket.Any(p => p.X == 0 || p.Y == 0 || p.Z == 0))
                {
                    confirmedAirPocket.AddRange(currentAirPocket);
                    var area = CalculateSurfaceArea(currentAirPocket);
                    SurfaceArea -= area;
                }
            }
        }
    }

    private void ExpandAirPocket((int X, int Y, int Z) possibleAirPocket, List<(int X, int Y, int Z)> possibleAirPockets, List<(int X, int Y, int Z)> currentAirPocket)
    {
        currentAirPocket.Add(possibleAirPocket);

        var nextPossibleAirPocket = (possibleAirPocket.X - 1, possibleAirPocket.Y, possibleAirPocket.Z);
        if (possibleAirPockets.Contains(nextPossibleAirPocket) && !currentAirPocket.Contains(nextPossibleAirPocket))
        {
            ExpandAirPocket(nextPossibleAirPocket, possibleAirPockets, currentAirPocket);
        }

        nextPossibleAirPocket = (possibleAirPocket.X + 1, possibleAirPocket.Y, possibleAirPocket.Z);
        if (possibleAirPockets.Contains(nextPossibleAirPocket) && !currentAirPocket.Contains(nextPossibleAirPocket))
        {
            ExpandAirPocket(nextPossibleAirPocket, possibleAirPockets, currentAirPocket);
        }

        nextPossibleAirPocket = (possibleAirPocket.X, possibleAirPocket.Y - 1, possibleAirPocket.Z);
        if (possibleAirPockets.Contains(nextPossibleAirPocket) && !currentAirPocket.Contains(nextPossibleAirPocket))
        {
            ExpandAirPocket(nextPossibleAirPocket, possibleAirPockets, currentAirPocket);
        }

        nextPossibleAirPocket = (possibleAirPocket.X, possibleAirPocket.Y + 1, possibleAirPocket.Z);
        if (possibleAirPockets.Contains(nextPossibleAirPocket) && !currentAirPocket.Contains(nextPossibleAirPocket))
        {
            ExpandAirPocket(nextPossibleAirPocket, possibleAirPockets, currentAirPocket);
        }

        nextPossibleAirPocket = (possibleAirPocket.X, possibleAirPocket.Y, possibleAirPocket.Z - 1);
        if (possibleAirPockets.Contains(nextPossibleAirPocket) && !currentAirPocket.Contains(nextPossibleAirPocket))
        {
            ExpandAirPocket(nextPossibleAirPocket, possibleAirPockets, currentAirPocket);
        }

        nextPossibleAirPocket = (possibleAirPocket.X, possibleAirPocket.Y, possibleAirPocket.Z + 1);
        if (possibleAirPockets.Contains(nextPossibleAirPocket) && !currentAirPocket.Contains(nextPossibleAirPocket))
        {
            ExpandAirPocket(nextPossibleAirPocket, possibleAirPockets, currentAirPocket);
        }
    }
}