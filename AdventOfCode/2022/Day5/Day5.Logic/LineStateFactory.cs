namespace Day5.Logic;

public class LineStateFactory
{
    public static ILineState Create(SupplyStacks supplyStacks, string line)
    {
        if (line.StartsWith("move"))
        {
            return new InstructionLineState(supplyStacks, line);
        }

        if (string.IsNullOrWhiteSpace(line))
        {
            return new EmptyLineState();
        }

        if (line[1] == '1')
        {
            return new IndexLineState();
        }

        return new SetupLineState(supplyStacks, line);
    }
}