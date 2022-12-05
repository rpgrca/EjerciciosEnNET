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
            if (line[1] == '1')
            {
                break;
            }

            if (line[1] != ' ')
            {
                Stacks[0].Add(line[1]);
            }

            if (line[5] != ' ')
            {
                Stacks[1].Add(line[5]);
            }

            if (line[9] != ' ')
            {
                Stacks[2].Add(line[9]);
            }
        }
    }
}
