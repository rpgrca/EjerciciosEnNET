namespace SumOfTwoLowestPositiveIntegers.Logic;

public static class Kata
{
    public static int sumTwoSmallestNumbers(int[] numbers) =>
        numbers.OrderBy(p => p).Take(2).Sum();
}