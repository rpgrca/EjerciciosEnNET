namespace ArrayReordering.Logic;

public class Reordering
{
    private readonly int[] _values;

    public int[] ReorderedArray { get; private set; }

    public Reordering(int[] values)
    {
        _values = values;
        ReorderedArray = Array.Empty<int>();

        Reorder();
    }

    private void Reorder()
    {
        if (_values.Length < 2)
        {
            KeepSameOrdering();
        }
        else
        {
            ReorderByAlgorithm();
        }
    }

    private void KeepSameOrdering() => ReorderedArray = _values;

    private void ReorderByAlgorithm() => ReorderedArray = _values.Reverse().ToArray();
}