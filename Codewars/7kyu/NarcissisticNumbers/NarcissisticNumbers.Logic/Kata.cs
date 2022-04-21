using System.Linq;

namespace NarcissisticNumbers.Logic;

public class Kata
{
    public static bool IsNarcissistic(long n)
    {
        var digits = n.ToString().Select(p => p - '0').ToArray();
        var power = digits.Length;
        return digits.Aggregate(0L, (t, i) => t + (long)Math.Pow(i, power)) == n;
    }
}