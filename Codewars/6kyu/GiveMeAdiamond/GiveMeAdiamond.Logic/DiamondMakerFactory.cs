namespace GiveMeAdiamond.Logic;

public static class DiamondMakerFactory
{
    public static IDiamondMaker CreateFor(int width) =>
        width < 0 || width % 2 == 0
            ? new NullDiamondMaker()
            : new DiamondMaker(width);
}