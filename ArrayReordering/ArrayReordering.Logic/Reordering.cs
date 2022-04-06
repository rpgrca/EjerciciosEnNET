using System.Collections;

namespace ArrayReordering.Logic;

public class Reordering
{
    private readonly int[] _values;

    public int[] ReorderedArray { get; set; }

    public Reordering(int[] value)
    {
        _values = value;
        ReorderedArray = Array.Empty<int>();
    }

}
