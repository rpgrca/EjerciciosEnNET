namespace ArrayDiff.Logic;

public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b) =>
        a.Where(p => !b.Contains(p)).ToArray();
}