using Day19.Logic;
using static Day19.UnitTests.Constants;

namespace Day19.UnitTests;

public class RobotBlueprint2Must
{
    [Fact]
    public void ParseBlueprintCorrectly_WhenBlueprintHasOneElement()
    {
        var sut = new RobotBlueprint2("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.");
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

    [Fact]
    public void ParseBlueprintCorrectly_WhenBlueprintHasTwoElements()
    {
        var sut = new RobotBlueprint2(@"Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
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
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.", 9)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.", 12)]
    public void CalculateQualityLevelCorrectly_WithOneBlueprint(string input, int expectedLevel)
    {
        var sut = new RobotBlueprint2(input);
        sut.Run();
        Assert.Equal(expectedLevel, sut.QualityLevel);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new RobotBlueprint2(SAMPLE_INPUT);
        sut.Run();
        Assert.Equal(33, sut.QualityLevel);
    }

    [Theory]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 19 clay. Each geode robot costs 2 ore and 12 obsidian.", 1)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 2 ore and 9 obsidian.", 2)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 3 ore and 10 obsidian.", 6)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 14 clay. Each geode robot costs 4 ore and 15 obsidian.", 0)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 12 clay. Each geode robot costs 3 ore and 15 obsidian.", 0)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 3 ore and 19 obsidian.", 0)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 7 clay. Each geode robot costs 4 ore and 17 obsidian.", 1)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 14 clay. Each geode robot costs 3 ore and 16 obsidian.", 0)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 16 clay. Each geode robot costs 2 ore and 9 obsidian.", 5)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 5 clay. Each geode robot costs 3 ore and 7 obsidian.", 8)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 4 ore and 9 obsidian.", 6)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 16 clay. Each geode robot costs 3 ore and 14 obsidian.", 0)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 18 clay. Each geode robot costs 2 ore and 19 obsidian.", 1)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 13 clay. Each geode robot costs 3 ore and 12 obsidian.", 3)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 16 clay. Each geode robot costs 3 ore and 9 obsidian.", 3)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 4 ore and 8 obsidian.", 4)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 2 ore. Each obsidian robot costs 2 ore and 17 clay. Each geode robot costs 2 ore and 10 obsidian.", 9)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 16 clay. Each geode robot costs 2 ore and 11 obsidian.", 5)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 12 clay. Each geode robot costs 3 ore and 8 obsidian.", 2)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 12 clay. Each geode robot costs 3 ore and 17 obsidian.", 1)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 2 ore and 9 obsidian.", 12)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 17 clay. Each geode robot costs 4 ore and 20 obsidian.", 1)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 19 clay. Each geode robot costs 3 ore and 10 obsidian.", 1)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 9 clay. Each geode robot costs 3 ore and 7 obsidian.", 4)]
    [InlineData("Blueprint 1: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 3 ore and 19 obsidian.", 3)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 16 clay. Each geode robot costs 3 ore and 20 obsidian.", 0)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 19 clay. Each geode robot costs 4 ore and 11 obsidian.", 0)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 11 clay. Each geode robot costs 4 ore and 7 obsidian.", 6)]
    [InlineData("Blueprint 1: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 2 ore and 12 obsidian.", 7)]
    [InlineData("Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 2 ore and 15 obsidian.", 1)]
    public void CalculateGeodeAmountCorrectlyForEveryBlueprintInPuzzle(string blueprint, int expectedAmount)
    {
        var sut = new RobotBlueprint2(blueprint);
        sut.Run();
        Assert.Equal(expectedAmount, sut.QualityLevel);
    }

/*
    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new RobotBlueprint2(PUZZLE_INPUT);
        sut.Run();
        Assert.True(1555 < sut.QualityLevel);
    }*/
}