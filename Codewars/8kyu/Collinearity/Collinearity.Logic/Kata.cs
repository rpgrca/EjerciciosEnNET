namespace Collinearity.Logic;

public class Kata
{
    public static bool Collinearity(int x1, int y1, int x2, int y2)
    {
        if (x1 == 0 && y1 == 0) return true;
        if (x2 == 0 && y2 == 0) return true;
        if (x1 == 0 && x2 == 0) return true;
        if (y1 == 0 && y2 == 0) return true;
        if (x2 != 0 && y2 != 0 && x1/x2 == y1/y2) return true;
        return false;
    }
}