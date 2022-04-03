namespace DoubleChar.Logic;

public class Kata
{
    public static string DoubleChar(string s) =>
        s.Aggregate(string.Empty, (t, i) => $"{t}{i}{i}");
}