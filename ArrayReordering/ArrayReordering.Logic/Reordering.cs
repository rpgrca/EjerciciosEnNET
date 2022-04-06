namespace ArrayReordering.Logic;

public class Reordering
{
    private readonly IReorderAlgorithm _algorithm;

    public int[] ReorderedArray { get; }

    public Reordering(int[] values, IReorderAlgorithm algorithm)
    {
        _algorithm = algorithm;
        ReorderedArray = _algorithm.Reorder(values);
    }
}