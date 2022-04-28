namespace CountTheDigit.Logic;

public class CountDig
{
    public static int NbDig(int n, int d) =>
        string.Concat(Enumerable.Range(0, n + 1).Select(p => p * p)).Count(p => p == '0' + d);
}