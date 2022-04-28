namespace MaxDiffEasy.Logic;

public class Kata
{
    public static int MaxDiff(int[] lst) => lst.Length < 2 ? 0 : lst.Max() - lst.Min();
}