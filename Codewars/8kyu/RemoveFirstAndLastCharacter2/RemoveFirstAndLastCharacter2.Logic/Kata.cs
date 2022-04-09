namespace RemoveFirstAndLastCharacter2.Logic;

public static class Kata
{
    public static string? Array(string s)
    {
        var values = s?.Split(",");
        if (values.Length < 3) return null;
        return string.Join(" ", values[1..^1]);
    }
}