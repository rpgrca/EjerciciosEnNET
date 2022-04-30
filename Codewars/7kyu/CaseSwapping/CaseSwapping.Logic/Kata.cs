namespace CaseSwapping.Logic;

using System;

public static class Kata
{
    public static string Swap(string str) =>
        string.Concat(str.Select(p => !char.IsLetter(p)? p : (char)(p ^ 32)));
}