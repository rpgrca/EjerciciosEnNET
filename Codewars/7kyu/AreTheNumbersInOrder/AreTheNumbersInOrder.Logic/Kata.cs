namespace AreTheNumbersInOrder.Logic;

using System;

public class Kata
{
    public static bool IsAscOrder(int[] arr)
    {
        var previousValue = int.MinValue;
        foreach (var value in arr)
        {
            if (value < previousValue) return false;
            previousValue = value;
        }

        return true;
    }
}