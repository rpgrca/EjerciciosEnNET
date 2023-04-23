using System;

namespace SortedSearch.Logic;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        var bottom = 0;
        var top = sortedArray.Length - 1;
        int previousTop;
        int previousBottom;
        int middle;

        if (top < 100)
        {
            return sortedArray.TakeWhile(p => p < lessThan).Count();
        }

        do
        {
            previousBottom = bottom;
            previousTop = top;

            middle = (top - bottom) / 2;
            if (sortedArray[bottom + middle] < lessThan)
            {
                bottom += middle;
            }

            if (sortedArray[top - middle] > lessThan)
            {
                top -= middle;
            }

        } while (previousBottom != bottom || previousTop != top);

        return sortedArray[bottom + middle] == lessThan ? (top + bottom) / 2 : top;
    }
}
