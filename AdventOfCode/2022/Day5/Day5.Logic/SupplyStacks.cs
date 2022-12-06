namespace Day5.Logic;

public class SupplyStacks
{
    private readonly string _input;
    private string[] _lines;
    private readonly Func<int, int, (int, int)> _setup;

    public List<List<char>> Stacks { get; private set; }
    public string TopCrates { get; private set; }
    public int StackCount { get; private set; }

    public static SupplyStacks CreateForFirstPuzzle(string input) =>
        new(input, (c, a) => (c, a));

    public static SupplyStacks CreateForSecondPuzzle(string input) =>
        new(input, (c, a) => (a, c));

    private SupplyStacks(string input, Func<int, int, (int, int)> setup)
    {
        _input = input;
        _setup = setup;

        TopCrates = string.Empty;
        Stacks = new List<List<char>>();

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
            Stacks.Add(new List<char>());
        }
    }

    private void CalculateTopCrates() => 
        TopCrates = Stacks
            .Where(s => s.Count > 0)
            .Aggregate(string.Empty, (t, i) => t += i.First());

    internal (int, int) SetupRepetitionAndAmountTimes(int cycles, int amount) =>
        _setup(cycles, amount);

    internal List<char> RetrieveCratesFrom(int amount, int from)
    {
        var crates = Stacks[from].Take(amount).ToList();
        Stacks[from].RemoveRange(0, amount);
        return crates;
    }

    internal void PutCratesOn(List<char> crates, int to) =>
        Stacks[to].InsertRange(0, crates);

    internal void AddCrateTo(char crate, int index) => Stacks[index].Add(crate);
}