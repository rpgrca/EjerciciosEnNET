namespace Day5.Logic;

public class SetupLineState : ILineState
{
    private readonly SupplyStacks _supplyStacks;
    private readonly string _line;

    public SetupLineState(SupplyStacks supplyStacks, string line)
    {
        _supplyStacks = supplyStacks;
        _line = line;
    }

    public void Process()
    {
        for (var index = 0; index < _supplyStacks.StackCount; index++)
        {
            int offset = 1 + (index * 4);
            if (_line[offset] != ' ')
            {
                _supplyStacks.AddCrateTo(_line[offset], index);
            }
        }
    }
}