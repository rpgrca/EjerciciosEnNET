namespace CaseSwapping.Logic;

using System;

public static class Kata
{
    public static string Swap(string str) =>
        string.Concat(str.Select(p => (p & 32) == 32 ? (char)(p & ~32) : (char)(p | 32)));
}