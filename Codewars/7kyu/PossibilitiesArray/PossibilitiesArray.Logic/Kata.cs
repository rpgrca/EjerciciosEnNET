namespace PossibilitiesArray.Logic;

using System;

public static class Kata
{
    public static bool IsAllPossibilities(int[] arr)
    {
        if (arr.Length == 0) return false;

        var orderedArray = arr.OrderBy(p => p).ToList();
        for (var index = 0; index < arr.Length; index++)
        {
            if (orderedArray.IndexOf(index) == -1) return false;
        }

        return true;
    }
}