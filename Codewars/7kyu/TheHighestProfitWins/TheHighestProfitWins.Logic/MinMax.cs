namespace TheHighestProfitWins.Logic;

using System;

public class MinMax 
{
    public static int[] minMax(int[] lst) 
    {
        if (lst.Length == 1)
        {
            return new[] { lst[0], lst[0] };
        }

        var sorted = lst.OrderBy(p => p).ToList();
        return new[] { sorted[0], sorted[^1] };
    }
}