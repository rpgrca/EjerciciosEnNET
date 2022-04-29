namespace ExclamationMarksSeries6.Logic;

public class Kata
{
    public static string Remove(string s, int n) =>
        s.Aggregate(string.Empty, (t, i) => t + (i == '!' && n-- > 0 ? "" : i));
}