namespace ArrayReordering.Logic;

public class FromBehindEveryOtherAlgorithm : IReorderAlgorithm
{
    public int[] Reorder(int[] values)
    {
        var head = 0;
        var tail = values.Length - 1;
        var index = tail;
        var reorderedArray = new int[values.Length];

        while (tail > head)
        {
            reorderedArray[head++] = values[index--];
            reorderedArray[tail--] = values[index--];
        }

        if (tail == head)
        {
            reorderedArray[head] = values[index];
        }

        return reorderedArray;
    }
}