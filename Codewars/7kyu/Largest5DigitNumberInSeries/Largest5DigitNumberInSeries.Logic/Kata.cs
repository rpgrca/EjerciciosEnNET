namespace Largest5DigitNumberInSeries.Logic;

using System;

public class Kata
{
    public static int GetNumber(string str) =>
        str[0..^4].Zip(str[1..^3]).Zip(str[2..^2]).Zip(str[3..^1]).Zip(str[4..])
            .Select(i => ((i.First.First.First.First - '0') * 10000) + ((i.First.First.First.Second - '0') * 1000) + ((i.First.First.Second - '0') * 100) + ((i.First.Second - '0') * 10) + (i.Second - '0'))
            .OrderByDescending(p => p)
            .First();
}