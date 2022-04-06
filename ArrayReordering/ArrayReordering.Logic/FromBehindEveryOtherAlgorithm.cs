namespace ArrayReordering.Logic;

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