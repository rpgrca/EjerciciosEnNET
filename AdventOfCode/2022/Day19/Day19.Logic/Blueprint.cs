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
