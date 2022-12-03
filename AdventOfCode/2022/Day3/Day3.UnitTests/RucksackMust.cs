using Day3.Logic;
using static Day3.UnitTests.Constants;

namespace Day3.UnitTests;

public class RucksackMust
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
    [InlineData("PmmdzqPrVvPwwTWBwg", 42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
    [InlineData("ttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw", 39)]
    public void CalculateSumOfPrioritiesCorrectly(string input, int expectedSum)
    {
        var sut = new Rucksack(input);
        Assert.Equal(expectedSum, sut.SumOfPriorities);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new Rucksack(SAMPLE_INPUT);
        Assert.Equal(157, sut.SumOfPriorities);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new Rucksack(PUZZLE_INPUT);
        Assert.Equal(7826, sut.SumOfPriorities);
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg", 18)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw", 52)]
    public void FindGroupBadgeCorrectly(string input, int expectedPriority)
    {
        var sut = new Rucksack(input);
        Assert.Equal(expectedPriority, sut.SumOfBadgePriorities);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new Rucksack(SAMPLE_INPUT);
        Assert.Equal(70, sut.SumOfBadgePriorities);
    }
}