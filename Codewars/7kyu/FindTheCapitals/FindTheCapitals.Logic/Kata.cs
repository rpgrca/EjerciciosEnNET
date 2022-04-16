using System;

namespace FindTheCapitals.Logic;

public static class Kata
{
    public static int[] Capitals(string word) =>
        word.Select((p, i) => (p, i)).Where(x => char.IsUpper(x.p)).Select(x => x.i).ToArray();
}