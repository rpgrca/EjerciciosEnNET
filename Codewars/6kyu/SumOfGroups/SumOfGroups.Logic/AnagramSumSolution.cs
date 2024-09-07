using System.Numerics;

namespace SumOfGroups.Logic;

public class AnagramSumSolution
{
    public static int SumOfDigitGroups(BigInteger[] numbers) =>
        numbers
            .Select(p => new { Key = string.Concat(p.ToString().OrderBy(p => p)), Values = p })
            .GroupBy(p => p.Key, p => p.Values, (k, g) => new { Key = k, Values = g.ToList() })
            .Where(p => p.Values.Count > 1)
            .Aggregate(new BigInteger(0), (t, i) => t + i.Values.MinBy(p => p))
            .ToString()
            .Aggregate(0, (t, i) => t + i - '0');
}
