namespace VowelRemover.Logic;

public class Kata
{
    public static string Shortcut(string input) =>
      string.Join("", input.Where(c => c is not ('a' or 'e' or 'i' or 'o' or 'u')));
}