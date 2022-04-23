namespace LastDigitOfHugeNumber.Logic;

using System;
using System.Numerics;

public class Calculator
{
    public static int LastDigit2(int[] array)
    {
        if (array.Length == 0 || array.Length == 1) return 1;
        if (array.Length == 2 && array[0] == 0 && array[1] == 0) return 1;

        var value = array[0];
        var originalValue = value;
        var power = 1L;

        foreach (var number in array[1..])
        {
            power *= number;
        }

        var binary = Convert.ToString(power, 2);
        foreach (var binaryDigit in binary[1..])
        {
            value = (value * value) % 10;
            if (binaryDigit == '1')
            {
                value = (value * originalValue) % 10;
            }
        }

        return value % 10;
    }

    public static int LastDigit1(int[] array, int recursionLevel = 0)
    {
        if (array.Length == 0 || array.Length == 1) return 1;

        if (array.Length > 2)
        {
            var exponent = LastDigit1(array[1..], recursionLevel + 1);

            var originalValue = array[0];
            var power = exponent;
            var value = originalValue;

            var binary = Convert.ToString(power, 2);
            foreach (var binaryDigit in binary[1..])
            {
                value = (value * value) % 100;
                if (binaryDigit == '1')
                {
                    value = (value * originalValue) % 100;
                }
            }

            return value % (recursionLevel == 0? 10 : 100);
        }
        else
        {
            if (array[0] == 0 && array[1] == 0) return 1;

            var originalValue = array[0];
            var power = array[1];
            var value = originalValue;

            var binary = Convert.ToString(power, 2);
            foreach (var binaryDigit in binary[1..])
            {
                value = (value * value) % 100;
                if (binaryDigit == '1')
                {
                    value = (value * originalValue) % 100;
                }
            }

            return value % 100;
        }
    }

    public static int LastDigit3(int[] array)
    {
        if (array.Length == 0 || array.Length == 1) return 1;

        if (array.Length > 2)
        {
            var exponent = LastDigit3(array[1..]);
            var value = array[0] % 10;

            var power = exponent % 4;
            if (power == 0)
            {
                power = 4;
            }

            return (int)Math.Pow(value, power) % 10;
        }
        else
        {
            if (array[0] == 0 && array[1] == 0) return 1;

            if (array[0] % 10 == 1)
            {
                return ((array[0] / 10 % 10 * array[1] % 10 * 10) + 1) % 10;
            }
            else
            {
                var value = array[0] % 10;
                var power = array[1] % 4;
                if (power == 0)
                {
                    power = 4;
                }

                return (int)Math.Pow(value, power) % 10;
            }
        }
    }

    public static int LastDigit4(int[] array)
    {
        if (array.Length < 2) return 1;

        var result = LastDigitOf(array.Select(p => new BigInteger(p)).ToArray());
        BigInteger.DivRem(result, 10, out var remainder);
        return (int)remainder;
    }

    private static BigInteger LastDigitOf(BigInteger[] array)
    {
        BigInteger exponent;
        if (array.Length > 2)
        {
            exponent = LastDigitOf(array[1..]);
        }
        else
        {
            exponent = array[1];
        }

        if (array[0] == 0 && exponent == 0) return 1;
        return BigInteger.ModPow(array[0], exponent, 10);
    }

    public static int LastDigit5(int[] array)
    {
        if (array.Length < 2) return 1;

        int exponent;
        if (array.Length > 2)
        {
            exponent = LastDigit5(array[1..]);
        }
        else
        {
            exponent = array[1];
        }

        if (array[0] == 0)
        {
            return exponent == 0? 1 : 0;
        }

        if (exponent == 0) return 1;

        if (exponent % 4 == 0)
        {
            return (int)(((long)Math.Pow(array[0], 4)) % 10);
        }
        else
        {
            return (int)(((long)(Math.Pow(array[0], (exponent % 4)))) % 10);
        }
    }

    public static int LastDigit6(int[] array)
    {
        if (array.Length < 2) return 1;

        int exponent;
        if (array.Length > 2)
        {
            exponent = LastDigit6(array[1..]);
        }
        else
        {
            exponent = array[1];
        }

        if (exponent == 0) exponent = 4;

        var value = array[0];
        var result = 1;
        while (exponent > 0)
        {
            if (exponent % 2 == 1)
            {
                result = (result * value) % 10;
            }

            exponent = exponent / 2;
            value = (value * value) % 10;
        }

        return result;
    }

    public static int LastDigit(int[] array)
    {
        if (array.Length == 0) return 1;
        if (array.Length == 1) return array[0] % 10;

        int exponent;
        if (array.Length > 2)
        {
            exponent = LastDigit(array[1..]);
            if (exponent == 0 || exponent == 6 || exponent == 2)
            {
                exponent = 4;
            }
        }
        else
        {
            exponent = array[1];
        }
        var value = array[0];

        var conversions = new int[][]
        {
            new int[] { 0, 0, 0, 0 },
            new int[] { 1, 1, 1, 1 },
            new int[] { 6, 2, 4, 8 },
            new int[] { 1, 3, 9, 7 },
            new int[] { 6, 4, 6, 4 },
            new int[] { 5, 5, 5, 5 },
            new int[] { 6, 6, 6, 6 },
            new int[] { 1, 7, 9, 3 },
            new int[] { 6, 8, 4, 2 },
            new int[] { 1, 9, 1, 9 }
        };

        return exponent == 0? 1 : conversions[value % 10][exponent % 4];
    }
}