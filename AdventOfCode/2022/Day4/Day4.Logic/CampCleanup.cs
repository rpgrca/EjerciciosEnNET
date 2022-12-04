namespace Day4.Logic;

public class CampCleanup
{
    private readonly string _input;
    private readonly Func<int[], int[], bool> _overlapCondition;
    private string _line;
    private string[] _pair;
    private int[] _leftSections;
    private int[] _rightSections;

    public int OverlapCount { get; private set; }

    public static CampCleanup CreateForFirstPuzzle(string input) =>
        new(input, (l, r) => (r[0] <= l[0] && l[1] <= r[1]) || (l[0] <= r[0] && r[1] <= l[1]));

    public static CampCleanup CreateForSecondPuzzle(string input) =>
        new(input, (l, r) => r[0] <= l[1] && l[0] <= r[1]);

    private CampCleanup(string input, Func<int[], int[], bool> overlapCondition)
    {
        _input = input;
        _overlapCondition = overlapCondition;
        Parse();
    }

    private void Parse()
    {
        foreach (var line in _input.Split('\n'))
        {
            _line = line;

            SplitLineInPair();
            ObtainLeftSections();
            ObtainRightSections();

            if (_overlapCondition(_leftSections, _rightSections))
            {
                OverlapCount++;
            }
        }
    }

    private void SplitLineInPair() => _pair = _line.Split(',');

    private void ObtainLeftSections() => _leftSections = GetSectionsByIndex(0);

    private void ObtainRightSections() => _rightSections = GetSectionsByIndex(1);

    private int[] GetSectionsByIndex(int index) => _pair[index].Split('-').Select(int.Parse).ToArray();
}