namespace FindTheNthDigitOfNumber.Logic;

public class Kata
{
    public static int FindDigit(int num, int nth)
    {
        if (nth <= 0) return -1;
        return Math.Abs(num) / (int)Math.Pow(10, nth - 1) % 10;
    }
}