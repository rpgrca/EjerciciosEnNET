namespace Mumbling.Logic;

using System;

public class Accumul
{
    public static String Accum(string s) =>
        string.Join("-", s.Select((p, i) => char.ToUpper(p) + new string(char.ToLower(p), i)));
}