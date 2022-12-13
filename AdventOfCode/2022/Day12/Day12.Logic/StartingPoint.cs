using System.Collections;

namespace Day12.Logic;

public class StartingPoint : IEnumerable
{
    private readonly (int x, int y) _startingPoint;

    public StartingPoint(int[][] _, (int x, int y) startingPoint) =>
        _startingPoint = startingPoint;

    IEnumerator IEnumerable.GetEnumerator()
    {
        yield return _startingPoint.y << 8 | _startingPoint.x;
    }
}