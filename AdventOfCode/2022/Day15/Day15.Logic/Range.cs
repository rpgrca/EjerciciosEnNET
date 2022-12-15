namespace Day15.Logic;

public record Range
{
    public int Minimum { get; private set; }
    public int Maximum { get; private set; }

    public Range(int minimum, int maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public bool Incluyes(Range other) =>
        Minimum <= other.Minimum && Maximum >= other.Maximum;

    public void UpdateMaximumTo(int end) => Maximum = end;

    public void UpdateMinimumTo(int start) => Minimum = start;
}