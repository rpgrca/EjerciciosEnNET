namespace Day4.Logic;

public class CampCleanup
{
    private readonly string _input;
    private readonly Func<int[], int[], bool> _condition;

    public int OverlapCount { get; private set; }

    public static CampCleanup CreateForFirstPuzzle(string input) =>
        new(input, (l, r) => (r[0] <= l[0] && l[1] <= r[1]) || (l[0] <= r[0] && r[1] <= l[1]));

    public static CampCleanup CreateForSecondPuzzle(string input) =>
        new(input, (l, r) => r[0] <= l[1] && l[0] <= r[1]);

    private CampCleanup(string input, Func<int[], int[], bool> condition)
    {
        _input = input;
        _condition = condition;
        Parse();
    }

    private void Parse()
    {
        foreach (var line in _input.Split('\n'))
        {
            var pairs = line.Split(',');
            var leftSections = pairs[0].Split('-').Select(p => int.Parse(p)).ToArray();
            var rightSections = pairs[1].Split('-').Select(p => int.Parse(p)).ToArray();

            if (_condition(leftSections, rightSections))
            {
                OverlapCount++;
            }
        }
    }
}