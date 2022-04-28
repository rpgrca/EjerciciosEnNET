namespace CharacterCounter.Logic;

public class Kata
{
    public static bool ValidateWord(string s) =>
        s.GroupBy(w => char.ToUpper(w)).Select(p => p.Count()).GroupBy(p => p).Count() == 1;
}