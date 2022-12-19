using System.Linq;

namespace Day19.Logic;

public record Blueprint
{
    public int Id { get; }
    public RobotFactory OreRobot { get; }
    public RobotFactory ClayRobot { get; }
    public RobotFactory ObsidianRobot { get; }
    public RobotFactory GeodeRobot { get; }

    public Blueprint(int id, RobotFactory oreRobot, RobotFactory clayRobot, RobotFactory obsidianRobot, RobotFactory geodeRobot)
    {
        Id = id;
        OreRobot = oreRobot;
        ClayRobot = clayRobot;
        ObsidianRobot = obsidianRobot;
        GeodeRobot = geodeRobot;
    }

    public RobotFactory GetFactoryForRobotOfType(char type) =>
        type switch {
            '0' => OreRobot,
            '1' => ClayRobot,
            '2' => ObsidianRobot,
            _ => GeodeRobot
        };
}

public class RobotFactory
{
    private readonly Func<(int, int, int, int)> _generation;
    public int ObsidianCost { get; }
    public int ClayCost { get; }
    public int OreCost { get; }

    public RobotFactory(int obsidianCost, int clayCost, int oreCost, Func<(int, int, int, int)> generation)
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

public class Robot
{
    private readonly Func<(int, int, int, int)> _generation;

    public Robot(Func<(int, int, int, int)> generation) => _generation = generation;

    public (int Geode, int Obsidian, int Clay, int Ore) Generate() => _generation();
}

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

public class RobotBlueprint
{
    private readonly string _input;
    private readonly string[] _lines;

    public List<Blueprint> Blueprints { get; private set; }
    public int QualityLevel { get; private set; }

    public RobotBlueprint(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Blueprints = new List<Blueprint>();

        int id, obsidianCost, clayCost, oreCost;
        RobotFactory oreRobot, clayRobot, obsidianRobot, geodeRobot;
        foreach (var line in _lines)
        {
            var sentences = line.Split(":");
            id = int.Parse(sentences[0][10..]);
            var costs = sentences[1].Split(".");

            oreRobot = new RobotFactory(0, 0, int.Parse(costs[0].Split(" ")[5]), () => (0, 0, 0, 1));
            clayRobot = new RobotFactory(0, 0, int.Parse(costs[1].Split(" ")[5]), () => (0, 0, 1, 0));

            oreCost = int.Parse(costs[2].Split(" ")[5]);
            clayCost = int.Parse(costs[2].Split(" ")[8]);
            obsidianRobot = new RobotFactory(0, clayCost, oreCost, () => (0, 1, 0, 0));

            oreCost = int.Parse(costs[3].Split(" ")[5]);
            obsidianCost = int.Parse(costs[3].Split(" ")[8]);
            geodeRobot = new RobotFactory(obsidianCost, 0, oreCost, () => (1, 0, 0, 0));

            Blueprints.Add(new Blueprint(id, oreRobot, clayRobot, obsidianRobot, geodeRobot));
        }

        var combinations = GenerateRobotCombinations()
            .Where(p => p[0] <= p[1] && p[1] <= p[2] && p[2] <= p[3] && p.Contains('1') && p.Contains('2') && p.Contains('3'));

        var pool = new Pool();
        var robotGeneration = new Pool();

        var cache = LoadCache();
        foreach (var blueprint in Blueprints)
        {
            var maximumGeode = 0;

            foreach (var combination in combinations)
            {
                var removed = combination.Length - 1;
                var found = false;
                var robotToCreate = 0;
                var minutes = 0;
                var createRobot = false;
                var createdRobots = string.Empty;
                RobotFactory? factory = null;

                robotGeneration.Reset();
                pool.Reset();

                while (!found && removed > 2)
                {
                    if (cache.TryGetValue(combination[0..removed], out ((int Geode, int Obsidian, int Clay, int Ore) RobotGeneration, (int Geode, int Obsidian, int Clay, int Ore) CurrentPool, int Minutes) value))
                    {
                        found = true;
                        robotGeneration.Add(value.RobotGeneration);
                        pool.Add(value.CurrentPool);
                        minutes = value.Minutes;
                        createdRobots = combination[0..removed];
                        robotToCreate = createdRobots.Length;
                    }

                    removed--;
                }

                if (!found)
                {
                    robotGeneration.Add(0, 0, 0, 1);
                }

                while (minutes < 24)
                {
                    if (robotToCreate < 16)
                    {
                        factory = blueprint.GetFactoryForRobotOfType(combination[robotToCreate]);
                        if (factory.CanCreateWith(pool))
                        {
                            pool.Spend(factory.ObsidianCost, factory.ClayCost, factory.OreCost);
                            createRobot = true;
                        }
                    }

                    pool.Add(robotGeneration);

                    if (createRobot)
                    {
                        var robot = factory!.Create();
                        robotGeneration.Add(robot.Generate());

                        createdRobots += combination[robotToCreate];
                        robotToCreate += 1;
                        createRobot = false;
                    }

                    minutes += 1;

                    if (createdRobots.Length > 2 && createdRobots.Length < 16 && !cache.ContainsKey(createdRobots))
                    {
                        cache.Add(createdRobots, ((robotGeneration.Geode, robotGeneration.Obsidian, robotGeneration.Clay, robotGeneration.Ore), (pool.Geode, pool.Obsidian, pool.Clay, pool.Ore), minutes));
                    }
                }

                if (pool.Geode > maximumGeode)
                {
                    maximumGeode = pool.Geode;
                }
            }

            QualityLevel += blueprint.Id * maximumGeode;

            SaveCache(cache);
        }
    }

    private void SaveCache(Dictionary<string, ((int Geode, int Obsidian, int Clay, int Ore) RobotGeneration, (int Geode, int Obsidian, int Clay, int Ore) CurrentPool, int Minutes)> cache)
    {
            System.IO.File.AppendAllLines("__cache.txt", cache.Select(p => p.Key + "|" + p.Value.RobotGeneration.ToString() + "|" + p.Value.CurrentPool.ToString() + "|" + p.Value.Minutes));
    }

    private Dictionary<string, ((int Geode, int Obsidian, int Clay, int Ore) RobotGeneration, (int Geode, int Obsidian, int Clay, int Ore) CurrentPool, int Minutes)> LoadCache()
    {
        var cache = new Dictionary<string, ((int Geode, int Obsidian, int Clay, int Ore) RobotGeneration, (int Geode, int Obsidian, int Clay, int Ore) CurrentPool, int Minutes)>();

        var lines = File.ReadAllLines("__cache.txt");
        foreach (var line in lines)
        {
            var segments = line.Split("|");
            var key = segments[0];
            var generationSegments = segments[1][1..^1].Split(", ").Select(p => int.Parse(p)).ToArray();
            var generation = (generationSegments[0], generationSegments[1], generationSegments[2], generationSegments[3]);
            var poolSegments =  segments[2][1..^1].Split(", ").Select(p => int.Parse(p)).ToArray();
            var pool = (poolSegments[0], poolSegments[1], poolSegments[2], poolSegments[3]);
            var minutes = int.Parse(segments[3]);
            cache.Add(key, (generation, pool, minutes));
        }
        return cache;
    }

    private static List<string> RemoveCombinationsWithoutNeededRobots(List<string> combinations) =>
        combinations.Where(p => p.Contains('1') && p.Contains('2') && p.Contains('3')).ToList();

    private static List<string> RemoveRobotsCreatedBeforeNeededRobots(List<string> combinations) =>
        combinations.Where(p => p[0] <= p[1] && p[1] <= p[2] && p[2] <= p[3]).ToList();

    private IEnumerable<string> GenerateRobotCombinations()
    {
        foreach (var robot1 in "01")
        {
            foreach (var robot2 in "012")
            {
                foreach (var robot3 in "0123")
                {
                    foreach (var robot4 in "0123")
                    {
                        foreach (var robot5 in "0123")
                        {
                            foreach (var robot6 in "0123")
                            {
                                foreach (var robot7 in "0123")
                                {
                                    foreach (var robot8 in "0123")
                                    {
                                        foreach (var robot9 in "0123")
                                        {
                                            foreach (var robot10 in "0123")
                                            {
                                                foreach (var robot11 in "0123")
                                                {
                                                    foreach (var robot12 in "0123")
                                                    {
                                                        foreach (var robot13 in "0123")
                                                        {
                                                            foreach (var robot14 in "0123")
                                                            {
                                                                foreach (var robot15 in "0123")
                                                                {
                                                                    foreach (var robot16 in "0123")
                                                                    {
                                                                        yield return $"{robot1}{robot2}{robot3}{robot4}{robot5}{robot6}{robot7}{robot8}{robot9}{robot10}{robot11}{robot12}{robot13}{robot14}{robot15}{robot16}";
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                               }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
