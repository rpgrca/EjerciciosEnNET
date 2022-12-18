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

    private void TraceAway()
    {
        SurfaceArea = 0;

        foreach (var cube in _cubes)
        {
            var cubeSurfaceArea = 6;

            if (_cubes.Contains((cube.X - 1, cube.Y, cube.Z)))
            {
                cubeSurfaceArea -= 1;
            }
            if (_cubes.Contains((cube.X + 1, cube.Y, cube.Z)))
            {
                cubeSurfaceArea -= 1;
            }
            if (_cubes.Contains((cube.X, cube.Y - 1, cube.Z)))
            {
                cubeSurfaceArea -= 1;
            }
            if (_cubes.Contains((cube.X, cube.Y + 1, cube.Z)))
            {
                cubeSurfaceArea -= 1;
            }
            if (_cubes.Contains((cube.X, cube.Y, cube.Z - 1)))
            {
                cubeSurfaceArea -= 1;
            }
            if (_cubes.Contains((cube.X, cube.Y, cube.Z + 1)))
            {
                cubeSurfaceArea -= 1;
            }

            SurfaceArea += cubeSurfaceArea;
        }
    }

    private void RemoveAirPockets()
    {
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
                            SurfaceArea -= 6;
                        }
                    }
                }
            }
        }
    }
}