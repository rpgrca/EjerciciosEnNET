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

    private void ReorderByAlgorithm()
    {
        var toFront = true;
        var firstHalf = new List<int>();
        var secondHalf = new List<int>();
        foreach (var number in _values.Reverse())
        {
            if (toFront)
            {
                firstHalf.Add(number);
            }
            else
            {
                secondHalf.Insert(0, number);
            }

            toFront = !toFront;
        }

        var total = new List<int>();
        total.AddRange(firstHalf);
        total.AddRange(secondHalf);

        ReorderedArray = total.ToArray();
    }
}