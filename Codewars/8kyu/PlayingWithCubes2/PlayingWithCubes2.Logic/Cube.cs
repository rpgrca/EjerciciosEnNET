namespace PlayingWithCubes2.Logic;

public class Cube
{
    private int _side;

    public Cube(int s = 0) => SetSide(s);

    public int GetSide() => _side;

    public void SetSide(int s) => _side = Math.Abs(s);
}