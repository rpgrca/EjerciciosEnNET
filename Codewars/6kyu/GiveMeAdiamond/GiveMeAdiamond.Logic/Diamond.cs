using System;

namespace GiveMeAdiamond.Logic;

public class Diamond
{
    public static string? Print(int n) =>
        DiamondMakerFactory.CreateFor(n).Diamond;
}