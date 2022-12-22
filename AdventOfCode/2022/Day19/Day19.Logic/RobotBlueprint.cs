using System.Linq;

namespace Day19.Logic;


public class RobotBlueprint
{
    private readonly string _input;
    private readonly string[] _lines;

    public List<Blueprint> Blueprints { get; private set; }
    public int QualityLevel { get; private set; }

    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _oreRobot = (0, 0, 0, 1);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _clayRobot = (0, 0, 1, 0);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _obsidianRobot = (0, 1, 0, 0);
    private static readonly (int Geode, int Obsidian, int Clay, int Ore) _geodeRobot = (1, 0, 0, 0);

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

            oreRobot = new RobotFactory(0, 0, int.Parse(costs[0].Split(" ")[5]), _oreRobot, 8);
            clayRobot = new RobotFactory(0, 0, int.Parse(costs[1].Split(" ")[5]), _clayRobot, 6);

            oreCost = int.Parse(costs[2].Split(" ")[5]);
            clayCost = int.Parse(costs[2].Split(" ")[8]);
            obsidianRobot = new RobotFactory(0, clayCost, oreCost, _obsidianRobot, 4);

            oreCost = int.Parse(costs[3].Split(" ")[5]);
            obsidianCost = int.Parse(costs[3].Split(" ")[8]);
            geodeRobot = new RobotFactory(obsidianCost, 0, oreCost, _geodeRobot, 2);

            Blueprints.Add(new Blueprint(id, oreRobot, clayRobot, obsidianRobot, geodeRobot));
        }
    }

    public void Run()
    {
        /*var combinations = GenerateRobotCombinations()
            .Where(p =>
            {
                var p1 = p.IndexOf('1');
                var p2 = p.IndexOf('2');

                return p1 != -1 && p1 < p2 && p2 < p.IndexOf('3');
            });*/

        var combinations = new string[] { "01110122233" };

        var pool = new Pool();
        var robotGeneration = new Pool();

        var cache = new Dictionary<string, ((int Geode, int Obsidian, int Clay, int Ore) RobotGeneration, (int Geode, int Obsidian, int Clay, int Ore) CurrentPool, int Minutes)>();
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
                    if (robotToCreate < combination.Length)
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
        if (false)
        {
            System.IO.File.AppendAllLines("__cache.txt", cache.Select(p => p.Key + "|" + p.Value.RobotGeneration.ToString() + "|" + p.Value.CurrentPool.ToString() + "|" + p.Value.Minutes));
        }
    }

    private static List<string> RemoveCombinationsWithoutNeededRobots(List<string> combinations) =>
        combinations.Where(p => p.Contains('1') && p.Contains('2') && p.Contains('3')).ToList();

    private static List<string> RemoveRobotsCreatedBeforeNeededRobots(List<string> combinations) =>
        combinations.Where(p => p[0] <= p[1] && p[1] <= p[2] && p[2] <= p[3]).ToList();

    private IEnumerable<string> GenerateRobotCombinationsDescending()
    {
        foreach (var robot1 in "01")
        {
            foreach (var robot2 in "012")
            {
                foreach (var robot3 in "3210")
                {
                    foreach (var robot4 in "3210")
                    {
                        foreach (var robot5 in "3210")
                        {
                            foreach (var robot6 in "3210")
                            {
                                foreach (var robot7 in "3210")
                                {
                                    foreach (var robot8 in "3210")
                                    {
                                        foreach (var robot9 in "3210")
                                        {
                                            foreach (var robot10 in "3210")
                                            {
                                                foreach (var robot11 in "3210")
                                                {
                                                    foreach (var robot12 in "3210")
                                                    {
                                                        foreach (var robot13 in "3210")
                                                        {
                                                            foreach (var robot14 in "3210")
                                                            {
                                                                foreach (var robot15 in "3210")
                                                                {
                                                                    foreach (var robot16 in "3210")
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


    private IEnumerable<string> GenerateRobotCombinations()
    {
        foreach (var robot1 in "1")
        {
            foreach (var robot2 in "1")
            {
                foreach (var robot3 in "01")
                {
                    foreach (var robot4 in "012")
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
