namespace RemoveTheMinimum.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

public class Remover
{
    public static List<int> RemoveSmallest(List<int> numbers)
    {
        var minimumValue = int.MaxValue;
        var minimumIndex = 0;
        for (var index = 0; index < numbers.Count; index++)
        {
            if (numbers[index] < minimumValue)
            {
                minimumValue = numbers[index];
                minimumIndex = index;
            }
        }

        return numbers.Select((p, i) => new { p, i}).Where(p => p.i != minimumIndex).Select(p => p.p).ToList();
    }
}