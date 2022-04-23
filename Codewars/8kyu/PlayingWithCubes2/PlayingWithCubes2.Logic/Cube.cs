namespace PlayingWithCubes2.Logic;

public class Cube
{
    private int Side;

    //This cube needs your help. 
    //Define a constructor which takes one integer and assignes its value to 'Side'

    public int GetSide()
    {
        return this.Side;
    }

    public void SetSide(int s)
    {
        this.Side = s;
    }
}