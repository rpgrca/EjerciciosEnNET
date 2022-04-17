namespace GiveMeAdiamond.Logic;

public class DiamondMaker : IDiamondMaker
{
    public string? Diamond { get; }

    internal DiamondMaker(int width) =>
        Diamond = Enumerable.Range(1, (width * 2) - 1)
            .Where(i => i % 2 != 0)
            .Aggregate(string.Empty, (t, i) => t + new string(' ', Math.Abs(width - i) / 2) + new string('*', width - Math.Abs(width - i)) + "\n");
}