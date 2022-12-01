namespace Day1.UnitTests;

using Day1.Logic;
using static Constants;

public class CalorieCounterMust
{
    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new CalorieCounter(SAMPLE_INPUT);
        Assert.Equal(24000, sut.MostCaloriesCarriedBySingleElf);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new CalorieCounter(PUZZLE_INPUT);
        Assert.Equal(69501, sut.MostCaloriesCarriedBySingleElf);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new CalorieCounter(SAMPLE_INPUT);
        Assert.Equal(45000, sut.CaloriesCarriedByTopThreeElves);
    }
}