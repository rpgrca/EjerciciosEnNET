namespace SumWithoutHighestAndLowestNumber.Logic;

using System;
using System.Linq;

public static class Kata
{
    public static int Sum(int[] numbers)
    {
        if (numbers is null || numbers.Length < 3) return 0;
        return numbers.OrderBy(p => p).Skip(1).Take(numbers.Length - 2).Sum();
    }
}