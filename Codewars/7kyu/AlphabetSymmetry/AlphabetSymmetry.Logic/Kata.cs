namespace AlphabetSymmetry.Logic;

using System;
using System.Collections.Generic;

public static class Kata
{
    public static List<int> Solve(List<string> arr) =>
        arr.ConvertAll(p => p
            .Select((x, i) => (Char.ToLower(x), i))
            .Count(t => t.Item1 - 'a' == t.i));
}
