namespace CountCharactersInString.Logic;

using System;
using System.Collections.Generic;

public class Kata
{
  public static Dictionary<char, int> Count(string str) =>
    str.GroupBy(p => p).ToDictionary(k => k.Key, v => v.Count());
}