namespace Day9.Logic;

public class Knot
{
    private int _x;
    private int _y;

    public (int X, int Y) Position => (_x, _y);

    public void MoveRight() => _x++;

    public void MoveLeft() => _x--;

    public void MoveUp() => _y--;

    public void MoveDown() => _y++;

    public bool TooFarHorizontallyFrom(Knot head) => Math.Abs(head._x - _x) > 1;

    public bool TooFarVerticallyFrom(Knot head) => Math.Abs(head._y - _y) > 1;

    public bool IsAtMyRight(Knot head) => head._x > _x;

    public bool IsAtMyLeft(Knot head) => head._x < _x;

    public bool IsAboveMe(Knot head) => head._y < _y;

    public bool IsBelowMe(Knot head) => head._y > _y;
}
