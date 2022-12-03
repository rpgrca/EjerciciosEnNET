using Day3.Logic;

namespace Day3.UnitTests;

public class RucksackMust
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
    [InlineData("PmmdzqPrVvPwwTWBwg", 42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
    [InlineData("ttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw", 39)]
    public void Test1(string input, int expectedSum)
    {
        var sut = new Rucksack(input);
        Assert.Equal(expectedSum, sut.SumOfPriorities);
    }
}