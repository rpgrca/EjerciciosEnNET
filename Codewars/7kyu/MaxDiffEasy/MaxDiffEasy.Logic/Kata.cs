namespace MaxDiffEasy.Logic;

public class Kata
{
    public static int MaxDiff(int[] lst)
    {
        if (lst.Length < 2) return 0;
        return lst.Max() - lst.Min();
    }
}