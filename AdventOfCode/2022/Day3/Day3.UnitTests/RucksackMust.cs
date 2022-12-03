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
}