using System.Numerics;

namespace SumOfGroups.Logic;

public class AnagramSumSolution
{
    public static int SumOfDigitGroups(BigInteger[] numbers)
    {
        var collection = numbers.Select(p => new { Value = p, Key = p.ToString().OrderBy(p => p) });
        return 0;
    }  
}
