namespace Day5.Logic;
public class SupplyStacks
{
    private string _input;
    private int _stackCount;

    public List<List<char>> Stacks { get; private set; }

    public SupplyStacks(string input, int stackCount)
    {
        _input = input;
        _stackCount = stackCount;
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
                for (var index = 0; index < int.Parse(tokens[1]); index++)
                {
                    var from = int.Parse(tokens[3]) - 1;
                    var to = int.Parse(tokens[5]) - 1;
                    var crate = Stacks[from][0];
                    Stacks[from].RemoveAt(0);
                    Stacks[to].Insert(0, crate);
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
    }
}
