namespace MaximumLengthDifference.Logic;

using System;

public class MaxDiffLength
{
    public static int Mxdiflg(string[] a1, string[] a2)
    {
        if (a1.Length == 0 || a2.Length == 0) return -1;

        var sortedA1 = a1.Select(p => p.Length).OrderBy(p => p);
        var sortedA2 = a2.Select(p => p.Length).OrderBy(p => p);

        return Math.Max(sortedA1.Last() - sortedA2.First(), sortedA2.Last() - sortedA1.First());
    }
}