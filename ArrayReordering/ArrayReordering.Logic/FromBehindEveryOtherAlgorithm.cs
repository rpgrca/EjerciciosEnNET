namespace ArrayReordering.Logic;

public class FromBehindEveryOtherAlgorithm : IReorderAlgorithm
{
    public int[] Reorder(int[] values)
    {
        var head = 0;
        var tail = values.Length - 1;
        var total = new int[values.Length];
        var index = tail;

        while (tail > head)
        {
            total[head++] = values[index--];
            total[tail--] = values[index--];
        }

        if (tail == head)
        {
            total[head] = values[index];
            if (index > 0)
                total[tail] = values[index - 1];
        }

        return total;
    }
}