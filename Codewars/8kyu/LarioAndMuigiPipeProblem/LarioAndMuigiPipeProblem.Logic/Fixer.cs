using System.Collections.Generic;
using System.Linq;

public class Fixer
{
    public static List<int> PipeFix(List<int> numbers)
    {
        var min = numbers.Min();
        var length = numbers.Max() - min + 1;
        return Enumerable.Range(min, length).ToList();
    }
}