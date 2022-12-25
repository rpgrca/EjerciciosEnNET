using System.Diagnostics;

namespace Day19.Logic;

[DebuggerDisplay("{Ore}or/{Clay}cl/{Obsidian}ob/{Geode}ge")]
public struct Pool
{
    public int Geode { get; private set; }
    public int Obsidian { get; private set; }
    public int Clay { get; private set; }
    public int Ore { get; private set; }

    public void Spend(int obsidianCost, int clayCost, int oreCost)
    {
        Obsidian -= obsidianCost;
        Clay -= clayCost;
        Ore -= oreCost;
    }

    public void Add((int Geode, int Obsidian, int Clay, int Ore) production)
    {
        Geode += production.Geode;
        Obsidian += production.Obsidian;
        Clay += production.Clay;
        Ore += production.Ore;
    }

    public void Add(int geode, int obsidian, int clay, int ore)
    {
        Geode += geode;
        Obsidian += obsidian;
        Clay += clay;
        Ore += ore;
    }

    public Pool(int geode, int obsidian, int clay, int ore) => Add(geode, obsidian, clay, ore);

    public Pool((int Geode, int Obsidian, int Clay, int Ore) values) => Add(values);

    public (int Geode, int Obsidian, int Clay, int Ore) ToTuple() => (Geode, Obsidian, Clay, Ore);
}
