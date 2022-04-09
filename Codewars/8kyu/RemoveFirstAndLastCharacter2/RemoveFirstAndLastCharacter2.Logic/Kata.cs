namespace RemoveFirstAndLastCharacter2.Logic;

public static class Kata
{
    public static string? Array(string s)
    {
        var values = s.Split(",");
        return values.Length < 3 ? null : string.Join(" ", values[1..^1]);
    }
}