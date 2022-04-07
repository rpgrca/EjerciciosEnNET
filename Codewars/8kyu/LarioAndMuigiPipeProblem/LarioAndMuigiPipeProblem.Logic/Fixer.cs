using System.Collections.Generic;
using System.Linq;

public class Fixer
{
    public static List<int> PipeFix(List<int> numbers)
    {
        var min = numbers.Min();
        return Enumerable.Range(min, numbers.Max() - min + 1).ToList();
    }
}