namespace CircleAreaInsideSquare.Logic;

using System;

public class Convert
{
    public static double SquareAreaToCircle(double size)
    {
        var side = Math.Sqrt(size);
        return Math.PI * Math.Pow(side / 2, 2);
    }
}