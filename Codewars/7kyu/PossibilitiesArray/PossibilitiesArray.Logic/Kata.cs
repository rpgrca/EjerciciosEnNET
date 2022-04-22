namespace PossibilitiesArray.Logic;

using System;

public static class Kata
{
    public static bool IsAllPossibilities(int[] arr)
    {
        var expectedValue = 0;
        foreach (var index in arr.OrderBy(p => p))
        {
            if (index != expectedValue++) return false;
        }

        return true;
    }
}