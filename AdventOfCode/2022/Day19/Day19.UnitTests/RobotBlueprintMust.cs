using Day19.Logic;
using static Day19.UnitTests.Constants;

namespace Day19.UnitTests;

public class RobotBlueprintMust
{
    [Fact(Skip = "skipped")]
    public void ParseBlueprintCorrectly_WhenBlueprintHasOneElement()
    {
        var sut = new RobotBlueprint("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.");
        Assert.Collection(sut.Blueprints,
            b1 =>
            {
                Assert.Equal(1, b1.Id);
                Assert.Equal(4, b1.OreRobot.OreCost);
                Assert.Equal(0, b1.OreRobot.ClayCost);
                Assert.Equal(0, b1.OreRobot.ObsidianCost);
                Assert.Equal(2, b1.ClayRobot.OreCost);
                Assert.Equal(0, b1.ClayRobot.ClayCost);
                Assert.Equal(0, b1.ClayRobot.ObsidianCost);
                Assert.Equal(3, b1.ObsidianRobot.OreCost);
                Assert.Equal(14, b1.ObsidianRobot.ClayCost);
                Assert.Equal(0, b1.ObsidianRobot.ObsidianCost);
                Assert.Equal(2, b1.GeodeRobot.OreCost);
                Assert.Equal(0, b1.GeodeRobot.ClayCost);
                Assert.Equal(7, b1.GeodeRobot.ObsidianCost);
            });
    }

    [Fact(Skip = "Skipped")]
    public void ParseBlueprintCorrectly_WhenBlueprintHasTwoElements()
    {
        var sut = new RobotBlueprint(@"Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.");
        Assert.Collection(sut.Blueprints,
            b1 =>
            {
                Assert.Equal(1, b1.Id);
                Assert.Equal(4, b1.OreRobot.OreCost);
                Assert.Equal(0, b1.OreRobot.ClayCost);
                Assert.Equal(0, b1.OreRobot.ObsidianCost);
                Assert.Equal(2, b1.ClayRobot.OreCost);
                Assert.Equal(0, b1.ClayRobot.ClayCost);
                Assert.Equal(0, b1.ClayRobot.ObsidianCost);
                Assert.Equal(3, b1.ObsidianRobot.OreCost);
                Assert.Equal(14, b1.ObsidianRobot.ClayCost);
                Assert.Equal(0, b1.ObsidianRobot.ObsidianCost);
                Assert.Equal(2, b1.GeodeRobot.OreCost);
                Assert.Equal(0, b1.GeodeRobot.ClayCost);
                Assert.Equal(7, b1.GeodeRobot.ObsidianCost);
            },
            b2 =>
            {
                Assert.Equal(2, b2.Id);
                Assert.Equal(2, b2.OreRobot.OreCost);
                Assert.Equal(0, b2.OreRobot.ClayCost);
                Assert.Equal(0, b2.OreRobot.ObsidianCost);
                Assert.Equal(3, b2.ClayRobot.OreCost);
                Assert.Equal(0, b2.ClayRobot.ClayCost);
                Assert.Equal(0, b2.ClayRobot.ObsidianCost);
                Assert.Equal(3, b2.ObsidianRobot.OreCost);
                Assert.Equal(8, b2.ObsidianRobot.ClayCost);
                Assert.Equal(0, b2.ObsidianRobot.ObsidianCost);
                Assert.Equal(3, b2.GeodeRobot.OreCost);
                Assert.Equal(0, b2.GeodeRobot.ClayCost);
                Assert.Equal(12, b2.GeodeRobot.ObsidianCost);
            });
    }

    [Theory]
    //[InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.", 9)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.", 12)]
    public void CalculateQualityLevelCorrectly_WithOneBlueprint(string input, int expectedLevel)
    {
        var sut = new RobotBlueprint(input);
        Assert.Equal(expectedLevel, sut.QualityLevel);
    }
/*
    [Fact]
    public void SolveFirstSample()
    {
        var sut = new RobotBlueprint(SAMPLE_INPUT);
        Assert.Equal(33, sut.QualityLevel);
    }*/
}