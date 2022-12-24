using System.Diagnostics;

namespace Day19.Logic;

[DebuggerDisplay("{Ore}or/{Clay}cl/{Obsidian}ob/{Geode}ge")]
public struct Pool
{
    public int Geode { get; private set; }
    public int Obsidian { get; private set; }
    public int Clay { get; private set; }
    public int Ore { get; private set; }

    public void Reset() => Geode = Obsidian = Clay = Ore = 0;

    public void Spend(int obsidianCost, int clayCost, int oreCost)
    {
        Obsidian -= obsidianCost;
        Clay -= clayCost;
        Ore -= oreCost;

        if (Obsidian < 0 || Clay < 0 || Ore < 0)
        {
            System.Diagnostics.Debugger.Break();
        }
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

    public void Add(Pool other)
    {
        Geode += other.Geode;
        Obsidian += other.Obsidian;
        Clay += other.Clay;
        Ore += other.Ore;
    }

    public Pool(Pool other) => Add(other);

    public Pool(int geode, int obsidian, int clay, int ore) => Add(geode, obsidian, clay, ore);

    public Pool((int Geode, int Obsidian, int Clay, int Ore) values) => Add(values);

    internal Pool CalculateAccumulatedPoolInNext(int minutes, Pool originalPool)
    {
        var pool = new Pool(originalPool);
        while (minutes-- > 0)
        {
            pool.Add(this);
        }

        return pool;
    }

    public (int Geode, int Obsidian, int Clay, int Ore) ToTuple() => (Geode, Obsidian, Clay, Ore);
}
