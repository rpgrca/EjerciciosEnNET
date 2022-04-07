namespace ArrayReordering.Logic;

public sealed partial class Reordering
{
    private readonly IReorderAlgorithm _algorithm;

    public int[] ReorderedArray { get; }

    private Reordering(int[] values, IReorderAlgorithm algorithm)
    {
        _algorithm = algorithm;
        ReorderedArray = _algorithm.Reorder(values);
    }
}