namespace CountCharactersInString.Logic;

using System;
using System.Collections.Generic;

public class Kata
{
  public static Dictionary<char, int> Count(string str) =>
    str.OrderBy(p => p).GroupBy(p => p, (q, r) => new { Key = q, Value = r.Count() }).ToDictionary(k => k.Key, v => v.Value);
}