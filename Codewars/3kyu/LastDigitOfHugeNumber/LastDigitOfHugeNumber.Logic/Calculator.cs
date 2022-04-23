namespace LastDigitOfHugeNumber.Logic;

using System;
using System.Numerics;

public class Calculator
{
    public static int LastDigit(int[] array)
    {
        if (array.Length == 0) return 1;
        if (array.Length == 1) return array[0] % 10;

        var result = LastDigitOf(array.Select(p => new BigInteger(p)).ToArray(), 0);
        BigInteger.DivRem(result, 10, out var remainder);
        return (int)remainder;
    }

    private static BigInteger LastDigitOf(BigInteger[] array, int level)
    {
        BigInteger exponent;
        if (array.Length > 2)
        {
            exponent = LastDigitOf(array[1..], level + 1);
        }
        else
        {
            exponent = array[1];
        }

        if (array[0] == 0)
        {
            if (exponent == 0) return 1;
            else return 0;
        }

        var result = BigInteger.ModPow(array[0], exponent, 10000);
        if (result == 0 && level != 0)
        {
            result = 4;
        }

        return result;
    }
}