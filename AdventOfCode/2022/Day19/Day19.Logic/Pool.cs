namespace Day19.Logic;

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
}
