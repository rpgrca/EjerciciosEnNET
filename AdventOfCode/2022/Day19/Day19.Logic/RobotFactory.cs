using System.Diagnostics;

namespace Day19.Logic;

[DebuggerDisplay("{_name}")]
public class RobotFactory
{
    private readonly string _name;
    private readonly (int, int, int, int) _generation;
    public int ObsidianCost { get; }
    public int ClayCost { get; }
    public int OreCost { get; }

    public RobotFactory(string name, int obsidianCost, int clayCost, int oreCost, (int, int, int, int) generation)
    {
        _name = name;
        ObsidianCost = obsidianCost;
        ClayCost = clayCost;
        OreCost = oreCost;
        _generation = generation;
    }

    public Robot Create() => new(_generation);

    internal int UntilNextAvailable(Pool pool, Pool robotGeneration)
    {
        var neededOre = OreCost - pool.Ore;
        var neededClay = ClayCost - pool.Clay;
        var neededObsidian = ObsidianCost - pool.Obsidian;

        if (neededOre <= 0 && neededClay <= 0 && neededObsidian <= 0)
        {
            return 0;
        }

        int[] time = { 1000, 1000, 1000 };

        if (neededOre <= 0)
        {
            time[0] = 0;
        }
        else if (robotGeneration.Ore != 0)
        {
            time[0] = (int)Math.Ceiling(neededOre / (double)robotGeneration.Ore);
        }

        if (neededClay <= 0)
        {
            time[1] = 0;
        }
        else if (robotGeneration.Clay != 0)
        {
            time[1] = (int)Math.Ceiling(neededClay / (double)robotGeneration.Clay);
        }

        if (neededObsidian <= 0)
        {
            time[2] = 0;
        }
        else if (robotGeneration.Obsidian != 0)
        {
            time[2] = (int)Math.Ceiling(neededObsidian / (double)robotGeneration.Obsidian);
        }

        return time.Max();
    }
}
