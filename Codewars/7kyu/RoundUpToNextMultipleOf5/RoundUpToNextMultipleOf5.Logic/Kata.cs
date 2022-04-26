namespace RoundUpToNextMultipleOf5.Logic;

public class Kata
{
    public static int RoundToNext5(int n) => (int)Math.Ceiling(n / 5.0) * 5;
}