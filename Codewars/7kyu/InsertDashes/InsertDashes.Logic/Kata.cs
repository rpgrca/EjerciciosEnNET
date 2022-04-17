namespace InsertDashes.Logic;

public class Kata
{
    public static string InsertDash(int num) =>
        num.ToString().Aggregate(string.Empty, (t, i) => $"{t}{(!string.IsNullOrEmpty(t) && ((i - '0') & (t[^1] - '0') & 1) == 1? "-" : "")}{i}");
}