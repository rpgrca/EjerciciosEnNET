namespace Day5.Logic;
public class SupplyStacks
{
    private readonly string _input;
    private int _stackCount;
    private readonly Func<int, int, (int, int)> _setup;

    public List<List<char>> Stacks { get; private set; }
    public string TopCrates { get; private set; }

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
        var lines = _input.Split("\n");

        _stackCount = (lines[0].Length / 4) + 1;
        for (var index = 0; index < _stackCount; index++)
        {
            Stacks.Add(new List<char>());
        }

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line[1] == '1') continue;

            if (line.StartsWith("move"))
            {
                var tokens = line.Split(" ");
                var from = int.Parse(tokens[3]) - 1;
                var to = int.Parse(tokens[5]) - 1;
                int cycles;
                int amount;

                (cycles, amount) = _setup(int.Parse(tokens[1]), 1);

                for (var index = 0; index < cycles; index++)
                {
                    var crates = Stacks[from].Take(amount).ToList();
                    Stacks[from].RemoveRange(0, amount);
                    Stacks[to].InsertRange(0, crates);
                }
            }
            else
            {
                for (var index = 0; index < _stackCount; index++)
                {
                    int offset = 1 + (index * 4);
                    if (line[offset] != ' ')
                    {
                        Stacks[index].Add(line[offset]);
                    }
                }
            }
        }

        TopCrates = Stacks.Where(s => s.Count > 0).Aggregate(string.Empty, (t, i) => t += i.First());
    }
}
