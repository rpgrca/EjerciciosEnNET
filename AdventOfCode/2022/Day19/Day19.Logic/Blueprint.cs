namespace Day19.Logic;

public record Blueprint
{
    public int Id { get; }
    public RobotFactory OreRobot { get; }
    public RobotFactory ClayRobot { get; }
    public RobotFactory ObsidianRobot { get; }
    public RobotFactory GeodeRobot { get; }

    public int MaximumOreRobots { get; }
    public int MaximumClayRobots { get; }
    public int MaximumObsidianRobots { get; }
    public int MaximumGeodeRobots { get; }

    public Blueprint(int id, RobotFactory oreRobot, RobotFactory clayRobot, RobotFactory obsidianRobot, RobotFactory geodeRobot)
    {
        Id = id;
        OreRobot = oreRobot;
        ClayRobot = clayRobot;
        ObsidianRobot = obsidianRobot;
        GeodeRobot = geodeRobot;

        MaximumOreRobots = new[] { OreRobot.OreCost, ClayRobot.OreCost, ObsidianRobot.OreCost, GeodeRobot.OreCost }.Max();
        MaximumClayRobots = new[] { OreRobot.ClayCost, ClayRobot.ClayCost, ObsidianRobot.ClayCost, GeodeRobot.ClayCost }.Max();
        MaximumObsidianRobots = new[] { OreRobot.ObsidianCost, ClayRobot.ObsidianCost, ObsidianRobot.ObsidianCost, GeodeRobot.ObsidianCost }.Max();
    }

    public RobotFactory GetFactoryForRobotOfType(char type) =>
        type switch {
            '0' => OreRobot,
            '1' => ClayRobot,
            '2' => ObsidianRobot,
            _ => GeodeRobot
        };
}
