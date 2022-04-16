using System.Linq;

namespace FindTheVowels.Logic;

public class Kata
{
    public static int[] VowelIndices(string word) =>
        word
            .Select((p, i) => new { p, i})
            .Where(a => a.p is 'a' or 'e' or 'i' or 'o' or 'u' or 'y')
            .Select(a => a.i + 1)
            .ToArray();
}