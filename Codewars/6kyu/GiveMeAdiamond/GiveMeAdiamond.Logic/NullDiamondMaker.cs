namespace GiveMeAdiamond.Logic;

public class NullDiamondMaker : IDiamondMaker
{
    internal NullDiamondMaker()
    {
    }

    public string? Diamond => null;
}