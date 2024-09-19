namespace FindTheDivisors.Logic;

public class Kata
{
#nullable enable
    public static int[]? Divisors(int n)
    {
        var divisors = new List<int>();
        var maximum = n / 2;
     
        for (var i = 2; i <= maximum; i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
            }
        }

        return divisors.Count == 0 ? null : divisors.ToArray();
    }
#nullable disable
}