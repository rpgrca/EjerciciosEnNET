namespace LastDigitOfHugeNumber.Logic;

using System;
using System.Numerics;

public class Calculator
{
    public static int LastDigit(int[] array)
    {
        if (array.Length == 0) return 1;
        if (array.Length == 1) return array[0] % 10;

        var result = LastDigitOf(array.Select(p => new BigInteger(p)).ToArray());
        BigInteger.DivRem(result, 10, out var remainder);
        return (int)remainder;
    }

    private static BigInteger LastDigitOf(BigInteger[] array, int level = 0)
    {
        var exponent = (array.Length > 2)
            ? LastDigitOf(array[1..], level + 1)
            : array[1];

        if (array[0] == 0)
        {
            return (exponent == 0) ? 1 : 0;
        }

        var result = BigInteger.ModPow(array[0], exponent, 10000);
        return (result == 0 && level != 0) ? 4 : result;
    }
}