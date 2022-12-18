namespace Day18.Logic;

public class BoilingBoulders
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<(int X, int Y, int Z)> _cubes;

    public int SurfaceArea { get; set; }

    public BoilingBoulders(string input)
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
    }

    private void TraceAway()
    {
        SurfaceArea = 0;

        foreach (var cube in _cubes)
        {
            var blockedAtLeft = false;
            var blockedAtRight = false;
            var blockedAtBottom = false;
            var blockedAtTop = false;
            var blockedAtFront = false;
            var blockedAtBack = false;
            var cubeSurfaceArea = 6;

            if (_cubes.Any(c => c.X < cube.X && c.Y == cube.Y && c.Z == cube.Z))
            {
                blockedAtLeft = true;
                if (_cubes.Contains((cube.X - 1, cube.Y, cube.Z)))
                {
                    cubeSurfaceArea -= 1;
                }
            }

            if (_cubes.Any(c => c.X > cube.X && c.Y == cube.Y && c.Z == cube.Z))
            {
                blockedAtRight = true;
                if (_cubes.Contains((cube.X + 1, cube.Y, cube.Z)))
                {
                    cubeSurfaceArea -= 1;
                }
            }

            if (_cubes.Any(c => c.Y < cube.Y && c.X == cube.X && c.Z == cube.Z))
            {
                blockedAtBottom = true;
                if (_cubes.Contains((cube.X, cube.Y - 1, cube.Z)))
                {
                    cubeSurfaceArea -= 1;
                }
            }

            if (_cubes.Any(c => c.Y > cube.Y && c.X == cube.X && c.Z == cube.Z))
            {
                blockedAtTop = true;
                if (_cubes.Contains((cube.X, cube.Y + 1, cube.Z)))
                {
                    cubeSurfaceArea -= 1;
                }
            }

            if (_cubes.Any(c => c.Z < cube.Z && c.X == cube.X && c.Y == cube.Y))
            {
                blockedAtBack = true;
                if (_cubes.Contains((cube.X, cube.Y, cube.Z - 1)))
                {
                    cubeSurfaceArea -= 1;
                }
            }

            if (_cubes.Any(c => c.Z > cube.Z && c.X == cube.X && c.Y == cube.Y))
            {
                blockedAtFront = true;
                if (_cubes.Contains((cube.X, cube.Y, cube.Z + 1)))
                {
                    cubeSurfaceArea -= 1;
                }
            }

            if (blockedAtBack && blockedAtFront && blockedAtTop && blockedAtBottom && blockedAtLeft && blockedAtRight)
            {
                continue;
            }

            SurfaceArea += cubeSurfaceArea;
        }
    }
}
