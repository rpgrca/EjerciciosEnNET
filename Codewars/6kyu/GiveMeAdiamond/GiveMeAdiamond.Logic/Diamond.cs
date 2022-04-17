using System;

namespace GiveMeAdiamond.Logic;

public class Diamond
{
    public static string? Print(int n)
    {
        var diamondMaker = new DiamondMaker(n);
        return diamondMaker.Diamond;
    }
}

public class DiamondMaker
{
    public string? Diamond { get; }

    public DiamondMaker(int n)
    {
        if (n < 0 || n % 2 == 0)
        {
            Diamond = null;
            return;
        }

        var result = string.Empty;

        for (var index = 1; index <= n; index += 2)
        {
            result += new string(' ', (n - index) / 2) + new string('*', index) + "\n";
        }

        for (var index = n - 2; index >= 1; index -= 2)
        {
            result += new string(' ', (n - index) / 2) + new string('*', index) + "\n";
        }

        Diamond = result;
    }
}