using System.Collections;

namespace Day12.Logic;

public class StartingPoints : IEnumerable
{
    private readonly int[][] _map;
    private readonly int _rows;
    private readonly int _columns;

    public StartingPoints(int[][] map, (int x, int y) _)
    {
        _map = map;
        _rows = _map.Length;
        _columns = _map[0].Length;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (var y = _rows - 1; y >= 0; y--)
        {
            for (var x = _columns - 1; x >= 0; x--)
            {
                if (_map[y][x] == 'a')
                {
                    yield return y << 8 | x;
                }
            }
        }
    }
}