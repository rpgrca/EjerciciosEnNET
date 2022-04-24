namespace ReversingWordsInString.Logic;

public class Kata
{
    public static string Reverse(string text) =>
        string.Join(" ", text.Split(" ").Reverse());
}
