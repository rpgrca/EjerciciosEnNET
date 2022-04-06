namespace ArrayReordering.Logic;

public interface IReorderAlgorithm
{
    int[] Reorder(int[] values);
}

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

public class FromBehindEveryOtherAlgorithm : IReorderAlgorithm
{
    public int[] Reorder(int[] values)
    {
        var toFront = true;
        var firstHalf = new List<int>();
        var secondHalf = new List<int>();

        foreach (var number in values.Reverse())
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

        return total.ToArray();
    }
}