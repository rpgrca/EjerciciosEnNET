namespace Day22.Logic;

internal class Pointer3d : Pointer
{
    private readonly string[][] _planes;
    private readonly (int, Direction, Func<int, int, int, int, (int, int)>)[][] _transitions;
    private readonly (int TopX, int TopY)[] _origins;
    private int _currentPlane;
    private readonly int _maximumX;
    private readonly int _maximumY;

    public Pointer3d(char[,] map, string[][] planes, (int, Direction, Func<int, int, int, int, (int, int)>)[][] transitions, (int TopX, int TopY)[] origins, int startingX, int startingY, int startingPlane, int maximumX, int maximumY)
        : base(map, startingX, startingY)
    {
        _planes = planes;
        _transitions = transitions;
        _origins = origins;
        _currentPlane = startingPlane;
        _maximumX = maximumX;
        _maximumY = maximumY;
    }

    protected override (int, int, Direction) GetLocationRightOfMyself()
    {
        var sourcePlaneX = X - _origins[_currentPlane].TopX;
        var sourcePlaneY = Y - _origins[_currentPlane].TopY;

        if (sourcePlaneX + 1 >= _maximumX)
        {
            var transition = _transitions[_currentPlane][(int)Facing];
            var targetCoordinates = transition.Item3(sourcePlaneX, sourcePlaneY, _maximumX, _maximumY);
            _currentPlane = transition.Item1;
            return (targetCoordinates.Item1 + _origins[transition.Item1].TopX, targetCoordinates.Item2 + _origins[transition.Item1].TopY, transition.Item2);
        }

        var nextTile = _planes[_currentPlane][sourcePlaneY][sourcePlaneX + 1];
        return nextTile == '#' ? (X, Y, Facing) : (X + 1, Y, Facing);
    }

    protected override (int, int, Direction) GetLocationLeftOfMyself()
    {
        var sourcePlaneX = X - _origins[_currentPlane].TopX;
        var sourcePlaneY = Y - _origins[_currentPlane].TopY;

        if (sourcePlaneX - 1 < 0)
        {
            var transition = _transitions[_currentPlane][(int)Facing];
            var targetCoordinates = transition.Item3(sourcePlaneX, sourcePlaneY, _maximumX, _maximumY);
            _currentPlane = transition.Item1;
            return (targetCoordinates.Item1 + _origins[transition.Item1].TopX, targetCoordinates.Item2 + _origins[transition.Item1].TopY, transition.Item2);
        }

        var nextTile = _planes[_currentPlane][sourcePlaneY][sourcePlaneX - 1];
        return nextTile == '#' ? (X, Y, Facing) : (X - 1, Y, Facing);
    }

    protected override (int, int, Direction) GetLocationBelowMyself()
    {
        var sourcePlaneX = X - _origins[_currentPlane].TopX;
        var sourcePlaneY = Y - _origins[_currentPlane].TopY;

        if (sourcePlaneY + 1 >= _maximumY)
        {
            var transition = _transitions[_currentPlane][(int)Facing];
            var targetCoordinates = transition.Item3(sourcePlaneX, sourcePlaneY, _maximumX, _maximumY);
            var nextTile2 = _planes[transition.Item1][targetCoordinates.Item2][targetCoordinates.Item1];
            if (nextTile2 != '#')
            {
                _currentPlane = transition.Item1;
                return (targetCoordinates.Item1 + _origins[transition.Item1].TopX, targetCoordinates.Item2 + _origins[transition.Item1].TopY, transition.Item2);
            }
            else
            {
                return (X, Y, Facing);
            }
        }

        var nextTile = _planes[_currentPlane][sourcePlaneY + 1][sourcePlaneX];
        return nextTile == '#' ? (X, Y, Facing) : (X, Y + 1, Facing);
    }

    protected override (int, int, Direction) GetLocationAboveMyself()
    {
        var sourcePlaneX = X - _origins[_currentPlane].TopX;
        var sourcePlaneY = Y - _origins[_currentPlane].TopY;

        if (sourcePlaneY - 1 < 0)
        {
            var transition = _transitions[_currentPlane][(int)Facing];
            var targetCoordinates = transition.Item3(sourcePlaneX, sourcePlaneY, _maximumX, _maximumY);

            var nextTile2 = _planes[transition.Item1][targetCoordinates.Item2][targetCoordinates.Item1];
            if (nextTile2 != '#')
            {
                _currentPlane = transition.Item1;
                return (targetCoordinates.Item1 + _origins[transition.Item1].TopX, targetCoordinates.Item2 + _origins[transition.Item1].TopY, transition.Item2);
            }
            else
            {
                return (X, Y, Facing);
            }
        }

        var nextTile = _planes[_currentPlane][sourcePlaneY - 1][sourcePlaneX];
        return nextTile == '#' ? (X, Y, Facing) : (X, Y - 1, Facing);
    }
}