using System;
using System.Collections.Generic;

namespace MostUsedWordInText.Logic;

public class TopWords
{
    public static List<string> Top3(string s) => s
        .Split(new char[] { '.', ' ', '\n', '\r', ',', '/', '?', ';', '!', ':', '_', '-' })
        .Select(p => p.ToLower())
        .Where(p => !string.IsNullOrWhiteSpace(p) && p.Any(p => char.IsLetterOrDigit(p)))
        .GroupBy(p => p, (a, b) => new { Word = a, Count = b.Count() }, StringComparer.CurrentCultureIgnoreCase)
        .OrderByDescending(p => p.Count)
        .Take(3)
        .Select(w => w.Word)
        .ToList();
}