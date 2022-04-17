using System;
using System.Linq;

namespace SortNumbers.Logic;

public class Kata
{
    public static int[] SortNumbers(int[] nums) =>
        nums is null ? Array.Empty<int>() : nums.OrderBy(n => n).ToArray();
}