using System;
using System.Linq;

namespace SortNumbers.Logic;

public class Kata
{
    public static int[] SortNumbers(int[] nums) =>
        nums?.OrderBy(n => n).ToArray() ?? Array.Empty<int>();
}