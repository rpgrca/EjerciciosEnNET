using System;
using System.Collections.Generic;

namespace MostUsedWordInText.Logic;

public class TopWords
{
    public static List<string> Top3(string s)
    {
        var words = s
          .Split(new char[] { '.', ' ', '\n', '\r', ',', '/' });
        return words
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .Where(p => p.Any(p => char.IsAsciiLetterOrDigit(p)))
            .Select(p => p.ToLower())
            .GroupBy(p => p, (a, b) => new { Word = a, Count = b.Count() }, StringComparer.CurrentCultureIgnoreCase)
            .OrderByDescending(p => p.Count)
            .Take(3)
            .Select(w => w.Word)
            .ToList();
    }

}