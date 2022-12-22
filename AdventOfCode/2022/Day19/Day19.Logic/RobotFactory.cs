namespace Day19.Logic;

public class RobotFactory
{
    private readonly (int, int, int, int) _generation;
    public int ObsidianCost { get; }
    public int ClayCost { get; }
    public int OreCost { get; }

    public RobotFactory(int obsidianCost, int clayCost, int oreCost, (int, int, int, int) generation)
    {
        ObsidianCost = obsidianCost;
        ClayCost = clayCost;
        OreCost = oreCost;
        _generation = generation;
    }

    public Robot Create() => new(_generation);

    internal bool CanCreateWith(Pool pool) =>
        pool.Obsidian >= ObsidianCost && pool.Clay >= ClayCost && pool.Ore >= OreCost;
}
