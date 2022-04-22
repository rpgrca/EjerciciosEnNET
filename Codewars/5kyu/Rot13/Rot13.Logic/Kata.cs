namespace Rot13.Logic;

using System;

public class Kata
{
    public static string Rot13(string input) =>
        input.Aggregate(string.Empty, (t, i) => t += char.IsLetter(i) ? (char)((((i & 31) + 13) % 26) + (i & 96)) : i);
}