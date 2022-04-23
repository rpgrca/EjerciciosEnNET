namespace LastDigitOfHugeNumber.Logic;

using System;

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

    public static int LastDigit(int[] array)
    {
        if (array.Length == 0 || array.Length == 1) return 1;

        if (array.Length > 2)
        {
            var exponent = LastDigit(array[1..]);
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

            var value = array[0] % 10;
            var power = array[1] % 4;
            if (power == 0)
            {
                power = 4;
            }

            return (int)Math.Pow(value, power) % 100;
        }
    }
}