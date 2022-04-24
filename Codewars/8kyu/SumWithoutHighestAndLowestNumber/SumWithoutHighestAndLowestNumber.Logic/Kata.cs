namespace SumWithoutHighestAndLowestNumber.Logic;

using System;
using System.Linq;

public static class Kata
{
    public static int Sum(int[] numbers) =>
        numbers?.OrderBy(p => p).Skip(1).Take(numbers.Length - 2).Sum() ?? 0;
}