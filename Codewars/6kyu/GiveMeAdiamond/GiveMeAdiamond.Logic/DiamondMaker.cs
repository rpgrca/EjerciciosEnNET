namespace GiveMeAdiamond.Logic;

public class DiamondMaker : IDiamondMaker
{
    public string? Diamond { get; }

    internal DiamondMaker(int n)
    {
        for (var index = 1; index <= n; index += 2)
        {
            Diamond += new string(' ', (n - index) / 2) + new string('*', index) + "\n";
        }

        for (var index = n - 2; index >= 1; index -= 2)
        {
            Diamond += new string(' ', (n - index) / 2) + new string('*', index) + "\n";
        }
    }
}
