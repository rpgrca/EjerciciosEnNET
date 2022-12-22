namespace Day19.Logic;

public class RobotBlueprint2
{
    private readonly string _input;
    private readonly string[] _lines;

    public List<Blueprint> Blueprints { get; private set; }
    public int QualityLevel { get; private set; }

    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _oreRobot = (0, 0, 0, 1);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _clayRobot = (0, 0, 1, 0);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _obsidianRobot = (0, 1, 0, 0);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _geodeRobot = (1, 0, 0, 0);

    public RobotBlueprint2(string input)
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

            oreRobot = new RobotFactory(0, 0, int.Parse(costs[0].Split(" ")[5]), _oreRobot, 13);
            clayRobot = new RobotFactory(0, 0, int.Parse(costs[1].Split(" ")[5]), _clayRobot, 7);

            oreCost = int.Parse(costs[2].Split(" ")[5]);
            clayCost = int.Parse(costs[2].Split(" ")[8]);
            obsidianRobot = new RobotFactory(0, clayCost, oreCost, _obsidianRobot, 3);

            oreCost = int.Parse(costs[3].Split(" ")[5]);
            obsidianCost = int.Parse(costs[3].Split(" ")[8]);
            geodeRobot = new RobotFactory(obsidianCost, 0, oreCost, _geodeRobot, 1);

            Blueprints.Add(new Blueprint(id, oreRobot, clayRobot, obsidianRobot, geodeRobot));
        }
    }

    public void Run()
    {
        var pool = new Pool();
        var minute = 0;
        var robotGeneration = new Pool();
        robotGeneration.Add(0, 0, 0, 1);

        foreach (var blueprint in Blueprints)
        {
            var maximumGeode = 0;

            while (minute < 24)
            {
                (int, RobotFactory)[] timeForNextRobot =
                {
                    ( blueprint.OreRobot.UntilNextAvailable(pool, robotGeneration), blueprint.OreRobot ),
                    ( blueprint.ClayRobot.UntilNextAvailable(pool, robotGeneration), blueprint.ClayRobot ),
                    ( blueprint.ObsidianRobot.UntilNextAvailable(pool, robotGeneration), blueprint.ObsidianRobot ),
                    ( blueprint.GeodeRobot.UntilNextAvailable(pool, robotGeneration), blueprint.GeodeRobot )
                };

                var nextRobot = timeForNextRobot.MinBy(p => p.Item1 * p.Item2.Priority);
                var repetitions = nextRobot.Item1;
                while (repetitions > 0)
                {
                    minute += 1;
                    repetitions -= 1;
                    pool.Add(robotGeneration);
                }

                minute += 1;
                pool.Spend(nextRobot.Item2.ObsidianCost, nextRobot.Item2.ClayCost, nextRobot.Item2.OreCost);
                pool.Add(robotGeneration);
                robotGeneration.Add(nextRobot.Item2.Create().Generate());
            }

            QualityLevel += blueprint.Id * pool.Geode;
        }
    }
}