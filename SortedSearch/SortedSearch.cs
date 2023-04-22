using System;

namespace SortedSearch.Logic;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        return sortedArray.TakeWhile(p => p < lessThan).Count();
    }
}
