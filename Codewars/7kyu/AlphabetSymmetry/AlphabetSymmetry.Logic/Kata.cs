namespace AlphabetSymmetry.Logic;

using System;
using System.Collections.Generic;

public static class Kata
{
    public static List<int> Solve(List<string> arr) =>
        arr.ConvertAll(p => p
            .Select((x, i) => (x.ToString().ToLower()[0], i))
            .Count(t => t.Item1 - 'a' == t.i));
}