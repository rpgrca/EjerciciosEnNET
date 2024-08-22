namespace TheHighestProfitWins.Logic;

using System;

public class MinMax 
{
    public static int[] minMax(int[] lst) 
    {
        var min = lst[0];
        var max = lst[0];

        foreach (var value in lst) {
            if (value < min) min = value;
            if (value > max) max = value;
        }

        return new[] { min, max };
    }
}