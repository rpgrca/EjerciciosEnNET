namespace PlayingWithCubes2.Logic;

public class Cube
{
    private int Side;

    public Cube(int s)
    {
        Side = Math.Abs(s);
    }

    public Cube()
    {
        Side = 0;
    }

    public int GetSide()
    {
        return this.Side;
    }

    public void SetSide(int s)
    {
        this.Side = s;
    }
}