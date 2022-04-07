
public class Kata
{
    public static double SquareArea(double A)
    {
        var radio = A * 2 / Math.PI;
        return Math.Round(radio * radio, 2);
    }
}