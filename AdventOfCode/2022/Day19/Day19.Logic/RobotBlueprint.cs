namespace Day19.Logic;

public record Blueprint
{
    public int Id { get; }
    public Robot OreRobot { get; }
    public Robot ClayRobot { get; }
    public Robot ObsidianRobot { get; }
    public Robot GeodeRobot { get; }

    public Blueprint(int id, Robot oreRobot, Robot clayRobot, Robot obsidianRobot, Robot geodeRobot)
    {
        Id = id;
        OreRobot = oreRobot;
        ClayRobot = clayRobot;
        ObsidianRobot = obsidianRobot;
        GeodeRobot = geodeRobot;
    }
}

public record Robot
{
    public int ObsidianCost { get; }
    public int ClayCost { get; }
    public int OreCost { get; }

    public Robot(int obsidianCost, int clayCost, int oreCost)
    {
        ObsidianCost = obsidianCost;
        ClayCost = clayCost;
        OreCost = oreCost;
    }
}

public class RobotBlueprint
{
    private string _input;
    private string[] _lines;

    public List<Blueprint> Blueprints { get; private set; }

    public RobotBlueprint(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Blueprints = new List<Blueprint>();

        int id, obsidianCost, clayCost, oreCost;
        Robot oreRobot, clayRobot, obsidianRobot, geodeRobot;
        foreach (var line in _lines)
        {
            var sentences = line.Split(":");
            id = int.Parse(sentences[0][10..]);
            var costs = sentences[1].Split(".");

            oreRobot = new Robot(0, 0, int.Parse(costs[0].Split(" ")[5]));
            clayRobot = new Robot(0, 0, int.Parse(costs[1].Split(" ")[5]));

            oreCost = int.Parse(costs[2].Split(" ")[5]);
            clayCost = int.Parse(costs[2].Split(" ")[8]);
            obsidianRobot = new Robot(0, clayCost, oreCost);

            oreCost = int.Parse(costs[3].Split(" ")[5]);
            obsidianCost = int.Parse(costs[3].Split(" ")[8]);
            geodeRobot = new Robot(obsidianCost, 0, oreCost);

            Blueprints.Add(new Blueprint(id, oreRobot, clayRobot, obsidianRobot, geodeRobot));
        }
    }
}
