namespace GiveMeAdiamond.Logic;

public class DiamondMaker : IDiamondMaker
{
    private readonly int _width;

    public string? Diamond { get; private set; }

    internal DiamondMaker(int width)
    {
        _width = width;

        Build(1, i => i <= _width, 2);
        Build(_width - 2, i => 1 <= i, -2);
    }

    private void Build(int from, Func<int, bool> condition, int step)
    {
        for (var index = from; condition(index); index += step)
        {
            Diamond += new string(' ', (_width - index) / 2) + new string('*', index) + "\n";
        }
    }
}