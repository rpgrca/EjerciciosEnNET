namespace Day19.Logic;

public class RobotBlueprint2
{
    private readonly string _input;
    private readonly int _minutes;
    private readonly string[] _lines;

    public List<Blueprint> Blueprints { get; private set; }
    public int QualityLevel { get; private set; }
    public int Result { get; private set; }

    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _oreRobot = (0, 0, 0, 1);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _clayRobot = (0, 0, 1, 0);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _obsidianRobot = (0, 1, 0, 0);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _geodeRobot = (1, 0, 0, 0);

    public RobotBlueprint2(string input, int minutes = 24)
    {
        _input = input;
        _minutes = minutes;
        _lines = _input.Split("\n");
        Result = 1;
        Blueprints = new List<Blueprint>();

        int id, obsidianCost, clayCost, oreCost;
        RobotFactory oreRobot, clayRobot, obsidianRobot, geodeRobot;

        var counter = 0;
        foreach (var line in _lines)
        {
            counter++;
            if (minutes == 32 && counter > 3)
            {
                break;
            }
            var sentences = line.Split(":");
            id = int.Parse(sentences[0][10..]);
            var costs = sentences[1].Split(".");

            oreRobot = new RobotFactory("Ore Robot Factory", 0, 0, int.Parse(costs[0].Split(" ")[5]), _oreRobot);
            clayRobot = new RobotFactory("Clay Robot Factory", 0, 0, int.Parse(costs[1].Split(" ")[5]), _clayRobot);

            oreCost = int.Parse(costs[2].Split(" ")[5]);
            clayCost = int.Parse(costs[2].Split(" ")[8]);
            obsidianRobot = new RobotFactory("Obsidian Robot Factory", 0, clayCost, oreCost, _obsidianRobot);

            oreCost = int.Parse(costs[3].Split(" ")[5]);
            obsidianCost = int.Parse(costs[3].Split(" ")[8]);
            geodeRobot = new RobotFactory("Geode Robot Factory", obsidianCost, 0, oreCost, _geodeRobot);

            Blueprints.Add(new Blueprint(id, oreRobot, clayRobot, obsidianRobot, geodeRobot));
        }
    }

    public void Run()
    {
        var emptyPool = new Pool();
        var initialRobotGeneration = new Pool();
        initialRobotGeneration.Add(0, 0, 0, 1);

        foreach (var blueprint in Blueprints)
        {
            (int TimeToHarvest, int CurrentTime,
                (int Geode, int Obsidian, int Clay, int Ore) Pool,
                (int Geode, int Obsidian, int Clay, int Ore) DailyHarvest,
                RobotFactory Factory) queueItem;
            var queue = new PriorityQueue<(int TimeToHarvest, int CurrentTime,
                (int Geode, int Obsidian, int Clay, int Ore) Pool,
                (int Geode, int Obsidian, int Clay, int Ore) DailyHarvest,
                RobotFactory Factory), int>();
            var maximumGeode = 0;
            (int, RobotFactory)[] timeForNextRobot =
            {
                ( blueprint.OreRobot.UntilNextAvailable(emptyPool, initialRobotGeneration), blueprint.OreRobot ),
                ( blueprint.ClayRobot.UntilNextAvailable(emptyPool, initialRobotGeneration), blueprint.ClayRobot ),
                ( blueprint.ObsidianRobot.UntilNextAvailable(emptyPool, initialRobotGeneration), blueprint.ObsidianRobot ),
                ( blueprint.GeodeRobot.UntilNextAvailable(emptyPool, initialRobotGeneration), blueprint.GeodeRobot )
            };

            if (timeForNextRobot[0].Item1 != 1000)
            {
                var toQueue1 = (timeForNextRobot[0].Item1, 0, emptyPool.ToTuple(), initialRobotGeneration.ToTuple(), timeForNextRobot[0].Item2);
                queue.Enqueue(toQueue1, toQueue1.Item2);
            }

            if (timeForNextRobot[1].Item1 != 1000)
            {
                var toQueue1 = (timeForNextRobot[1].Item1, 0, emptyPool.ToTuple(), initialRobotGeneration.ToTuple(), timeForNextRobot[1].Item2);
                queue.Enqueue(toQueue1, toQueue1.Item2);
            }

            if (timeForNextRobot[2].Item1 != 1000)
            {
                var toQueue1 = (timeForNextRobot[2].Item1, 0, emptyPool.ToTuple(), initialRobotGeneration.ToTuple(), timeForNextRobot[2].Item2);
                queue.Enqueue(toQueue1, toQueue1.Item2);
            }

            if (timeForNextRobot[3].Item1 != 1000)
            {
                var toQueue1 = (timeForNextRobot[3].Item1, 0, emptyPool.ToTuple(), initialRobotGeneration.ToTuple(), timeForNextRobot[3].Item2);
                queue.Enqueue(toQueue1, toQueue1.Item2);
            }

            while (queue.Count > 0)
            {
                var currentCombination = queue.Dequeue();

                var accumulatedPool = new Pool(
                    currentCombination.Pool.Geode + (currentCombination.DailyHarvest.Geode * (currentCombination.TimeToHarvest + 1)),
                    currentCombination.Pool.Obsidian + (currentCombination.DailyHarvest.Obsidian * (currentCombination.TimeToHarvest + 1)),
                    currentCombination.Pool.Clay + (currentCombination.DailyHarvest.Clay * (currentCombination.TimeToHarvest + 1)),
                    currentCombination.Pool.Ore + (currentCombination.DailyHarvest.Ore * (currentCombination.TimeToHarvest + 1)));

                accumulatedPool.Spend(currentCombination.Factory.ObsidianCost, currentCombination.Factory.ClayCost, currentCombination.Factory.OreCost);

                if (accumulatedPool.Geode > maximumGeode)
                {
                    maximumGeode = accumulatedPool.Geode;
                }

                var nextRobotGeneration = new Pool(currentCombination.DailyHarvest);
                nextRobotGeneration.Add(currentCombination.Factory.Create().Generate());

                var currentTime = currentCombination.TimeToHarvest + 1 + currentCombination.CurrentTime;
                var queued = false;

                var timeLeft = _minutes - currentTime;
                if (timeLeft > 1)
                {
                    var possibleGeodes = accumulatedPool.Geode + timeLeft * nextRobotGeneration.Geode + (timeLeft * (timeLeft + 1) / 2);
                    if (possibleGeodes < maximumGeode)
                    {
                        continue;
                    }

                    (int TimeToHarvest, RobotFactory Factory)[] timeForNextRobot1 =
                    {
                        ( blueprint.OreRobot.UntilNextAvailable(accumulatedPool, nextRobotGeneration), blueprint.OreRobot ),
                        ( blueprint.ClayRobot.UntilNextAvailable(accumulatedPool, nextRobotGeneration), blueprint.ClayRobot ),
                        ( blueprint.ObsidianRobot.UntilNextAvailable(accumulatedPool, nextRobotGeneration), blueprint.ObsidianRobot ),
                        ( blueprint.GeodeRobot.UntilNextAvailable(accumulatedPool, nextRobotGeneration), blueprint.GeodeRobot )
                    };

                    queueItem = (timeForNextRobot1[0].TimeToHarvest, currentTime, accumulatedPool.ToTuple(), nextRobotGeneration.ToTuple(), timeForNextRobot1[0].Factory);
                    if (queueItem.TimeToHarvest + queueItem.CurrentTime < _minutes && nextRobotGeneration.Ore < blueprint.MaximumOreRobots)
                    {
                        queue.Enqueue(queueItem, _minutes - queueItem.CurrentTime);
                        queued = true;
                    }

                    queueItem = (timeForNextRobot1[1].TimeToHarvest, currentTime, accumulatedPool.ToTuple(), nextRobotGeneration.ToTuple(), timeForNextRobot1[1].Factory);
                    if (queueItem.TimeToHarvest + queueItem.CurrentTime < _minutes && nextRobotGeneration.Clay < blueprint.MaximumClayRobots)
                    {
                        queue.Enqueue(queueItem, _minutes - queueItem.CurrentTime);
                        queued = true;
                    }

                    queueItem = (timeForNextRobot1[2].TimeToHarvest, currentTime, accumulatedPool.ToTuple(), nextRobotGeneration.ToTuple(), timeForNextRobot1[2].Factory);
                    if (queueItem.TimeToHarvest + queueItem.CurrentTime < _minutes)
                    {
                        queue.Enqueue(queueItem, _minutes - queueItem.CurrentTime);
                        queued = true;
                    }

                    queueItem = (timeForNextRobot1[3].TimeToHarvest, currentTime, accumulatedPool.ToTuple(), nextRobotGeneration.ToTuple(), timeForNextRobot1[3].Factory);
                    if (queueItem.TimeToHarvest + queueItem.CurrentTime < _minutes)
                    {
                        queue.Enqueue(queueItem, _minutes - queueItem.CurrentTime);
                        queued = true;
                    }
                }

                if (! queued)
                {
                    if (nextRobotGeneration.Geode > 0 && currentTime < _minutes)
                    {
                        var daysLeft = _minutes - currentTime;
                        var geodesToCome = nextRobotGeneration.Geode * daysLeft;
                        var totalGeodes = accumulatedPool.Geode + geodesToCome;
                        if (totalGeodes > maximumGeode)
                        {
                            maximumGeode = totalGeodes;
                        }
                    }
                }
            }

            QualityLevel += blueprint.Id * maximumGeode;
            Result *= maximumGeode;
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

            oreRobot = new RobotFactory("Ore Robot Factory", 0, 0, int.Parse(costs[0].Split(" ")[5]), _oreRobot);
            clayRobot = new RobotFactory("Clay Robot Factory", 0, 0, int.Parse(costs[1].Split(" ")[5]), _clayRobot);

            oreCost = int.Parse(costs[2].Split(" ")[5]);
            clayCost = int.Parse(costs[2].Split(" ")[8]);
            obsidianRobot = new RobotFactory("Obsidian Robot Factory", 0, clayCost, oreCost, _obsidianRobot);

            oreCost = int.Parse(costs[3].Split(" ")[5]);
            obsidianCost = int.Parse(costs[3].Split(" ")[8]);
            geodeRobot = new RobotFactory("Geode Robot Factory", obsidianCost, 0, oreCost, _geodeRobot);

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