using System;

namespace DescendingOrder.Logic;

public static class Kata
{
  public static int DescendingOrder(int num)
  {
    var value = int.Parse(string.Join("", num.ToString().OrderByDescending(p => p)));
    return value;
  }
}
