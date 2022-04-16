namespace MultiplesOf3Or5.Logic;

public static class Kata
{
    public static int Solution(int value) =>
        value < 1 ? 0 : Enumerable.Range(1, value - 1).Where(p => p % 3 == 0 || p % 5 == 0).Sum();
}