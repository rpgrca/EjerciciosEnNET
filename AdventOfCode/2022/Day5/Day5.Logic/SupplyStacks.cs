namespace Day5.Logic;
public class SupplyStacks
{
    private readonly string _input;
    private readonly int _stackCount;
    private readonly bool newVersion;

    public List<List<char>> Stacks { get; private set; }
    public string TopCrates { get; private set; }

    public SupplyStacks(string input, int stackCount, bool newVersion = false)
    {
        _input = input;
        _stackCount = stackCount;
        this.newVersion = newVersion;
        Stacks = new List<List<char>>();

        for (var index = 0; index < _stackCount; index++)
        {
            Stacks.Add(new List<char>());
        }

        Parse();
    }

    private void Parse()
    {
        foreach (var line in _input.Split("\n"))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line[1] == '1') continue;

            if (line.StartsWith("move"))
            {
                var tokens = line.Split(" ");

                if (newVersion)
                {
                    var from = int.Parse(tokens[3]) - 1;
                    var to = int.Parse(tokens[5]) - 1;
                    var amount = int.Parse(tokens[1]);

                    var crates = Stacks[from].Take(amount).ToList();
                    Stacks[from].RemoveRange(0, amount);

                    var list = new List<char>(crates);
                    list.AddRange(Stacks[to]);
                    Stacks[to] = list;
                }
                else
                {
                    for (var index = 0; index < int.Parse(tokens[1]); index++)
                    {
                        var from = int.Parse(tokens[3]) - 1;
                        var to = int.Parse(tokens[5]) - 1;
                        var crate = Stacks[from][0];
                        Stacks[from].RemoveAt(0);
                        Stacks[to].Insert(0, crate);
                    }
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

        foreach (var stack in Stacks)
        {
            if (stack.Count > 0)
            {
                TopCrates += stack[0];
            }
        }
    }
}
