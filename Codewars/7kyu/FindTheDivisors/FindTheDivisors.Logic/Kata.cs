namespace FindTheDivisors.Logic;

public class Kata
{
#nullable enable
    public static int[]? Divisors(int n)
    {
        var divisors = Enumerable
            .Range(2, n / 2 - 1)
            .Where(p => n % p == 0)
            .Select(p => p)
            .ToArray();

        return divisors.Length == 0 ? null : divisors;
/*
        var divisors = new List<int>();
        var maximum = n / 2;

        for (var i = 2; i <= maximum; i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
            }
        }

        return divisors.Count == 0 ? null : divisors.ToArray();*/
    }
#nullable disable
}