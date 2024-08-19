using System;
using System.Linq;
using static System.Linq.Enumerable;

namespace DescendingOrder.Logic;

public static class Kata
{
  public static int DescendingOrder(int num) =>
    int.Parse(string.Join("", num.ToString().OrderDescending()));
}
