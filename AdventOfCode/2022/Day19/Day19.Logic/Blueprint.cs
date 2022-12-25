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

    public Blueprint(int id, RobotFactory oreRobot, RobotFactory clayRobot, RobotFactory obsidianRobot, RobotFactory geodeRobot)
    {
        Id = id;
        OreRobot = oreRobot;
        ClayRobot = clayRobot;
        ObsidianRobot = obsidianRobot;
        GeodeRobot = geodeRobot;

        MaximumOreRobots = new[] { OreRobot.OreCost, ClayRobot.OreCost, ObsidianRobot.OreCost, GeodeRobot.OreCost }.Max();
        MaximumClayRobots = new[] { OreRobot.ClayCost, ClayRobot.ClayCost, ObsidianRobot.ClayCost, GeodeRobot.ClayCost }.Max();
    }
}
