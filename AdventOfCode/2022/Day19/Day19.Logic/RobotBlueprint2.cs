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

            oreRobot = new RobotFactory("Ore Robot Factory", 0, 0, int.Parse(costs[0].Split(" ")[5]), _oreRobot, 13);
            clayRobot = new RobotFactory("Clay Robot Factory", 0, 0, int.Parse(costs[1].Split(" ")[5]), _clayRobot, 7);

            oreCost = int.Parse(costs[2].Split(" ")[5]);
            clayCost = int.Parse(costs[2].Split(" ")[8]);
            obsidianRobot = new RobotFactory("Obsidian Robot Factory", 0, clayCost, oreCost, _obsidianRobot, 3);

            oreCost = int.Parse(costs[3].Split(" ")[5]);
            obsidianCost = int.Parse(costs[3].Split(" ")[8]);
            geodeRobot = new RobotFactory("Geode Robot Factory", obsidianCost, 0, oreCost, _geodeRobot, 1);

            Blueprints.Add(new Blueprint(id, oreRobot, clayRobot, obsidianRobot, geodeRobot));
        }
    }

    public void Run()
    {
        foreach (var blueprint in Blueprints)
        {
            var queue = new PriorityQueue<(int, int,
                (int Geode, int Obsidian, int Clay, int Ore),
                (int Geode, int Obsidian, int Clay, int Ore),
                RobotFactory), int>();
            var maximumGeode = 0;
            var pool = new Pool();
            var robotGeneration = new Pool();
            robotGeneration.Add(0, 0, 0, 1);

            (int, RobotFactory)[] timeForNextRobot =
            {
                ( blueprint.OreRobot.UntilNextAvailable(pool, robotGeneration), blueprint.OreRobot ),
                ( blueprint.ClayRobot.UntilNextAvailable(pool, robotGeneration), blueprint.ClayRobot ),
                ( blueprint.ObsidianRobot.UntilNextAvailable(pool, robotGeneration), blueprint.ObsidianRobot ),
                ( blueprint.GeodeRobot.UntilNextAvailable(pool, robotGeneration), blueprint.GeodeRobot )
            };

            if (timeForNextRobot[0].Item1 != 1000)
            {
                var toQueue1 = (timeForNextRobot[0].Item1, 0, pool.ToTuple(), robotGeneration.ToTuple(), timeForNextRobot[0].Item2);
                queue.Enqueue(toQueue1, toQueue1.Item2);
            }

            if (timeForNextRobot[1].Item1 != 1000)
            {
                var toQueue1 = (timeForNextRobot[1].Item1, 0, pool.ToTuple(), robotGeneration.ToTuple(), timeForNextRobot[1].Item2);
                queue.Enqueue(toQueue1, toQueue1.Item2);
            }

            if (timeForNextRobot[2].Item1 != 1000)
            {
                var toQueue1 = (timeForNextRobot[2].Item1, 0, pool.ToTuple(), robotGeneration.ToTuple(), timeForNextRobot[2].Item2);
                queue.Enqueue(toQueue1, toQueue1.Item2);
            }

            if (timeForNextRobot[3].Item1 != 1000)
            {
                var toQueue1 = (timeForNextRobot[3].Item1, 0, pool.ToTuple(), robotGeneration.ToTuple(), timeForNextRobot[3].Item2);
                queue.Enqueue(toQueue1, toQueue1.Item2);
            }

            while (queue.Count > 0)
            {
                var currentCombination = queue.Dequeue();

                var accumulatedPool = new Pool(
                    currentCombination.Item3.Geode + (currentCombination.Item4.Geode * (currentCombination.Item1)),
                    currentCombination.Item3.Obsidian + (currentCombination.Item4.Obsidian * (currentCombination.Item1)),
                    currentCombination.Item3.Clay + (currentCombination.Item4.Clay * (currentCombination.Item1)),
                    currentCombination.Item3.Ore + (currentCombination.Item4.Ore * (currentCombination.Item1)));

                accumulatedPool.Spend(currentCombination.Item5.ObsidianCost, currentCombination.Item5.ClayCost, currentCombination.Item5.OreCost);
                accumulatedPool.Add(currentCombination.Item4);

                if (accumulatedPool.Geode > maximumGeode)
                {
                    maximumGeode = accumulatedPool.Geode;
                }

                var nextRobotGeneration = new Pool(currentCombination.Item4);
                nextRobotGeneration.Add(currentCombination.Item5.Create().Generate());

                (int, RobotFactory)[] timeForNextRobot1 =
                {
                    ( blueprint.OreRobot.UntilNextAvailable(accumulatedPool, nextRobotGeneration), blueprint.OreRobot ),
                    ( blueprint.ClayRobot.UntilNextAvailable(accumulatedPool, nextRobotGeneration), blueprint.ClayRobot ),
                    ( blueprint.ObsidianRobot.UntilNextAvailable(accumulatedPool, nextRobotGeneration), blueprint.ObsidianRobot ),
                    ( blueprint.GeodeRobot.UntilNextAvailable(accumulatedPool, nextRobotGeneration), blueprint.GeodeRobot )
                };

                var toQueue = (timeForNextRobot1[0].Item1, currentCombination.Item1 + 1 + currentCombination.Item2, accumulatedPool.ToTuple(), nextRobotGeneration.ToTuple(), timeForNextRobot1[0].Item2);
                if (timeForNextRobot1[0].Item1 != 1000 && toQueue.Item1 + toQueue.Item2 < 24 && nextRobotGeneration.Ore < blueprint.MaximumOreRobots)
                {
                    queue.Enqueue(toQueue, toQueue.Item2);
                }

                toQueue = (timeForNextRobot1[1].Item1, currentCombination.Item1 + 1 + currentCombination.Item2, accumulatedPool.ToTuple(), nextRobotGeneration.ToTuple(), timeForNextRobot1[1].Item2);
                if (timeForNextRobot1[1].Item1 != 1000 && toQueue.Item1 + toQueue.Item2 < 24 && nextRobotGeneration.Clay < blueprint.MaximumClayRobots)
                {
                    queue.Enqueue(toQueue, toQueue.Item2);
                }

                toQueue = (timeForNextRobot1[2].Item1, currentCombination.Item1 + 1 + currentCombination.Item2, accumulatedPool.ToTuple(), nextRobotGeneration.ToTuple(), timeForNextRobot1[2].Item2);
                if (timeForNextRobot1[2].Item1 != 1000 && toQueue.Item1 + toQueue.Item2 < 24)
                {
                    queue.Enqueue(toQueue, toQueue.Item2);
                }

                toQueue = (timeForNextRobot1[3].Item1, currentCombination.Item1 + 1 + currentCombination.Item2, accumulatedPool.ToTuple(), nextRobotGeneration.ToTuple(), timeForNextRobot1[3].Item2);
                if (timeForNextRobot1[3].Item1 != 1000 && toQueue.Item1 + toQueue.Item2 < 24)
                {
                    queue.Enqueue(toQueue, toQueue.Item2);
                }
            }

            QualityLevel += blueprint.Id * maximumGeode;
        }
    }
}

public class RobotBlueprint3
{
    private readonly string _input;
    private readonly string[] _lines;

    public List<Blueprint> Blueprints { get; private set; }
    public int QualityLevel { get; private set; }

    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _oreRobot = (0, 0, 0, 1);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _clayRobot = (0, 0, 1, 0);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _obsidianRobot = (0, 1, 0, 0);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _geodeRobot = (1, 0, 0, 0);

    public RobotBlueprint3(string input)
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

            oreRobot = new RobotFactory("Ore Robot Factory", 0, 0, int.Parse(costs[0].Split(" ")[5]), _oreRobot, 13);
            clayRobot = new RobotFactory("Clay Robot Factory", 0, 0, int.Parse(costs[1].Split(" ")[5]), _clayRobot, 7);

            oreCost = int.Parse(costs[2].Split(" ")[5]);
            clayCost = int.Parse(costs[2].Split(" ")[8]);
            obsidianRobot = new RobotFactory("Obsidian Robot Factory", 0, clayCost, oreCost, _obsidianRobot, 3);

            oreCost = int.Parse(costs[3].Split(" ")[5]);
            obsidianCost = int.Parse(costs[3].Split(" ")[8]);
            geodeRobot = new RobotFactory("Geode Robot Factory", obsidianCost, 0, oreCost, _geodeRobot, 1);

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