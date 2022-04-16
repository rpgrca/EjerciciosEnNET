using System.Linq;

namespace FindTheVowels.Logic;

public class Kata
{
    public static int[] VowelIndices(string word) =>
        word
            .Select((p, i) => new { p, i})
            .Where(a => "aeiouyAEIOUY".Contains(a.p))
            .Select(a => a.i + 1)
            .ToArray();
}