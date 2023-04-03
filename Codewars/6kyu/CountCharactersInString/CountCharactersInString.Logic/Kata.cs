namespace CountCharactersInString.Logic;

using System;
using System.Collections.Generic;

public class Kata
{
  public static Dictionary<char, int> Count(string str)
  {
    var result = new Dictionary<char, int>();
    if (string.IsNullOrEmpty(str))
    {
        return result;
    }

    return str.OrderBy(p => p).GroupBy(p => p, (q, r) => new { Key = q, Value = r.Count() }).ToDictionary(k => k.Key, v => v.Value);
  }
}