using System;

namespace GiveMeAdiamond.Logic;

public class Diamond
{
    public static string? Print(int n)
    {
        if (n < 0 || n % 2 == 0) return null;
        var result = string.Empty;

        for (var index = 1; index <= n; index += 2)
        {
            result += new string(' ', (n - index) / 2) + new string('*', index) + "\n";
        }

        for (var index = n - 2; index >= 1; index -= 2)
        {
            result += new string(' ', (n - index) / 2) + new string('*', index) + "\n";
        }

        return result;
    }
}