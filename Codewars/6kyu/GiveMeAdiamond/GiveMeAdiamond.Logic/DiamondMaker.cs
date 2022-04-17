namespace GiveMeAdiamond.Logic;

public class DiamondMaker : IDiamondMaker
{
    public string? Diamond { get; }

    public DiamondMaker(int n)
    {
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
