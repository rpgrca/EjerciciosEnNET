namespace Day5.Logic;

public class SupplyStacks
{
    private readonly List<List<char>> _stacks;
    private readonly string _input;
    private string[] _lines;
    private readonly Func<int, int, (int, int)> _setup;

    internal int StackCount { get; private set; }
    public string TopCrates { get; private set; }

    public static SupplyStacks CreateForFirstPuzzle(string input) =>
        new(input, (c, a) => (c, a));

    public static SupplyStacks CreateForSecondPuzzle(string input) =>
        new(input, (c, a) => (a, c));

    private SupplyStacks(string input, Func<int, int, (int, int)> setup)
    {
        _input = input;
        _setup = setup;
        _lines = Array.Empty<string>();
        _stacks = new List<List<char>>();

        TopCrates = string.Empty;

        Parse();
    }

    private void Parse()
    {
        SplitInputInLines();
        CalculateAmountOfStacks();
        CreateStacks();

        foreach (var line in _lines)
        {
            LineStateFactory.Create(this, line).Process();
        }

        CalculateTopCrates();
    }

    private void SplitInputInLines() => _lines = _input.Split("\n");

    private void CalculateAmountOfStacks() => StackCount = (_lines[0].Length / 4) + 1;

    private void CreateStacks()
    {
        for (var index = 0; index < StackCount; index++)
        {
            _stacks.Add(new List<char>());
        }
    }

    private void CalculateTopCrates() => 
        TopCrates = _stacks
            .Where(s => s.Count > 0)
            .Aggregate(string.Empty, (t, i) => t += i.First());

    internal (int, int) GetRepetitionAndAmount(int cycles, int amount) =>
        _setup(cycles, amount);

    internal List<char> RetrieveCratesFrom(int amount, int from)
    {
        var crates = _stacks[from].Take(amount).ToList();
        _stacks[from].RemoveRange(0, amount);
        return crates;
    }

    internal void PutCratesOn(List<char> crates, int to) =>
        _stacks[to].InsertRange(0, crates);

    internal void AddCrateTo(char crate, int index) => _stacks[index].Add(crate);
}