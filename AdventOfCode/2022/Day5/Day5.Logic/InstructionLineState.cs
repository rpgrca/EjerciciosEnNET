namespace Day5.Logic;

public class InstructionLineState : ILineState
{
    private readonly SupplyStacks _supplyStacks;
    private readonly string _line;

    public InstructionLineState(SupplyStacks supplyStacks, string line)
    {
        _supplyStacks = supplyStacks;
        _line = line;
    }

    public void Process()
    {
        var tokens = _line.Split(" ");
        var from = int.Parse(tokens[3]) - 1;
        var to = int.Parse(tokens[5]) - 1;

        (int cycles, int amount) = _supplyStacks.GetRepetitionAndAmount(int.Parse(tokens[1]), 1);

        for (var index = 0; index < cycles; index++)
        {
            var crates = _supplyStacks.RetrieveCratesFrom(amount, from);
            _supplyStacks.PutCratesOn(crates, to);
        }
    }
}
