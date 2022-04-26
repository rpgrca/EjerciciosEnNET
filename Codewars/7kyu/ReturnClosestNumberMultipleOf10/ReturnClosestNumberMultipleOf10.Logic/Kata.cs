namespace ReturnClosestNumberMultipleOf10.Logic;

using System;

public class Kata
{
    public int ClosestMultiple10(int num) => ((num / 10) + (num % 10 < 5 ? 0 : 1)) * 10;
}