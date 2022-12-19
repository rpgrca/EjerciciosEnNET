using Day19.Logic;
using static Day19.UnitTests.Constants;

namespace Day19.UnitTests;

public class RobotBlueprintMust
{
    [Fact]
    public void Test1()
    {
        var sut = new RobotBlueprint("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.");
        Assert.Equal(1, sut.Blueprints);
    }
}